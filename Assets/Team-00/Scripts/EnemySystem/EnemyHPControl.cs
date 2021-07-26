using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHPControl : MonoBehaviour
{
  public static EnemyHPControl instance;
  // 函式 instance

  [Header("尖刺陷阱效果")] 
  public bool spikeIsCollide;
  float spikedelta = 0;
  float deltaSum=0; //delta要比deltaSum大 的值
  float spikecollide=0; //尖刺陷阱碰撞次數加成
  
  [Header("重新啟動扣血判斷")] 
  public bool circle;
  [Header("敵人血量設定")] 
  public int hp;     // 敵人當前血量
  public int max_hp ;  // 最大血量數值 max blood value
  [Header("每__秒扣一次")]
  public int costtime; // 每幾秒扣一次
  [Header("正常模式扣血量1")]
  public int cost1; //正常模式扣血量
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
    spikeIsCollide = false;
    back=true;
    max_hp = 100;
    hp = max_hp;   
    checkHP  = 1;            //最大血量設置數值，初始HP血量=最大血量
    costtime = 4 ;
    cost1 = 5;
    cost2 = 10;
    timer2bool = true;
    timer1bool = true;
    circle = true;
  }

  void Update()
  {   //如果目前血量HP小於等於0，那就會讓這個物件，也就是敵人消失
    if (hp <= 0)
    {
      Destroy(this.gameObject);
      
    }
   
    //如果HP沒有小於0目前的血條位置就會為 目前血量/最大血量
    float _percent = ((float)hp / (float)max_hp);
    EnemyAllHP.transform.localScale = new Vector3(_percent, EnemyAllHP.transform.localScale.y, EnemyAllHP.transform.localScale.z);

    //如果spikedeltaTime>=500，就停止扣血，如果還沒超過時間碰撞後持續扣血
    if (spikeIsCollide == true)
    {
      //每秒扣血
      // hp -= Time.deltaTime * 10f;

      CostBlood();
      
      // 更改地方還有 hp 的資料型態變為 int ; 
      // time.deltatime 通常是用在角色實體每秒速度~
      // 另外有寫每多少秒扣血的 funtion了 方便凱倫關卡設計參數還有完成我的進度

      spikedelta += 1;
      deltaSum=2*spikecollide;  //扣血加成
    }
    if (spikedelta >= deltaSum)
    {
     

      spikeIsCollide = false;
      spikedelta=0;
      spikecollide=0;
    }
    //Debug.Log(hp);
    
  
  }

  //碰撞後bool為真開始持續扣血
  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      spikeIsCollide = true;
      spikecollide += 1 ;
    }

    if (col.tag == "rockboom")
    {
      hp -= 1;
      // trap-02物件 要更換tag哦 
    }
    if (col.tag=="Traps02")
    {
      hp -= 10;  
    }

  

  }
void OnCollisionStay2D(Collision2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Friendly")
        { 
          if (circle)
          {  
            CheckCondition();
              
          } 

        
        
        }
        if(coll.gameObject.tag=="guard")
        {  
           
            
          CheckCondition();
            
        }
    }
    public void ChangBleeding(){
        checkHP = 2;
    }

    public void CheckCondition(){

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
      }
 
    
    
    }
    public void CostBlood(){

      if (timer1bool){
          StartCoroutine("timer1");  
      }

  
      



    }
    IEnumerator timer1(){
      
      yield return new WaitForSeconds(costtime);
      hp = hp - cost1;
       Debug.Log($"敵人正常狀態每{costtime}秒扣{cost1}滴血");     
       Debug.Log($"剩餘{hp}滴血"); 
      circle = true;
      //  timer1bool = false ; 停止計時 但暫時不用寫 因為必有一方消失 沒碰撞擊不會執行 checkcondition

    }
    IEnumerator timer2(){
      
      yield return new WaitForSeconds(costtime);
      hp = hp - cost2;
      Debug.Log($"敵人大規模下每{costtime}秒扣{cost2}滴血");     
      Debug.Log($"剩餘{hp}滴血");  
      circle = true;



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

