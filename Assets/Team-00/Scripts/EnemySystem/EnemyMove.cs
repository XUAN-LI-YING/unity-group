using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyMove : MonoBehaviour
{
   public static EnemyMove instance;
    [Header("撞到友軍")]
    public Animator playerAni;
    //呼叫打架動畫
    public bool IsAttacking;
    //如果撞到友軍且正在遭受攻擊
    
   [Header("有限狀態機FSM")] 
    public float speed = 0;    //怪物初始速度
    public bool walking;         //敵人移動狀態開關
    public bool check;           //判斷碰觸何種陷阱
    public Vector3 EnemyPos;     //偵測敵人當下位置
     
   [Header("暗黑停血開關")]
    public bool Turnon;         //暗黑陷阱效果開關
  
    [Header("暗黑陷阱-Trap03")] 
    public bool blacktrap;       //暗黑陷阱碰撞判定
    public int stucktraptime; //單一暗黑陷阱碰撞次數
    public int caseSwitch ;   //暗黑陷阱觸發事件判定


    [Header("暗黑秒數設置")]
    public float turnbacktime;  //暗黑陷阱效果敵人後退時間
    public float canceltime;    //暗黑陷阱效果關閉扣血時間


    [Header("大規模設置")]
    public float effecttime;  //大規模陷阱效果時間



   [Header("尖刺陷阱-Trap01")] 
    public bool SpikedIsCollide; //尖刺陷阱碰撞判定
    public int Spikedelta = 0;   //碰撞緩速計時器
    public float deltaSum = 0;   //減緩速度加乘參數(800倍x碰撞次數)
    public float spikecollide;   //尖刺陷阱碰撞次數
 

   
   [Header("捕獸陷阱-Trap02")] 
    public bool Traps02IsCollide;   //捕獸陷阱碰撞判定
    public int Trapsdelta = 0;      //捕獸陷阱緩速計時器
    
    // public int slowdowntime = 0; //緩速時間

    [Header("巨型滾筒-roller")]
    public float rollerdelta;
    public bool rollerCollide;
    // public Animator playerAni; //巨型滾筒呼叫動畫


  void Start()
  {
    instance = this;
    check = true;
    walking = true;
    SpikedIsCollide = false;
    Traps02IsCollide=false;
    this.speed = 10f; 
    blacktrap = false;
    stucktraptime = 0;
    turnbacktime = 1;
    canceltime = 5;
    spikecollide = 0;
     IsAttacking = false ;
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

        WalkMode();                    //敵人移動模式啟動
    }
    
    if(rollerCollide)                  //巨型滾筒
    {
      rollerTrap();
    }

    if(IsAttacking==true)     //如果受我方友軍攻擊則切換攻擊武裝動畫
        {
            if(playerAni.GetInteger("Status")==0)
              
                playerAni.SetInteger("Status",1);
                // Debug.Log("IsAttacking");
         
        }
        else
        {
            if(playerAni.GetInteger("Status")==1)
            {   
                playerAni.SetInteger("Status",0);
            }
        }
  }
  public void CheckCondition(){                //判別狀態


    if (SpikedIsCollide)                //尖刺陷阱碰撞
    {
        SpikedTrap();
    }
    if (blacktrap)                      //黑暗陷阱碰撞
    {
        CheckTime();  
    }
    if(Traps02IsCollide)                //捕獸夾陷阱碰撞 
    {
       Traps02() ;
    }

  }
  
  void WalkMode(){


             transform.Translate(speed * Time.deltaTime , 0, 0);          //固定一秒走固定距離

    	  
            if (EnemyPos.x > 100 && EnemyPos.y >= 0 && EnemyPos.y <= 28){    //移動至下層樓

            gameObject.transform.position = new Vector3(-99f, -15.3f, 0);

            }
            if (EnemyPos.y >= -20 && EnemyPos.y <= -5 && EnemyPos.x > 97)
            {
              
              Destroy(gameObject);
              
              //SceneManager.LoadScene("gameOver"); //跳到結束畫面
            }
      
  }

  void SpikedTrap(){
                                          //停止走路模式再執行該陷阱效果
                                          //commit by 01
    
      this.speed = 5f;
      Spikedelta += 1;
                                           
      deltaSum=800*spikecollide;           //撞到幾個速度就加成多少
    if (Spikedelta >= deltaSum)            //緩速到 一定時間 後便正常 
    {

      SpikedIsCollide = false;

      this.speed = 10f;                    // 重啟走路模式
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
                                                //停止走路模式再執行該陷阱效果
                                                //commit by 01

            this.speed = 0;                     //暈眩
            rollerdelta += 1;

            if (rollerdelta >= 200)             //暈眩到 一定時間 後便正常
            {
             
             this.speed = 10f;                   //恢復 walkmode
             rollerdelta=0;
             rollerCollide = false;
            }
  }
  
  public void CheckTime(){

    check = false;                         // 停止偵測 碰觸何種陷阱狀態
    
    BlackTrap();

  }


  public void StopBlood(){  



      Turnon = true;                                // 純粹寫介面方便偵錯

      InvokeRepeating("CancelTime", 0, 1);          // 停止攻擊效果秒數 turn on
      //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。 


  }


  void CancelTime(){

    canceltime -= 1;

    //  Debug.Log($"停止攻擊效果倒數{canceltime}sec");     // 顯示停止攻擊倒數幾秒

    if (canceltime < 1)                              // 停止扣血計時器
    {
      Turnon = false;
      // FriendlyHPControl.instance.StopBloodoff();  // 調用 友軍血量控制器 恢復正常扣友軍血量
      CancelInvoke("CancelTime");
      // EnemyHPControl.instance.SwitchCost();

      //
      canceltime = 10;                               // 重新啟動計時

    }



  }
  

  
  IEnumerator TurnbackTime()                        //往後走更好的寫法，關卡設計者容易調整數值
  
  {

    yield return new WaitForSeconds(turnbacktime);      //往後走秒數
     speed = 10f;
     check = true;                                      //恢復偵測狀態
    

  }



  public void BlackTrap(){
                                                    //判斷單一陷阱碰撞次數
          switch (stucktraptime)                   

          {
          
          case 1: 
            //FriendlyHPControl.instance.StopBloodon();  
            StopBlood();                            // 停止敵方扣友軍血量
            fearBar.instance.Increase();            // 增加恐懼值
            speed = -10f;                           // 反方向速度
            WalkMode();                             // 開始移動
            StartCoroutine(TurnbackTime());         // 孩子該回來了
            blacktrap = false;                      // 結束這一回合

            break;

          case 2:
          
          check = true;                             // 恢復預設持續偵測路上陷阱
          stucktraptime = 0;                        // 重置遇到黑暗陷阱次數
          blacktrap = false;                        // 結束這一回合

            break;
          
          default:                                  // 預設 數值無定義時啟動
                                                    // 一開始就有定義所以不用這行
            break;

          }

  }
  public void Checkbuff(){
    
    if (Turnon)
    {
      EnemyHPControl.instance.ChangBleeding();      //遇上大規模 敵方失血量轉變
                                                    //調用敵人HP控制器 script ;
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

      // Debug.Log("碰撞黑暗第"+(stucktraptime)+"次");

      

    
    }
    if (col.tag == "Trap-05")                   // 撞到大規模，檢查前面是否觸發黑暗
    {
        // Debug.Log("觸發大規模");
        Checkbuff();
        
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

    if (col.tag == "devil")
    {
       Destroy(this.gameObject);  
    }
  
  }

  void OnCollisionStay2D(Collision2D coll){

        if(coll.gameObject.tag=="Friendly")
        { 
          walking = false;
          IsAttacking = true ;
        }
        if(coll.gameObject.tag=="guard")
        { 
          walking = false;
          IsAttacking = true ;
        }
  }
  void OnCollisionExit2D(Collision2D coll)
    
    {
        if(coll.gameObject.tag=="Friendly")
        {
          walking = true;
           IsAttacking = false ;   
        }
        if(coll.gameObject.tag=="guard")
        {
          walking = true;
           IsAttacking = false ;   
        }
    }
}
