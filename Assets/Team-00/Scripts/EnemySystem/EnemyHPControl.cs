using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHPControl : MonoBehaviour
{
  public static EnemyHPControl instance;
  // 函式 instance

  [Header("尖刺陷阱效果")] 
  // public bool spikeIsCollide;
  // float spikedelta = 0;
  // float deltaSum=0;  //delta要比deltaSum大 的值
  float bonustime = 0; //尖刺陷阱碰撞次數加成  可客製化秒數及加成倍數
  
  [Header("重新啟動扣血判斷")] 
  public bool circle;
  [Header("敵人血量設定")] 
  public float hp;     // 敵人當前血量
  public int max_hp ;  // 最大血量數值 max blood value
  
  [Header("每__秒扣一次(加乘效果)")]
  public int costtime1;
  [Header("每__秒扣一次(正常模式與大規模)")]
  public int costtime; // 每幾秒扣一次
  [Header("正常模式扣血量1")]
  public float cost1; //正常模式扣血量
  [Header("大規模扣血量2")]
  public int cost2; //大規模模式扣血量
  [Header("扣血量切換模式1and2")]
  public int checkHP; // 扣血量狀態判斷 check how many blood cost persecond
  public bool timer1bool; //啟動秒數開關
  public bool timer2bool; //啟動秒數開關
  [Header("血量圖像")] 
  public GameObject EnemyAllHP;  

  [Header("擊退效果")] 
  public bool back;   //擊退狀態
  public int times=0; //擊退次數



  void Start()
  { 
    instance = this;
    
    back=true;
    max_hp = 200;
    hp = max_hp;                    //最大血量設置數值，初始HP血量=最大血量
    checkHP  = 1;            
    costtime = 4 ;
    costtime1 = 1;
    cost1 = 5;
    cost2 = 10;
    timer2bool = true;
    timer1bool = true;
    circle = true;
  }

  void Update()
  {                                                             //如果目前血量HP小於等於0，那就會讓這個物件，也就是敵人消失
    if (hp <= 0)
    {
      Destroy(this.gameObject);
      
    }
   
                                                                //如果HP沒有小於0目前的血條位置就會為 目前血量/最大血量
    float _percent = ((float)hp / (float)max_hp);
    EnemyAllHP.transform.localScale = new Vector3(_percent, EnemyAllHP.transform.localScale.y, EnemyAllHP.transform.localScale.z);

                                                                //如果 spikedeltaTime >= 500，就停止扣血，如果還沒超過 時間 撞後持續扣血

    
  
  }

  //碰撞後bool為真開始持續扣血
  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      // spikeIsCollide = true;
      InvokeRepeating("AutoAddBonus", 0, 1);  
      InvokeRepeating("CostBloodBonus",0,costtime1);   //扣血加成優化
      
      
    }

    if (col.tag == "rockboom")
    {
      hp -= 100;
      
      // trap-02物件 要更換tag哦 
    }
    if (col.tag=="Traps02")
    {
      hp -= 10;  
    }

  

  }
  void AutoAddBonus(){
    bonustime += 1.5f ; 
    cost1 = 5 + bonustime;
      
         
    
    if (bonustime > 6 )   //     6 / 1.5  =  4 秒加乘時間
    {
      Debug.Log($"結束{(bonustime/1.5)-1}秒加乘時間"); 
      CancelInvoke("AutoAddBonus");
      cost1 = 5;
        
    }

  }
  void OnCollisionStay2D(Collision2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Friendly")
        { 
          if (circle)                       //重複計時啟動開關 
          {  
            CheckCondition();               //檢查敵人扣血狀態
              
          } 

        
        
        }
        if(coll.gameObject.tag=="guard")
        {  
           
            
          CheckCondition();
            
        }
    }
    public void ChangBleeding(){          // enenmymove.cs checkbuff()調用的函式 
        checkHP = 2;
    }

    public void CheckCondition(){

                                         // case1 一般扣血  case2 因碰撞到大規模扣較多血
      switch (checkHP)                   


          {
          
          case 1: 

          circle = false; 
          
          CostBlood();

            break;

          case 2:
          
          circle = false;

          CostmoreBlood();

            break;
          
          default:

          // CostBlood();

            break;

          }
      
    
    
    }
    public void CostmoreBlood(){

      if (timer2bool){
          StartCoroutine("timer2");
          circle = true;
      }
 
    
    
    }
    public void CostBlood(){

      if (timer1bool){
          StartCoroutine("timer1");  
          circle = true;
      }
 

    }
       
    public void CostBloodBonus(){

      hp = hp - cost1;
       Debug.Log($"敵人加乘狀態每{costtime1}秒扣{cost1}滴血");     
       Debug.Log($"剩餘{hp}滴血"); 


    }

    IEnumerator timer1(){
      
      yield return new WaitForSeconds(costtime);
      hp = hp - cost1;
       Debug.Log($"敵人正常狀態每{costtime}秒扣{cost1}滴血");     
       Debug.Log($"剩餘{hp}滴血"); 
      
      //  timer1bool = false ; 停止計時 但暫時沒用上 因為必有一方消失 (組員已經寫成 onstay 的狀態) 所以一旦沒碰撞即自動停止執行 checkcondition

    }
    IEnumerator timer2(){
      
      yield return new WaitForSeconds(costtime);
      hp = hp - cost2;
      Debug.Log($"敵人大規模下每{costtime}秒扣{cost2}滴血");     
      Debug.Log($"剩餘{hp}滴血");  
      
      //  timer2bool = false ; 停止計時 但暫時沒用上 因為必有一方消失 (組員已經寫成 onstay 的狀態)  所以一旦沒碰撞即自動停止執行 checkcondition


    }



// void OnCollisionEnter2D(Collision2D coll) 
// {
//   if(coll.gameObject.tag=="Friendly")
//   {     if( times>=2)
//             {
//               back=true;     //當遇到我方友軍則會擊退並計算擊退次數
//               times=0;
//             }

//             else
//             {
//               times += 1 ;
//             }
//             if(back==true)
//             {
//             //偵測現在move到哪裡的位置
//             Vector3 move = gameObject.transform.position;
//             //move比現在的位置-5
//             move = new Vector3(move.x-20f, move.y, move.z);
//             //現在的位置等於現在-5後的move
//             gameObject.transform.position = move;
//             back=false;
//             }
//   }
  
// }



}

