using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHPContron : MonoBehaviour
{
  float hp = 0;
  float delta = 0;
  public bool IsCollide;
  public bool back;
  public int max_hp = 0;
  public GameObject EnemyAllHP;
  public int times=0;
  
  // Start is called before the first frame update
  //最大血量為10，而初始HP血量=最大血量
  void Start()
  { 
    IsCollide = false;
    back=true;
    max_hp = 10;
    hp = max_hp;
  }

  // Update is called once per frame
  void Update()
  {   //如果目前血量HP小於等於0，那就會讓這個物件，也就是敵人消失
    if (hp <= 0)
    {
      Destroy(this.gameObject);
      
    }
   
    //如果HP沒有小於0目前的血條位置就會為 目前血量/最大血量
    float _percent = ((float)hp / (float)max_hp);
    EnemyAllHP.transform.localScale = new Vector3(_percent, EnemyAllHP.transform.localScale.y, EnemyAllHP.transform.localScale.z);

    //如果deltaTime>=500，就停止扣血，如果還沒超過時間碰撞後持續扣血
    if (IsCollide == true)
    {
      //每秒扣血
      hp -= Time.deltaTime * 0.5f;
      delta += 1;
    }
    if (delta >= 800)
    {
      IsCollide = false;
    }
    //Debug.Log(hp);
    
  
  }

  //碰撞後bool為真開始持續扣血
  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      IsCollide = true;
    }

    if (col.tag == "rockboom")
    {
      hp -= 1;
      // trap-02物件 要更換tag哦 
    }

    // 如果敵人撞到友軍則扣血
    // if (col.tag == "Friendly")
    // {   //hp-0.1
    //   hp -= 1f;
    // }

  }
void OnCollisionStay2D(Collision2D coll) 
    {   //如果碰撞到cat
        if(coll.gameObject.tag=="Friendly")
        {   hp -=0.03f;
            
        
        }
        if(coll.gameObject.tag=="guard")
        {   //hp-0.1
            hp -= 0.1f;
            
        }
    }

void OnCollisionEnter2D(Collision2D coll) 
{
  if(coll.gameObject.tag=="Friendly")
  {     if( times>=2)
            {
              back=true;
              times=0;
            }

            else
            {
              times += 1 ;
            }
            if(back==true)
            {//偵測現在move到哪裡的位置
            Vector3 move = gameObject.transform.position;
            //move比現在的位置-5
            move = new Vector3(move.x-20f, move.y, move.z);
            //現在的位置等於現在-5後的move
            gameObject.transform.position = move;
            back=false;
            }
  }
  
}



}

