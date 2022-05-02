using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EnemyHPControl : MonoBehaviour
{
  public static EnemyHPControl instance;
  // 函式 instance

  [Header("大規模扣血UI")]
  public Text costblood_ui;

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
    max_hp = 120;
    hp = max_hp;                    //最大血量設置數值，初始HP血量=最大血量
    checkHP  = 1;            
    costtime = 0 ;
    costtime1 = 1;
    cost1 = 6;
    cost2 = 20;
    timer2bool = false;
    timer1bool = true;
    circle = true;
    changmode = false;
    
  }

  void Update()
  {                                                             //如果目前血量HP小於等於0，那就會讓這個物件，也就是敵人消失
    if (hp <= 0)
    {
      EnemyPrefab.Instance.addEnemyDie();
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
      
    }
    if (col.tag=="Traps02")
    {
      hp -= 20;  
    }    
    if (col.tag=="Trap-05")
    {
      hp -= 20;  
    }


  

  }
  void AutoAddBonus(){
    bonustime += 1.5f ; 
    cost1 = 5 + bonustime;
      
         
    
    if (bonustime > 6 )   //     6 / 1.5  =  4 秒加乘時間
    {
      Debug.Log($"結束{(bonustime/1.5)-1}秒加乘時間"); 
      CancelInvoke("AutoAddBonus");
      CancelInvoke("CostBloodBonus"); //取消加乘效果
      Debug.Log("取消加乘效果"); 
      cost1 = 5;
        
    }

  }

  //這裡有問題
 



  

  void OnCollisionEnter2D(Collision2D coll){

        if(coll.gameObject.tag=="Friendly")
        { 

            Debug.Log("meet my friendly");
             CheckCondition();               
            
        }
        if(coll.gameObject.tag=="Trap-05")
        { 

                hp = hp - cost1;        
            
        }

        if(coll.gameObject.tag=="guard")
        {  
          InvokeRepeating("guardBoold", 0f, 2);

        }

  }  

 void OnCollisionExit2D(Collision2D coll)
    {
        

    }


  public void ChangBleeding(){          // enenmymove.cs checkbuff()調用的函式 
        
        checkHP = 2;
        

    }
  public void SwitchCost(){


    }


    void CheckCondition(){

                                         // case1 一般扣血  case2 因碰撞到大規模扣較多血
      switch (checkHP)                   


          {
          
          case 1: 

          timer1bool = true;

          timer2bool = false;

           Debug.Log($"一般來說"); 

          CostBlood();
          


          

            break;

          case 2:
          
          timer1bool = false;

          timer2bool = true;

           Debug.Log($"特殊來說"); 

          CostmoreBlood();
          
          



            break;
          
          default:

            break;

          }


      
    
    
    }
   void CostmoreBlood(){

    costblood_ui.text = "翻開大規模術士效果！";
    
    Debug.Log("翻開大規模術士效果！");

    InvokeRepeating("timer2",0f,1);
 
    
    
    }
   void CostBlood(){

      
    Debug.Log($"正常狀態下扣血");

    InvokeRepeating("timer1",0f,1);


    }
       
    void CostBloodBonus(){

      hp = hp - cost1;

      costblood_ui.text = "敵人狀態每" + costtime1 + "秒扣" + cost1 + "滴血";
       Debug.Log($"敵人加乘狀態每{costtime1}秒扣{cost1}滴血");     
       Debug.Log($"剩餘{hp}滴血"); 


    }
  

    void timer1(){

      hp = hp - cost1;

       Debug.Log($"普通模式：每{costtime}秒扣{cost1}滴血，敵人剩餘{hp}滴血"); 
          
    }

    
    void timer2(){

      costtime += 1 ;

      if (costtime>5)
      {
          SwitchCost();
      }
      
      hp = hp - cost2; 

      costblood_ui.text = "每1秒扣"+cost2+"滴血"+"敵人剩餘"+hp+"滴血，效果持續"+costtime+"秒";

      // Debug.Log($"術式模式：1秒扣{cost2}滴血，敵人剩餘{hp}滴血，效果持續{costtime}秒");  
      

       

    }
    // 大規模要5秒

    void guardBoold()
    {
        hp = hp-2;
    }


}

