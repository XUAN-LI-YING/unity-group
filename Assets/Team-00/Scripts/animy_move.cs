using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animy_move : MonoBehaviour
{
    int delta=0;
    float speed=0;
    public bool IsCollide;
    void Start()
    {
      IsCollide=false;
      //怪物初始數度
      this.speed=0.08f;  
    }
    void Update()
    {
        //怪物速度
        transform.Translate(this.speed,0,0);

        //怪物消失判斷，只靠位置
        if(transform.position.x>200)    
        {
        Destroy(gameObject);
        }

        if(IsCollide==true)
        {
            //Debug.Log("阿我減速了QQ");
            this.speed=0.04f;
            delta+=1;
        }

        if (delta>=2000)
        {
            //Debug.Log("阿我恢復了!");
            IsCollide=false;
            this.speed=0.08f;
        }

    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Trap")
        {
            //Debug.Log("阿我撞到了QQ");
            IsCollide=true;
        }
    }
    
}
