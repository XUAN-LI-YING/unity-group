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

        //當物體超過畫面時(x=200)怪物移動到第一層的位置
        if(transform.position.x<-200)    
        {
        
        gameObject.transform.position = new Vector3(200, 40, 0);

        }
        //物體在第一層超過畫面時則讓她消失
        if(transform.position.y==40 && transform.position.x<-200)
        {
            Destroy(gameObject);
        }
    }
}
