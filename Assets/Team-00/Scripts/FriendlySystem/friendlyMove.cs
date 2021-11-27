using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyMove : MonoBehaviour
{
    [Header("友軍速度")]

    public float speed = 0;
    //int times= 0;           //撞到次數

    public bool back;      //擊退判定
    
    void Start()
    {
      back=false;
      //怪物初始數度
      this.speed = -5f;  
    }
    void Update()
    {
        transform.Translate(speed * Time.deltaTime , 0, 0);

        //怪物速度

        //當物體超過畫面時(x=200)怪物移動到第一層的位置
        if(transform.position.x<-101 && transform.position.y <= -15 && transform.position.y > -20)    
        {
        
        gameObject.transform.position = new Vector3(90, 13, 0);

        }
        //物體在第一層超過畫面時則讓她消失
        if(transform.position.x<-100 && transform.position.y <= 20 && transform.position.y > 12)
        {
            // Destroy(gameObject);
        }
    }


    
    void OnTriggerEnter2D(Collider2D col)
    {
       
        //敵方碰撞到我方友軍被擊退一點
        // if (col.tag == "Cat")
        // {   
        //     if(back==true)
        //     {
            
        //     //偵測現在move到哪裡的位置
        //     Vector3 move = gameObject.transform.position;
        //     //move比現在的位置加5
        //     move = new Vector3(move.x + 10f, move.y, move.z);
        //    //現在的位置等於現在+5後的move
        //     gameObject.transform.position = move;
        //     }
            
        //     times+=1;          //紀錄第一次碰撞到友軍
        // }
    
        //  if(times>=1 && times<=5)  //每碰裝到友軍5次才會又擊退一次
        //  {   
        //          back=false;
        //  }

        //  else
        //  {
        //     times=0;
        //     back=true; 
        //  }
    }
}
