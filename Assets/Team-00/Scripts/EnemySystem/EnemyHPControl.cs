using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 更動組員程式碼命名方式以及其解釋理由
// 若更改造成有 bug 產生，還請多多見諒 !!
// 更改地方：(commit上也看得到差異哦賴訊息會再報備一次)
// 將 max_hp = 100;
public class EnemyHPControl : MonoBehaviour
{
  public static EnemyHPControl instance;
  // 函式 instance

  [Header("尖刺陷阱效果")] 
  public bool spikeIsCollide;
  float spikedelta = 0;
  float deltaSum=0; //delta要比deltaSum大 的值
  float spikecollide=0; //尖刺陷阱碰撞次數加成
  
  [Header("血量控制")]
  public int checkHP; // 扣血量狀態判斷 check how many blood cost persecond
  
  public bool timer1bool; 
  public bool timer2bool;
  public int hp;     // 敵人當前血量
  public int max_hp ;  // 最大血量數值 max blood value
  public int costtime; // 每幾秒扣一次

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
    checkHP = 1;             //最大血量設置數值，初始HP血量=最大血量
    costtime = 1;
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

    // 如果敵人撞到友軍則扣血
    // if (col.tag == "Friendly")
    // {   //hp-0.1
    //   hp -= 1f;
    // }

  }
void OnCollisionStay2D(Collision2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Friendly")
        {  

          CheckCondition();
          // 這邊預計會重寫判斷 才可能達到功能
          // 寫個 switch 隨時判斷狀態 切換扣多少血量狀態
          // default : 普通扣血 CostBlood();
          
          // 1.遇到大規模 : 扣多
          // 2.遇到巴拉巴拉：扣___看企劃怎寫
          // 3.以次類推續加

          // 本來寫在這的  hp -= 0.5f;
          // 用呼叫函式方式 costblood之類的();
          // 因為 enemymove.cs  要調用這邊完成 啟動 and 關閉扣血 "我方扣敵方更多血量"

          // 不好意思擅自更動啦~~~
          // commit by 01 賴上面也會有截圖哦

          // 方便企劃測試 血量扣的速率寫在介面上
          // 大概會變 hp - "一秒扣多少數值"
          // 目前是只要 collisionstay 就會扣沒有秒數在裡頭
          // 想法： 用 StartCoroutine 協程去寫
          
        
        }
        if(coll.gameObject.tag=="guard")
        {   //hp-0.1
            
          CheckCondition();
            
        }
    }
    public void CheckCondition(){

      switch (checkHP)                   

          {
          
          case 1: 
          CostBlood();

            break;

          case 2:
          
          CostmoreBlood();

            break;
          
          default:

          CostBlood();

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
      hp = hp - 3;
       Debug.Log($"敵人每{costtime}秒扣3滴血");     
       Debug.Log($"剩餘{hp}滴血"); 
       timer1bool = false ;

    }
    IEnumerator timer2(){
      
      yield return new WaitForSeconds(costtime);
      hp = hp - 10;
      Debug.Log($"敵人每{costtime}秒扣10滴血");     
      Debug.Log($"剩餘{hp}滴血");     


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

