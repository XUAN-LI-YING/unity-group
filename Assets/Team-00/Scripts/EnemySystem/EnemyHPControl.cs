﻿using System;
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
  [Header("扣血量模式 check 1 OR 2")]
  public int checkHP; // 扣血量狀態判斷 check how many blood cost persecond
  public bool timer1bool; //啟動秒數開關
  public bool timer2bool; //啟動秒數開關
  public bool changmode; //切換模式 2大規模 切到 1普通扣血
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
    costtime = 1 ;
    costtime1 = 1;
    cost1 = 2;
    cost2 = 10;
    timer2bool = false;
    timer1bool = true;
    circle = true;
    changmode = false;
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
    {   //如果碰撞到cat     10.03 齡移 commit : 應該要寫成碰到當下反應事件 stay 會一直觸發而無法計時將扣血機制給量化 所以就寫在下面啦

        // 這邊留給判斷何時作切換

        if(coll.gameObject.tag=="Friendly")
        { 
   


        
        
        }
        if(coll.gameObject.tag=="guard")
        {  
           

            
        }
    }



  

  void OnCollisionEnter2D(Collision2D coll){

        if(coll.gameObject.tag=="Friendly")
        { 

             CheckCondition();               
            //檢查敵人扣血狀態 至於哪個扣血模式才會真的執行取決於 checkHP 的狀態呦～～ 
            
            //1 的時候代表遇敵人普通扣血， 2代表遇到大規模且遇敵人那瞬間，checkHP的狀態取決於 敵人有沒有碰到大規模 and 大規模效果要多久喔

            // 大規模效果要多久又是根據 EnemyMove 腳本 StopBlood() 函式中 turnon 的開關狀態～  開關狀態又是根據 canceltime 扣血時間(10秒)控制的

            // 至於何時取消扣血，兩種狀況 一: 敵人沒血了，二種模式都要取消 上面映璇有寫了 hp <0 destory 

            // 二 : 敵人有血但大規模效果失效了，切換普通扣血

            // 思考點：何時失效。 turnon 關掉的時候，
            
        }

  }
  public void ChangBleeding(){          // enenmymove.cs checkbuff()調用的函式 
        
        checkHP = 2;
        

    }
  public void SwitchCost(){
        changmode = true;
        CancelInvoke("timer2");
        checkHP = 1 ;
        CheckCondition();// 不管有無碰到，往後都是普通扣血，除非再次觸發


    }


    void CheckCondition(){

                                         // case1 一般扣血  case2 因碰撞到大規模扣較多血
      switch (checkHP)                   


          {
          
          case 1: 

          timer1bool = true;

          timer2bool = false;

          CostBlood();
          


          

            break;

          case 2:
          
          timer1bool = false;

          timer2bool = true;

          CostmoreBlood();
          
          



            break;
          
          default:

            break;

          }


      
    
    
    }
   void CostmoreBlood(){

      Debug.Log("翻開大規模術士效果！");

    InvokeRepeating("timer2",0f,costtime);
 
    
    
    }
   void CostBlood(){

      
    Debug.Log($"正常狀態下扣血");

    InvokeRepeating("timer1",0f,costtime);


    }
       
    void CostBloodBonus(){

      hp = hp - cost1;
       Debug.Log($"敵人加乘狀態每{costtime1}秒扣{cost1}滴血");     
       Debug.Log($"剩餘{hp}滴血"); 


    }

    void timer1(){

      hp = hp - cost1;

       Debug.Log($"普通模式：每{costtime}秒扣{cost1}滴血，敵人剩餘{hp}滴血"); 
          
    }

    
    void timer2(){
      
      hp = hp - cost2;  
      Debug.Log($"術式模式：每{costtime}秒扣{cost2}滴血，敵人剩餘{hp}滴血");  
      
       

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

