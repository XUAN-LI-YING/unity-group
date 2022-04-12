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
        CheckCondition();

    }
    public void StopBloodon(){
        stopblood = true;
        CheckCondition();

    }

    public void StopBloodoff(){
        stopblood = false;
        CheckCondition();
    }

    
    // 一碰到就判斷是否扣血，而不是碰到過程一直判斷
    // 看 commit 記錄可看我改了什麼哦
     void OnCollisionEnter2D(Collision2D col) 
    {   
        

        //如果碰撞到cat
        if(col.gameObject.tag=="Cat")
        { 
            
            if (stopblood)
            {
                // 效果開了當然不能扣！
                
            }else{

                // 原本的：hp -= Time.deltaTime * 20;

                // 扣血量要以固定頻率運作，通常用在速度哦哦
                // 幫你找了相關資料：https://ithelp.ithome.com.tw/articles/10273201?sc=hot
                // 再幫你寫了另一個函式去計時扣血，還能設定秒數呢～
               InvokeRepeating("timer1", 0, costtime);

            }

             
            
            // 上方映璇寫的重新調整

        }
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        // 離開當然取消攻擊啦
        CancelInvoke("timer1");

    }


    public void CheckCondition(){
        
        if (stopblood)
        
            {
                // Debug.Log($"友軍停止受傷狀態：{stopblood} ");
                // Debug.Log($"friendly目前血量 {hp} ");
            } 

        else{
            
            //  Debug.Log($"友軍停止受傷狀態：{stopblood} ");
        }
            
 


    }

    void timer1(){
      
      hp = hp - cost1;
       Debug.Log($"友軍每{costtime}秒扣{cost1}滴血");     
       Debug.Log($"友軍剩餘{hp}滴血"); 
    }




} 

