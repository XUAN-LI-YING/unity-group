using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHPControl : MonoBehaviour
{
    public static FriendlyHPControl instance;
 
    [Header("血條物件")]
    public GameObject FriendlyAllHP;
    [Header("友軍目前血量")]
    public float hp=0;
    [Header("友軍最大血量")]
    public int max_hp=0;
    [Header("每幾秒扣一次")]
    public int costtime; // 每幾秒扣一次
    [Header("正常模式扣血量")]
    public int cost1; //正常模式扣血量
    [Header("停止受傷效果")]
    public bool stopblood;
    [Header("扣血計時開關")]
    public bool timer1bool;

    [Header("友軍退後(目前無效果)")]
    public bool back = true;
     public int times =0;


    // Start is called before the first frame update
    //最大血量為100，而初始HP血量=最大血量
    void Start()
    { 
        instance = this;
        max_hp=50;
        hp=max_hp;
        stopblood=false;
        timer1bool=false;
        costtime = 1;
        cost1 = 15;


    }

    // Update is called once per frame
    void Update()
    {   //如果目前血量HP小於等於0，那就會讓這個物件，也就是敵人消失
        if(hp<=0)
        {
            Destroy(this.gameObject);
        } 
        //如果HP沒有小於0目前的血條位置就會為 目前血量/最大血量
        float _percent=((float)hp /(float) max_hp);
        FriendlyAllHP.transform.localScale=new Vector3(_percent, FriendlyAllHP.transform.localScale.y,FriendlyAllHP.transform.localScale.z);

    }
    public void StopBloodon(){
        stopblood = true;
        CheckCondition();

    }

    public void StopBloodoff(){
        stopblood = false;
        CheckCondition();
    }

    //碰撞後bool為真開始持續扣血
    //  void OnTriggerEnter2D(Collider2D col)
     void OnCollisionStay2D(Collision2D col) 
    {   
        

        //如果碰撞到cat
        if(col.gameObject.tag=="Cat")
        { 
            


            //  hp -= Time.deltaTime * 5;
            
            // //偵測現在move到哪裡的位置
            // Vector3 move = gameObject.transform.position;
            // //move比現在的位置多5
            // move = new Vector3(move.x +5f, move.y, move.z);
            // //現在的位置等於現在+5後的move
            // gameObject.transform.position = move;
        }
    }
    void CheckCondition(){
        
        if (stopblood)
        
            {
                Debug.Log($"停止受傷狀態：{stopblood} ");
                Debug.Log($"friendly目前血量 {hp} ");
            } 

        else{


            timer1bool = true;
            CostBlood();
             Debug.Log($"friendly目前血量 {hp} ");
        }
            
 


    }
    public void CostBlood(){

      if (timer1bool){
         InvokeRepeating("timer1", 0, costtime);  
      }

  
      



    }
    void timer1(){
      
      hp = hp - cost1;
    //    Debug.Log($"友軍每{costtime}秒扣{cost1}滴血");     
       Debug.Log($"友軍剩餘{hp}滴血"); 
    }

    // void OnCollisionEnter2D(Collision2D coll) 
    // {
    //   if(coll.gameObject.tag=="Cat")
    //   {     if( times>=2)
    //         {
    //           back=true;
    //           times=0;
    //         }            
    //         else
    //         {
    //           times += 1 ;
    //         }
    //         if(back==true)
    //         {
    //         //偵測現在move到哪裡的位置
    //         Vector3 move = gameObject.transform.position;
    //         //move比現在的位置-5
    //         move = new Vector3(move.x+10f, move.y, move.z);
    //         //現在的位置等於現在-5後的move
    //         gameObject.transform.position = move;
    //         back=false;
            
    //         }
    //     }
    // }


} 

