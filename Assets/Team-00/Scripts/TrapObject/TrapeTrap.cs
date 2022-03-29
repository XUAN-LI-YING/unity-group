using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapeTrap : MonoBehaviour
{
    
    public Animator playerAni;
    public bool IsAttacking;
   
    void Start()
    { 
        IsAttacking = false ;
        
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
        
        
    }

     void OnTriggerStay2D(Collider2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Cat")
        { 
            // Debug.Log("碰撞到敵人啦")  ;
            IsAttacking = true ;      
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    
    {
        if(coll.gameObject.tag=="Cat")
        {
           IsAttacking = false ;   
        }
    }


}
