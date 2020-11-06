using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animy_move : MonoBehaviour
{
    
    float speed=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    
    void Update()
    {this.speed=0.008f;
    transform.Translate(this.speed,0,0);
    //怪物速度

    //怪物消失判斷，只靠位置
    if(transform.position.x>32)    
    {
        Destroy(gameObject);
    }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
      if(col.tag=="Trap")
        {
            Destroy(col.gameObject);
             Destroy(gameObject);
            
        }
    }
}
