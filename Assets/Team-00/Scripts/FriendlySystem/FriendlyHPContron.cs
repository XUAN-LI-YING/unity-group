using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHPContron : MonoBehaviour
{
    float hp=0;
    public int max_hp=0;
    public bool back;
    public int times=0;
    public GameObject FriendlyAllHP;
    // Start is called before the first frame update
    //最大血量為10，而初始HP血量=最大血量
    void Start()
    { 
        max_hp=10;
        hp=max_hp;
        back=true;
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

    //碰撞後bool為真開始持續扣血
    //  void OnTriggerEnter2D(Collider2D col)
     void OnCollisionStay2D(Collision2D col) 
    {   
        

        //如果碰撞到cat
        if(col.gameObject.tag=="Cat")
        {    hp -= 0.05f;
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
        // else if (times==0)
        //  {
        //   back=true;
        //  times += 1 ;
        // }    
            
            else
            {
              times += 1 ;
            }
            Debug.Log($"{times}秒");
            if(back==true)
            {//偵測現在move到哪裡的位置
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

