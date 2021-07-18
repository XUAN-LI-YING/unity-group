using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


 // 第二次更動：修正註解，並刪除 debug 
 // 若造成不便，還請多多寬待 i am sorry
 
 //更動組員程式碼命名方式以及其解釋理由
 // 若更改造成有 bug 產生，還請多多見諒 !!
 // 很想要更改的地方：(commit上也看得到差異哦)
 // 1. trap02 speed 速度太慢了我想更改
 // 2. 緩速時間參數設置為全域變數
 // 解釋其理由：容易在 unity 調整數值方便團隊開發

public class animy_move : MonoBehaviour
{
    
   [Header("有限狀態機FSM")] 
    public float speed = 0;    //怪物初始速度
    public bool walking;         //敵人移動狀態開關
    public bool check;           //判斷碰觸何種陷阱
    public Vector3 EnemyPos;     //偵測敵人當下位置

   [Header("尖刺陷阱")] 
    public bool SpikedIsCollide; //尖刺陷阱碰撞判定
    public int Spikedelta = 0;   //碰撞緩速計時器
    public float deltaSum = 0;   //減緩速度加乘參數(800倍x碰撞次數)
    public float spikecollide;   //尖刺陷阱碰撞次數
 
   [Header("暗黑陷阱")] 
    public bool blacktrap;       //暗黑陷阱碰撞判定
    public int stucktraptime; //單一暗黑陷阱碰撞次數
    public int caseSwitch ;   //暗黑陷阱觸發事件判定
   
   [Header("捕獸陷阱")] 
    public bool Traps02IsCollide;   //捕獸陷阱碰撞判定
    public int Trapsdelta = 0;      //捕獸陷阱緩速計時器
    
    // public int slowdowntime = 0; //緩速時間


    [Header("暗黑秒數設置")]
    public float turnbacktime;  //暗黑陷阱效果敵人後退時間
    public float canceltime;    //暗黑陷阱效果關閉扣血時間

    [Header("停血開關")]
    public bool Turnon;         //暗黑陷阱效果開關

    [Header("巨型滾筒")]
    public float rollerdelta;
    public bool rollerCollide;
    // public Animator playerAni; //巨型滾筒呼叫動畫
  void Start()
  {
    check = true;
    walking = true;
    SpikedIsCollide = false;
    Traps02IsCollide=false;
    this.speed = 10f; 
    blacktrap = false;
    stucktraptime = 0;
    turnbacktime = 3;
    canceltime = 5;
    spikecollide = 0;
  }
  void Update()
  {
  
    
    if (check)
    {
      CheckCondition();                //判斷碰觸何種陷阱
    }
    if (walking)
    {
        EnemyPos = transform.position; //隨時偵測敵人位置並放入參數中

        WalkMode();
    }
    
    if(rollerCollide)
    {
      rollerTrap();
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

    
      this.speed = 5f;
      Spikedelta += 1;
                                           
      deltaSum=800*spikecollide;           //撞到幾個速度就加成多少
    if (Spikedelta >= deltaSum)            //緩速到一定時間後便正常 
    {

      SpikedIsCollide = false;

      this.speed = 10f;
      Spikedelta=0;
      spikecollide=0;

      
    }
  }

  void Traps02(){

      this.speed = 0;                     //當遇到捕獸夾則被困住所以速度為0
      Trapsdelta += 1;

    if (Trapsdelta >= 500)                //緩速到一定時間後便正常
    {

      Traps02IsCollide = false;
      this.speed = 10f;
     
      Trapsdelta=0;
    }
  }

  void rollerTrap(){
            this.speed = 0;                     //暈眩
            rollerdelta += 1;

            if (rollerdelta >= 200)                //暈眩到一定時間後便正常
            {
             
             this.speed = 10f;
             rollerdelta=0;
             rollerCollide = false;
            }
  }
  
  void CheckTime(){

    check = false;                         // 停止偵測 碰觸何種陷阱狀態
    
    BlackTrap();

  }


  void StopBlood(){      

      Turnon = true;
      FriendlyHPControl.instance.StopBloodon();

      InvokeRepeating("CancelTime", 0, 1);
      //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。


  }


  void CancelTime(){

    canceltime -= 1;

    if (canceltime < 1)                             //停止扣血計時器
    {
      Turnon = false;
      FriendlyHPControl.instance.StopBloodoff();
      CancelInvoke("CancelTime");
      canceltime = 5;

    }

    Debug.Log($"停止攻擊效果倒數{canceltime}sec");     //顯示停止攻擊倒數幾秒

  }
  

  
  IEnumerator TurnbackTime()                        //往後走更好的寫法，關卡設計者容易調整數值
  
  {

    yield return new WaitForSeconds(turnbacktime);
     speed = 10f;
     check = true;
    

  }



  void BlackTrap(){
                                                    //判斷單一陷阱碰撞次數
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
      SpikedIsCollide = true;
      spikecollide += 1 ;    
    
    }

    if (col.tag == "DarkTrap")
    {
      blacktrap = true;

      stucktraptime += 1;                       //確認是否第一次碰撞暗黑陷阱

      Debug.Log("碰撞黑暗第"+(stucktraptime)+"次");
    
    }

    if (col.tag=="Traps02")
    {
      Traps02IsCollide=true;                    //當撞到捕獸夾，則撞到變true呼叫函式traps02
      
    }
    if (col.gameObject.tag=="roller")
    {
      rollerCollide =true;                       //當撞到巨型滾筒，則呼叫rollerTrap函式
      //偵測現在move到哪裡的位置
      Vector3 move = gameObject.transform.position;
      //move比現在的位置-5
      move = new Vector3(move.x-5f, move.y, move.z);
      //現在的位置等於現在-5後的move
      gameObject.transform.position = move;
      
    }
  
  }
}
