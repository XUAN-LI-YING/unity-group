using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyMove : MonoBehaviour
{
    float speed=0;
    void Start()
    {
      
      //怪物初始數度
      this.speed=-0.08f;  
    }
    void Update()
    {
        //怪物速度
        transform.Translate(this.speed,0,0);

        //怪物消失判斷，只靠位置
        if(transform.position.x<-200)    
        {
        Destroy(gameObject);
        }
    }
}
