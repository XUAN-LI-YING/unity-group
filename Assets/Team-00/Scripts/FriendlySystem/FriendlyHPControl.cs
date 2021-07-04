using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 更動組員程式碼命名方式以及其解釋理由
// 若更改造成有 bug 產生，還請多多見諒 !!
// 更改地方：(commit上也看得到差異哦)
// 將 Contron 改為 Control 控制的英文單字
// 可安裝拼字檢查套件避免英文拼字錯誤哦
// https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker
public class FriendlyHPControl : MonoBehaviour
{
    public static FriendlyHPControl instance;
 
    float hp=0;
    public int max_hp=0;
    public bool back;
    public bool stopblood;
    public int times=0;
    public GameObject FriendlyAllHP;
    // Start is called before the first frame update
    //最大血量為10，而初始HP血量=最大血量
    void Start()
    { 
        instance = this;
        max_hp=10;
        hp=max_hp;
        back=true;
        stopblood=false;


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
    }

    public void StopBloodoff(){
        stopblood = false;
    }

    //碰撞後bool為真開始持續扣血
    //  void OnTriggerEnter2D(Collider2D col)
     void OnCollisionStay2D(Collision2D col) 
    {   
        

        //如果碰撞到cat
        if(col.gameObject.tag=="Cat")
        { 
            if (stopblood)
            {
                Debug.Log($"目前血量 {hp} ");
            } 
            
            hp -= 0.05f;
            //  hp -= Time.deltaTime * 5;
            
            // //偵測現在move到哪裡的位置
            // Vector3 move = gameObject.transform.position;
            // //move比現在的位置多5
            // move = new Vector3(move.x +5f, move.y, move.z);
            // //現在的位置等於現在+5後的move
            // gameObject.transform.position = move;
        }
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
      if(coll.gameObject.tag=="Cat")
      {     if( times>=2)
            {
              back=true;
              times=0;
            }            
            else
            {
              times += 1 ;
            }
            if(back==true)
            {
            //偵測現在move到哪裡的位置
            Vector3 move = gameObject.transform.position;
            //move比現在的位置-5
            move = new Vector3(move.x+10f, move.y, move.z);
            //現在的位置等於現在-5後的move
            gameObject.transform.position = move;
            back=false;
            
            }
        }
    }


} 

