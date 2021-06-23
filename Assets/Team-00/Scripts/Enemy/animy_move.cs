using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class animy_move : MonoBehaviour
{

  int delta = 0;
 // int times = 0;    //撞到次數
  float speed = 0;
 
  public bool IsCollide; //尖刺陷阱判定
  public bool back;      //擊退判定
  public int caseSwitch = 1;
  void Start()
  {
    IsCollide = false;
    back = false;
    //怪物初始數度
    this.speed = 0.09f;
  }
  void Update()
  {
    //怪物速度
    transform.Translate(this.speed, 0, 0);

    //當物體超過畫面時(x>101,y>=10)怪物移動到的二層的位置

    // 不能直接放 update 

    // 需判定狀態再來 call back funtion 呼叫函式

    // 思緒：有何狀態

    // 正常行走、遇到特定物件、無法攻擊狀態

    // 先拿一張紙寫流程圖 先不管程式會不會寫

    // 避免敵人一直困在同一陷阱 紀錄單一碰撞次數

    CheckCondition();

    // SpikeTrap();

  }
  void CheckCondition(){
    	
      

  
          switch (caseSwitch)
          {
          case 1:
            Debug.Log("Case 1");
            if (transform.position.x > 101 && transform.position.y >= 10 && transform.position.y <= 20){

            gameObject.transform.position = new Vector3(-104, -18, 0);

            }
            //物體在第二層超過畫面時則讓她消失
            if (transform.position.y >= -20 && transform.position.y <= -15 && transform.position.x > 69)
            {
              Destroy(gameObject);
              //SceneManager.LoadScene("gameOver"); //跳到結束畫面
            }
            break;

          case 2:
            Debug.Log("Case 2");

            break;
          
          default:
          
            Debug.Log("Default case");
            break;
          
          
          
          
          }




    




  }
  void SpikedTrap(){

    

    //IsCollide==true也就是遇到尖刺陷阱時，持續緩速
    if (IsCollide == true)
    {
      this.speed = 0.04f;
      delta += 1;
      // Debug.Log(delta);

    }
    //緩速到一定時間後便正常
    if (delta >= 800)
    {
      //Debug.Log("阿我恢復了!");
      IsCollide = false;
      this.speed = 0.1f;
      // 速度與原先設定預設速度不同
    }





  }
  //當撞到尖刺陷阱時IsCollide==true

  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      //Debug.Log("阿我撞到了QQ");
      IsCollide = true;
    }
    if (col.tag == "DarkTrap")
    {
      //Debug.Log("meet darktrap");
      
      // animy move 敵方移動需重構邏輯判斷[待調整]
      fearBar.instance.Increase();
    }
  }


}
