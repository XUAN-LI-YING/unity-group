using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyHPContron : MonoBehaviour
{
    float hp=0;
    public int max_hp=0;
    public GameObject FriendlyAllHP;
    // Start is called before the first frame update
    //最大血量為10，而初始HP血量=最大血量
    void Start()
    { 
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
        FriendlyAllHP.transform.localScale=new Vector3(_percent, FriendlyAllHP.transform.localScale.y,FriendlyAllHP.transform.localScale.z);

    }

    //碰撞後bool為真開始持續扣血
     void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag=="Cat")
        {
            hp -= 0.1f;
            //this.gameObject.transform.position=new Vector3(this.gameObject.transform.position.X+0.5f, this.gameObject.transform.position.y,this.gameObject.transform.position.z);
            Vector3 move = gameObject.transform.position;
            move = new Vector3(move.x +5f, move.y, move.z);
            gameObject.transform.position = move;
        }
    }

} 

