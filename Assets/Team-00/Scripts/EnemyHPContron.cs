using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPContron : MonoBehaviour
{
    float hp=0;
    float delta=0;
    public bool IsCollide;
    public int max_hp=0;
    public GameObject EnemyAllHP;
    // Start is called before the first frame update
    //最大血量為10，而初始HP血量=最大血量
    void Start()
    { 
        IsCollide=false;
        max_hp=10;
        hp=max_hp;
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
        EnemyAllHP.transform.localScale=new Vector3(_percent, EnemyAllHP.transform.localScale.y,EnemyAllHP.transform.localScale.z);
        
        //如果deltaTime>=500，就停止扣血，如果還沒超過時間碰撞後持續扣血
        if (IsCollide==true)
        {   
            //每秒扣血
            hp -= Time.deltaTime *1;
            delta+=1;
        }
        if(delta>=2000)
        {   
            IsCollide=false;
        }
    }

    //碰撞後bool為真開始持續扣血
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Trap")
        {
           IsCollide=true;
        }
    //如果碰撞到rockboom(也就是魔法地雷的特效時)hp-10
        if(col.tag=="rockboom")
        {
           hp -= 10 ;
        }

        if(col.tag=="Friendly")
        {   //hp-0.1
            hp -= 0.1f;
            //this.gameObject.transform.position=new Vector3(this.gameObject.transform.position.X+0.5f, this.gameObject.transform.position.y,this.gameObject.transform.position.z);
            //偵測現在move到哪裡的位置
            Vector3 move = gameObject.transform.position;
            //move比現在的位置多5
            move = new Vector3(move.x -5f, move.y, move.z);
            //現在的位置等於現在+5後的move
            gameObject.transform.position = move;
        }

    }

    
} 

