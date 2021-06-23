using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class animy_move : MonoBehaviour
{

  int delta = 0;
 // int times = 0;    //撞到次數
  float speed = 0;
  
// public bool back;      //擊退判定
//沒用到參數 先註解
  
  public bool walking;   //正常走路狀態
  public bool IsCollide; //尖刺陷阱碰撞判定
  public bool blacktrap = true; //暗黑陷阱碰撞判定
  public bool spiketrap;
  public int stucktraptime;
  
  

  public int caseSwitch = 2; //暗黑陷阱觸發事件判定


  void Start()
  {
    walking = true;
    IsCollide = false;
    // blacktrap = 第一次是 ture 後退離開後是 false 遇到下一個 trap 才變 true;
    // back = false; 後續被刪除沒用上
    this.speed = 0.09f; //怪物初始速度
  }
  void Update()
  {
    //怪物速度
    transform.Translate(this.speed, 0, 0);

    //當物體超過畫面時(x>101,y>=10)怪物移動到的二層的位置

    // 不能直接放 update 

    // 需判定狀態再來 call back function 呼叫函式

    // 思緒：有何狀態

    // 正常行走、遇到特定物件、無法攻擊狀態

    // 先拿一張紙寫流程圖 先不管程式會不會寫

    // 避免敵人一直困在同一陷阱 紀錄單一碰撞次數

    CheckCondition();

    // SpikeTrap();

  }
  void CheckCondition(){

    if (walking)
    {

        WalkMode();
    }
    if (spiketrap)
    {

        SpikedTrap();
    }
    if (blacktrap)
    {
        walking = false;

        CheckTime();

    
   
        
    }




  }
  void CheckTime(){

    
    //確認是否第一次碰撞暗黑陷阱
    // 再想想怎做

      Blacktrap();


  }
  
  
  void WalkMode(){
    	  
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

    
      this.speed = 0.04f;
      delta += 1;
      // Debug.Log(delta);
      //緩速到一定時間後便正常
    if (delta >= 800)
    {
      //Debug.Log("阿我恢復了!");
      IsCollide = false;
      this.speed = 0.1f;
      // 速度與原先設定預設速度不同
    }





  }

  void Blacktrap(){

      Debug.Log("執行判斷");
          
          switch (caseSwitch)
          {
          case 1: 
            Debug.Log("Case 1後退");
          
            break;

          case 2:
          
            Debug.Log("Case 2略過");

            break;
          
          default:
          
            Debug.Log("預設後退");
            break;
          
          
          
          
          }





  }
  //當撞到尖刺陷阱時IsCollide==true

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      //Debug.Log("阿我撞到了QQ");
      IsCollide = true;
      SpikedTrap();
    }
    if (col.tag == "DarkTrap")
    {
      blacktrap = true;
      stucktraptime += 1;
      //time+1
      // animy move 敵方移動需重構邏輯判斷[待調整]
      fearBar.instance.Increase();
    }
  }


}
