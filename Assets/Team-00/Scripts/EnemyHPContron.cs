using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    int hp=0;
    public int max_hp=0;
    public GameObject EnemyAllHP;
    // Start is called before the first frame update
    void Start()
    {
        max_hp=10;
        hp=max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp<=0)
        {
            Destroy(this.gameObject);
        }
        float _percent=((float)hp /(float) max_hp);
        EnemyAllHP.transform.localScale=new Vector3(_percent, EnemyAllHP.transform.localScale.y,EnemyAllHP.transform.localScale.z);
    }

    //碰撞後消失
     void OnTriggerEnter2D(Collider2D col)
    {
      if(col.tag=="Trap")
        {
           hp-=1;
            
        }
    } 
}
