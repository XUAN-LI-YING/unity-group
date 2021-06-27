using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

 //更動組員程式碼命名方式以及其解釋理由
 // 若更改造成有 bug 產生，還請多多見諒 !!
 // 很想要更改的地方：(commit上也看得到差異哦)
 // 1. trap02 speed 速度太慢了我想更改
 // 2. 緩速時間參數設置為全域變數
 // 解釋其理由：容易在 unity 調整數值方便團隊開發

public class animy_move : MonoBehaviour
{
  // public static animy_move instance;


  public int Spikedelta = 0;
  public int Trapsdelta = 0;
  public float deltaSum = 0; //delta要比deltaSum大 的值
  public float speed = 0;    //怪物初始速度
  public float spikecollide = 0; //尖刺陷阱碰撞次數加成

  

    
   [Header("有限狀態機FSM")] 
    public bool walking;   //正常走路狀態
    public bool SpikedIsCollide; //尖刺陷阱碰撞判定
    public bool Traps02IsCollide;//捕獸夾碰撞判定
    public bool blacktrap;       //暗黑陷阱碰撞判定
    public bool check;           //判斷碰觸何種陷阱
    public Vector3 EnemyPos; //偵測敵人當下位置

   [Header("尖刺陷阱")] 
    public bool spiketrap;   //尖刺陷阱碰撞判定  
 
   [Header("暗黑陷阱")] 
    public int stucktraptime; //單一陷阱碰撞次數
    public int caseSwitch ;   //暗黑陷阱觸發事件判定

    [Header("秒數設置")]
    public float turnbacktime;  //陷阱效果敵人後退時間
    public float canceltime;    //陷阱效果關閉扣血時間

    [Header("停血開關")]
    public bool Turnon;

  void Start()
  {
    // instance = this;
    check = true;
    walking = true;
    SpikedIsCollide = false;
    Traps02IsCollide=false;
    this.speed = 10f; 
    blacktrap = false;
    stucktraptime = 0;
    turnbacktime = 3;
    canceltime = 5;
 
  }
  void Update()
  {

    
    if (check)
    {
      CheckCondition(); 
    }
    if (walking)
    {
        EnemyPos = transform.position; //隨時偵測敵人位置並放入參數中

        WalkMode();
    }

  }
  void CheckCondition(){


    if (SpikedIsCollide)
    {
        SpikedTrap();
    }
    if (blacktrap)
    {
        CheckTime();  
    }
    if(Traps02IsCollide)
    {
       Traps02() ;
    }

  }
  
  void WalkMode(){


             transform.Translate(speed * Time.deltaTime , 0, 0);

    	  
            if (EnemyPos.x > 101 && EnemyPos.y >= 10 && EnemyPos.y <= 20){

            gameObject.transform.position = new Vector3(-104, -18, 0);

            }
            if (EnemyPos.y >= -20 && EnemyPos.y <= -15 && EnemyPos.x > 69)
            {
              Destroy(gameObject);
              //SceneManager.LoadScene("gameOver"); //跳到結束畫面
            }
      
  }

  void SpikedTrap(){

    
      this.speed = 9f;
      Spikedelta += 1;
      // Debug.Log(delta);
      //緩速到一定時間後便正常
       deltaSum=800*spikecollide; //撞到幾個速度就加成多少
    if (Spikedelta >= deltaSum)
    {
      //Debug.Log("阿我恢復了!");
      SpikedIsCollide = false;

      this.speed = 10f;
      Spikedelta=0;
      spikecollide=0;

      
    }
  }

  void Traps02()
  //當遇到捕獸夾則被困住所以速度為0
  {

      this.speed = 0;
      Trapsdelta += 1;
      //Debug.Log($"撞到捕獸夾 {Trapsdelta}");
      // Debug.Log(delta);
      //緩速到一定時間後便正常
    if (Trapsdelta >= 500)
    //
    {
      //Debug.Log("阿我恢復了!");
      Traps02IsCollide = false;
      this.speed = 10f;
     
      Trapsdelta=0;
    }
  }
  
  void CheckTime(){

    check = false;
    // 停止偵測 碰觸何種陷阱狀態
    
    BlackTrap();

  }


  void StopBlood(){      

      Turnon = true;
      FriendlyHPControl.instance.StopBloodon();

       // CancelTime();
      InvokeRepeating("CancelTime", 0, 1);
       //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。


  }


  void CancelTime(){

    canceltime -= 1;

    if (canceltime < 1)
    {
      Turnon = false;
      FriendlyHPControl.instance.StopBloodoff();
      CancelInvoke("CancelTime");
      canceltime = 5;

    }
    // 顯示倒數幾秒
    Debug.Log($"停止攻擊效果倒數{canceltime}sec");

  }
  

  
  IEnumerator TurnbackTime()
  
  {

    yield return new WaitForSeconds(turnbacktime);
     speed = 10f;
     check = true;
    

  }



  void BlackTrap(){

      // Debug.Log("執行判斷");
          
          switch (stucktraptime)
          
          {
          
          case 1: 
            StopBlood();
            fearBar.instance.Increase();
            speed = -10f;
            WalkMode();
            StartCoroutine(TurnbackTime());
            blacktrap = false;

            break;

          case 2:
          
          
          Debug.Log("Case 2略過");
          check = true;
          stucktraptime = 0;
          blacktrap = false;
            break;
          
          default:

            break;

          }

  }

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      // Debug.Log("阿我撞到了QQ");
      SpikedIsCollide = true;
      //SpikedTrap();
      spikecollide += 1 ;    }
    if (col.tag == "DarkTrap")
    {

      

      blacktrap = true;

      stucktraptime += 1;
      // 確認是否第一次碰撞暗黑陷阱

      Debug.Log("碰撞黑暗第"+(stucktraptime)+"次");

      
  
    
    }

    if (col.tag=="Traps02")
    {
      //當撞到捕獸夾，則撞到變true呼叫函式traps02
      Traps02IsCollide=true;
      
    }
  }

}
