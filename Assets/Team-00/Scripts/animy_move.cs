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

        //當物體超過畫面時(x=200)怪物移動到的二層的位置
        if(transform.position.x>200)    
        {
        
        gameObject.transform.position = new Vector3(-200, -43, 0);

        }
        //物體在第二層超過畫面時則讓她消失
        if(transform.position.y==-43 && transform.position.x>200)
        {
            Destroy(gameObject);
        }

        
        if(IsCollide==true)
        {
           // Debug.Log(this.speed);
            this.speed=0.05f;
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
        if(col.tag=="SpikedTrap")
        {
            //Debug.Log("阿我撞到了QQ");
            IsCollide=true;
        }
    }
    
}
