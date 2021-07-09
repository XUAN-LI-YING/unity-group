using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollanimation : MonoBehaviour
{   
    // public float speed = 0; 
    public Animator playerAni;
    
    void Start()
    {
    // this.speed = 10f;   
    }

    void Update()
    {   
        // rollPos = transform.position;
        
    }

    // void rollspeed()
    // {
    //     transform.Translate(this.speed,0,0);

    //     //當物體超過畫面時(x=200)怪物移動到第一層的位置
    //     if(transform.position.x<-105 )    
    //     {
    
    //     Destroy(gameObject);
    //     }
        
    // }
    void OnTriggerEnter2D(Collider2D col)
    {
    if (col.gameObject.tag=="Cat")
    {
      
    //   if(playerAni.GetInteger("roll")==0)
        
     playerAni.SetInteger("roll",1);
    
    //  rollspeed();
     
    }
    }
    void AnimationEnd() 
     {
     Destroy (gameObject); //當動畫結束消滅此物件
    
     }  
}
