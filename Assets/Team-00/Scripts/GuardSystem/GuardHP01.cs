using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardHP01 : MonoBehaviour
{
    float hp=0;
    public int max_hp=0;
    public GameObject GuardAllHP01;
    public Animator playerAni;
    public bool IsAttacking;
    // Start is called before the first frame update
    //最大血量為10，而初始HP血量=最大血量
    void Start()
    { 
        IsAttacking = false ;
        max_hp=20;
        hp=max_hp;
    }

    // Update is called once per frame
    void Update()
    {   
        //如果IsWalking則呼叫status動畫
        if(IsAttacking==true)
        {
            if(playerAni.GetInteger("status")==0)
              
                playerAni.SetInteger("status",1);
                // Debug.Log("IsAttacking");
         
        }
        else
        {
            if(playerAni.GetInteger("status")==1)
            {   
                playerAni.SetInteger("status",0);
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
     void OnCollisionEnter2D(Collision2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Cat")
        {   //hp-0.1
             InvokeRepeating("guardBoold", 0f, 2);
            IsAttacking = true ;      
        }
        if(coll.gameObject.tag=="bigEnemy")
        {   //hp-0.1
            
            IsAttacking = true ;      
        }
        if(coll.gameObject.tag=="DevilEnemy")
        {   //hp-0.1
            InvokeRepeating("DevilguardBoold", 0f, 2);
            IsAttacking = true ;      
        }
    }
    void OnCollisionExit2D(Collision2D coll)
    
    {
        if(coll.gameObject.tag=="Cat")
        {
           IsAttacking = false ;   
           CancelInvoke("guardBoold");
        }
         if(coll.gameObject.tag=="bigEnemy")
        {
           IsAttacking = false ;   
          
        }
         if(coll.gameObject.tag=="DevilEnemy")
        {
           IsAttacking = false ;   
           CancelInvoke("DevilguardBoold");
        }
    }

    void guardBoold()
    {
        hp = hp-3;
    }

    void DevilguardBoold()
    {
        hp = hp-6;
    }
} 