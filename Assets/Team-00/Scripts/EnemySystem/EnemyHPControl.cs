using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 更動組員程式碼命名方式以及其解釋理由
// 若更改造成有 bug 產生，還請多多見諒 !!
// 更改地方：(commit上也看得到差異哦賴訊息會再報備一次)
// 將 max_hp = 100;
public class EnemyHPControl : MonoBehaviour
{
  float hp = 0;
  float spikedelta = 0;
  float deltaSum=0; //delta要比deltaSum大 的值

  float spikecollide=0; //尖刺陷阱碰撞次數加成
  public bool spikeIsCollide;
  public bool back; //擊退成立否
  public int max_hp ;
  public GameObject EnemyAllHP;
  public int times=0; //擊退次數
  
  // Start is called before the first frame update
  //最大血量為10，而初始HP血量=最大血量
  void Start()
  { 
    spikeIsCollide = false;
    back=true;
    max_hp = 100;
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

    //如果spikedeltaTime>=500，就停止扣血，如果還沒超過時間碰撞後持續扣血
    if (spikeIsCollide == true)
    {
      //每秒扣血
      hp -= Time.deltaTime * 10f;
      
      spikedelta += 1;
      deltaSum=800*spikecollide;  //扣血加成
    }
    if (spikedelta >= deltaSum)
    {
     

      spikeIsCollide = false;
      spikedelta=0;
      spikecollide=0;
    }
    //Debug.Log(hp);
    
  
  }

  //碰撞後bool為真開始持續扣血
  void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "SpikedTrap")
    {
      spikeIsCollide = true;
      spikecollide += 1 ;
    }

    if (col.tag == "rockboom")
    {
      hp -= 1;
      // trap-02物件 要更換tag哦 
    }
    if (col.tag=="Traps02")
    {
      hp -= 10;  
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
        {   hp -=0.1f;
            
        
        }
        if(coll.gameObject.tag=="guard")
        {   //hp-0.1
            hp -= 0.1f;
            
        }
    }

// void OnCollisionEnter2D(Collision2D coll) 
// {
//   if(coll.gameObject.tag=="Friendly")
//   {     if( times>=2)
//             {
//               back=true;     //當遇到我方友軍則會擊退並計算擊退次數
//               times=0;
//             }

//             else
//             {
//               times += 1 ;
//             }
//             if(back==true)
//             {
//             //偵測現在move到哪裡的位置
//             Vector3 move = gameObject.transform.position;
//             //move比現在的位置-5
//             move = new Vector3(move.x-20f, move.y, move.z);
//             //現在的位置等於現在-5後的move
//             gameObject.transform.position = move;
//             back=false;
//             }
//   }
  
// }



}

