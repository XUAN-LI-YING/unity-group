using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animy_move : MonoBehaviour
{

  int delta = 0;
  int times = 0;    //撞到次數
  float speed = 0;

  public bool IsCollide; //尖刺陷阱判定
  public bool back;      //擊退判定
  void Start()
  {
    IsCollide = false;
    back = false;
    //怪物初始數度
    this.speed = 0.08f;
  }
  void Update()
  {
    //怪物速度
    transform.Translate(this.speed, 0, 0);

    //當物體超過畫面時(x=200)怪物移動到的二層的位置
    if (transform.position.x > 200 && transform.position.y >= 30 && transform.position.y <= 40)
    {

      gameObject.transform.position = new Vector3(-200, -43, 0);

    }
    //物體在第二層超過畫面時則讓她消失
    if (transform.position.y >= -43 && transform.position.y <= -20 && transform.position.x > 200)
    {
      Destroy(gameObject);
    }

    //IsCollide==true也就是遇到尖刺陷阱時，持續緩速
    if (IsCollide == true)
    {
      // Debug.Log(this.speed);
      this.speed = 0.05f;
      delta += 1;
    }
    //緩速到一定時間後便正常
    if (delta >= 2000)
    {
      //Debug.Log("阿我恢復了!");
      IsCollide = false;
      this.speed = 0.08f;
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



    //敵方碰撞到我方友軍被擊退一點
    if (col.tag == "Friendly")
    {
      if (back == true)
      {
        Debug.Log(back);
        Vector3 move = gameObject.transform.position;
        //move比現在的位置扣5
        move = new Vector3(move.x - 10f, move.y, move.z);
        //現在的位置等於現在-5後的move
        gameObject.transform.position = move;
      }

      times += 1;          //紀錄第一次碰撞到友軍
    }

    if (times >= 1 && times <= 5)  //每碰撞到友軍5次才會又擊退一次
    {
      Debug.Log(times);
      back = false;
    }

    else
    {
      times = 0; //這邊可能要修改只要碰撞到object time就會歸0
      //參考解法：
      // update 隨時偵測 time 若大於5 back = true  碰到friendly & back=true時 time 重置= 0,否則time+-1; 
      // commit by 01
      Debug.Log($"{times}秒//擊退友軍");
      back = true;
    }
  }

}
