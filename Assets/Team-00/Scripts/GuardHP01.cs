using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHP01 : MonoBehaviour
{
    float hp=0;
    public int max_hp=0;
    public GameObject GuardAllHP01;
    public Animator playerAni;
    public bool IsWalking;
    // Start is called before the first frame update
    //最大血量為10，而初始HP血量=最大血量
    void Start()
    { 
        IsWalking = false ;
        max_hp=20;
        hp=max_hp;
    }

    // Update is called once per frame
    void Update()
    {   //如果目前血量HP小於等於0，那就會讓這個物件，也就是敵人消失
        
        if(IsWalking==true)
        {
            if(playerAni.GetInteger("sword")==0)
              
                playerAni.SetInteger("sword",1);
                Debug.Log("IsWalking");
         
        }
        else
        {
            if(playerAni.GetInteger("sword")==1)
            {   
                playerAni.SetInteger("sword",0);
            }
        }
        if(hp<=0)
        {
            Destroy(this.gameObject);
        } 
        //如果HP沒有小於0目前的血條位置就會為 目前血量/最大血量
        float _percent=((float)hp /(float) max_hp);
        GuardAllHP01.transform.localScale=new Vector3(_percent, GuardAllHP01.transform.localScale.y,GuardAllHP01.transform.localScale.z);
        
    }

    //碰撞後bool為真開始持續扣血
     void OnCollisionStay2D(Collision2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Cat")
        {   //hp-0.1
            hp -= 0.09f;
            IsWalking = true ;      
        }
    }

} 