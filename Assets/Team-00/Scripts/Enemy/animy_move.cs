using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class animy_move : MonoBehaviour
{

// 碰撞黑暗陷阱流程圖
// https://upload.cc/i1/2021/06/25/edz4bn.jpg
  
  float speed; //怪物速度量值
  //更改組員設置參數數值
  //解釋：數值可先不定義方便再 unity 內調整 
  //且 start()函式中已宣吿數值;
  
  
  public bool walking;   //正常走路狀態

  // public bool IsCollide; 
  // 因陷阱碰撞判定有多樣 替換為特定參數： spiketrap 還請見諒

  
   [Header("狀態機IDE")] 
  public bool check;     //偵測敵人當下狀態
  public Vector3 EnemyPos; //偵測敵人當下位置
   [Header("尖刺陷阱")] 
  public bool spiketrap; //尖刺陷阱碰撞判定  
  int delta = 0;         //敵人緩速時間
   [Header("暗黑陷阱")] 
  public int stucktraptime; //單一陷阱碰撞次數
  public bool blacktrap;    //暗黑陷阱碰撞判定
  public int caseSwitch ; //暗黑陷阱觸發事件判定


  void Start()
  {
    check = true;
    walking = true;
    this.speed = 0.09f; 
    blacktrap = false;  
    stucktraptime = 0; 
  
  }
  void Update()
  {
    if (check)
    {
      CheckCondition(); //判斷敵人狀態
    }

  }
  void CheckCondition(){

    if (walking)
    {
        EnemyPos = transform.position; //隨時偵測敵人位置並放入參數中
        WalkMode();
    }
    if (spiketrap)
    {
        SpikedTrap();
    }
    if (blacktrap)
    {
        CheckTime();  
    }

  }
  void CheckTime(){

    check = false;
    // 停止偵測 enemy 狀態
    // 確認是否第一次碰撞暗黑陷阱

    if (stucktraptime > 1)
    {
      caseSwitch = 2;
      // 若是碰撞第二次，切換狀態2:略過陷阱

    }  
    //啟動陷阱無法扣血效果 改變我方扣血程式(friendlyhpcontrol.cs) 
    //啟動判斷依據的布林值(目前沒有加上)
    //StopBlood();
    // 還要計時，計時完後，要繼續能扣血 得再改變我方友軍布林值
    // 覺得有點小複雜 想法：可用魔力值也用過的 invoke 功能
    // 算了先註解掉 搞不好他們覺得沒那麼複雜給他們製作


    BlackTrap();
    //更動地方：統一函示命名規則

  }

  // void StopBlood(){

      
  //  //調用我方友軍布林值 stopblood 
  // friendlyhpcontrol.stopblood = true;
  // }

  // 計時功能
  // void noattacktime()
  // {
  // timeToAdd = 5;
  //   //update time on the UI
  //   //更新倒數顯示
  //   timeToAdd -= 1;

  //   if (timeToAdd <= 0)
  //   {
  //     friendlyhpcontrol.stopblood  = false;
  //     CancelInvoke("noattacktime");

  //   }
  //   // 顯示倒數幾秒
  //   Debug.Log($"{timeToAdd}sec");



  // }
  

  
  void WalkMode(){

          

            transform.Translate(this.speed*Time.deltaTime, 0, 0);
            // reference : https://www.jianshu.com/p/d2a83d49d027
            // https://rayfly0225.wordpress.com/2016/07/05/unity-time時間類1/
        
            // 根據每台電腦效能不同而設定之數據
            // 實現固定每秒移動 n 個單位長
    	  
            if (EnemyPos.x > 101 && EnemyPos.y >= 10 && EnemyPos.y <= 20){

            gameObject.EnemyPos = new Vector3(-104, -18, 0);

            }
            if (EnemyPos.y >= -20 && EnemyPos.y <= -15 && EnemyPos.x > 69)
            {
              Destroy(gameObject);
              //SceneManager.LoadScene("gameOver"); //跳到結束畫面
            }
            // 敵人樓層移動判定
            // 替換參數精簡程式
      
  }

  void SpikedTrap(){

    
      this.speed = 0.04f;
      delta += 1;
      // Debug.Log(delta);
      //緩速到一定時間後便正常
    if (delta >= 800)
    {
      //Debug.Log("阿我恢復了!");
      // IsCollide = false;
      //移除組員側置參數
      //commit by 01
      this.speed = 0.1f;
      // 速度與原先設定預設速度不同
    }

  }

  void BlackTrap(){

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
            // stopblood = true;
            Debug.Log($"預設後退且判別狀態改為 {check}");
            break;

          }

  }

  //當撞到尖刺陷阱時IsCollide==true
  //移除組員設置參數並將將事件拉出 update 外 
  //解釋原因與想法：
  //此參數不容易看出哪個陷阱啟動collide 且會一直都在偵測 改用狀態機流程去判斷 
  //遇到陷阱 >> 再去做觸發事件
  // commit by 01 
 

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      Debug.Log("撞到SpikedTrap");
      // IsCollide = true;
      SpikedTrap();
    }
    if (col.tag == "DarkTrap")
    {
      Debug.Log("撞到DarkTrap");

      blacktrap = true;

      stucktraptime += 1;

      Debug.Log(stucktraptime);

  
      // if (stucktraptime < 2  )
      // {
        // InvokeRepeating("noattacktime", 0, 1);
      //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。
      //     StopBlood();
      // }

      fearBar.instance.Increase();
    }
  }

}
