using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyMove : MonoBehaviour
{
    [Header("友軍速度")]
    public bool walking;
    public float speed = 0;
    //int times= 0;           //撞到次數
    // public bool back;      //擊退判定
    public Vector3 EnemyPos;

    [Header("撞到敵軍")]
    public Animator playerAni;
    //呼叫打架動畫
    public bool IsAttacking;
    //如果撞到敵軍且正在遭受攻擊
    
    void Start()
    {
      //back=false;
      //怪物初始數度
      this.speed = -5f;  
      IsAttacking = false ;
      walking = true;
    }
    void Update()
    {
        if (walking)
        {
        EnemyPos = transform.position; //隨時偵測敵人位置並放入參數中

        WalkMode();                    //敵人移動模式啟動
        }

        if(IsAttacking==true)     //如果受我方友軍攻擊則切換攻擊武裝動畫
        {
            if(playerAni.GetInteger("Status")==0)
              
                playerAni.SetInteger("Status",1);
                // Debug.Log("IsAttacking");
         
        }
        else
        {
            if(playerAni.GetInteger("Status")==1)
            {   
                playerAni.SetInteger("Status",0);
            }
        }
        
    }
    void WalkMode(){
        transform.Translate(speed * Time.deltaTime , 0, 0);

        //怪物速度

        //當物體超過畫面時(x=200)怪物移動到第一層的位置
        if(EnemyPos.x<-96 && EnemyPos.y <= -10 && EnemyPos.y > -30)    
        {
        
        gameObject.transform.position = new Vector3(98, 24, 0);

        }
        //物體在第一層超過畫面時則讓她消失
        if(EnemyPos.x<-98 && EnemyPos.y <= 35 && EnemyPos.y > 10)
        {
            Destroy(gameObject);
        }

    }

     void OnCollisionStay2D(Collision2D coll){

        if(coll.gameObject.tag=="Cat")
        { 
          walking = false;
          IsAttacking = true ;
        }
        
  }
  void OnCollisionExit2D(Collision2D coll)
    
    {
        if(coll.gameObject.tag=="Cat")
        {
          walking = true;
           IsAttacking = false ;   
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
