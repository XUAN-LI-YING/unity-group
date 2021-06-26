using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class animy_move : MonoBehaviour
{

  int Spikedelta = 0;
  int Trapsdelta=0;
 // int times = 0;    //撞到次數
 float deltaSum=0; //delta要比deltaSum大 的值
  float speed = 0;
  float spikecollide=0; //尖刺陷阱碰撞次數加成
  
// public bool back;      //擊退判定
//沒用到參數 先註解
  
  public bool walking;   //正常走路狀態
  public bool SpikedIsCollide; //尖刺陷阱碰撞判定

  public bool Traps02IsCollide;//捕獸夾碰撞判定
  public bool blacktrap; //暗黑陷阱碰撞判定
  // public bool spiketrap; 
  public bool check;
  public int stucktraptime;
  
  

  public int caseSwitch ; //暗黑陷阱觸發事件判定


  void Start()
  {
    check = true;
    walking = true;
    SpikedIsCollide = false;
    Traps02IsCollide=false;
    // blacktrap = 預設 false  第一次碰撞是 true 後退離開後是 false 遇到下一個 trap 才變 true;
    // back = false; 後續被刪除沒用上
    this.speed = 0.1f; //怪物初始速度
    blacktrap = false;
    stucktraptime = 0;
  }
  void Update()
  {
    //怪物速度
    

    //當物體超過畫面時(x>101,y>=10)怪物移動到的二層的位置

    // 不能直接放 update 

    // 需判定狀態再來 call back function 呼叫函式

    // 思緒：有何狀態

    // 正常行走、遇到特定物件、無法攻擊狀態

    // 先拿一張紙寫流程圖 先不管程式會不會寫

    // 避免敵人一直困在同一陷阱 紀錄單一碰撞次數

    if (check)
    {
      CheckCondition();
    }


    // SpikeTrap();

  }
  void CheckCondition(){

    if (walking)
    {

        WalkMode();
    }
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
  void CheckTime(){

    check = false;
    // 停止判別狀態

    //確認是否第一次碰撞暗黑陷阱

    if (stucktraptime > 1)
    {
      caseSwitch = 2;

    }  
    
    Blacktrap();



  }
  
  
  void WalkMode(){

            transform.Translate(this.speed, 0, 0);
    	  
            if (transform.position.x > 101 && transform.position.y >= 10 && transform.position.y <= 20){

            gameObject.transform.position = new Vector3(-104, -18, 0);

            }
            //物體在第二層超過畫面時則讓她消失
            if (transform.position.y >= -20 && transform.position.y <= -15 && transform.position.x > 69)
            {
              Destroy(gameObject);
              //SceneManager.LoadScene("gameOver"); //跳到結束畫面
            }
      

  

  }

  void SpikedTrap(){

    
      this.speed = 0.05f;
      Spikedelta += 1;
      // Debug.Log(delta);
      //緩速到一定時間後便正常
       deltaSum=800*spikecollide; //撞到幾個速度就加成多少
    if (Spikedelta >= deltaSum)
    {
      //Debug.Log("阿我恢復了!");
      SpikedIsCollide = false;
      this.speed = 0.1f;
      Spikedelta=0;
      spikecollide=0;
      // 速度與原先設定預設速度不同
      
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
    {
      //Debug.Log("阿我恢復了!");
      Traps02IsCollide = false;
      this.speed = 0.1f;
      Trapsdelta=0;
      // 速度與原先設定預設速度不同
    }
  }

  void Blacktrap(){

      // Debug.Log("執行判斷");
          
          switch (caseSwitch)
          {
          case 1: 

          
            break;

          case 2:

          
            // Debug.Log("Case 2略過");
            check = true;


            break;
          
          default:

            Vector3 move = gameObject.transform.position;
            //move比現在的位置-5
            move = new Vector3(move.x-20f, move.y, move.z);
            //現在的位置等於現在-5後的move
            gameObject.transform.position = move;
            Debug.Log("預設後退");
          
            blacktrap = false;
            check = true;
            Debug.Log($"預設後退且判別狀態改為 {check}");
            break;

          
          
          
          
          }





  }
  //當撞到尖刺陷阱時IsCollide==true

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      // Debug.Log("阿我撞到了QQ");
      SpikedIsCollide = true;
      //SpikedTrap();
      spikecollide += 1 ;
    }
    if (col.tag == "DarkTrap")
    {

      blacktrap = true;

      stucktraptime += 1;

      Debug.Log(stucktraptime);

      fearBar.instance.Increase();
    }

    if (col.tag=="Traps02")
    {
      //當撞到捕獸夾，則撞到變true呼叫函式traps02
      Traps02IsCollide=true;
      
    }
  }


}
