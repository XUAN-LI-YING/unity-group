using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    int hp = 0;
    public float Speed;
    public int max_hp = 0;
    public GameObject HP_Bar;

    public int ATK;

    // Start is called before the first frame update
    void Start()
    {
        max_hp = 10;
        hp = max_hp;

    }

    // Update is called once per frame
    void Update()
    {
        float ratio = ((float)hp/(float)max_hp);
        
       
        HP_Bar.transform.localScale = new Vector3(ratio, HP_Bar.transform.localScale.y, HP_Bar.transform.localScale.z);

        this.gameObject.transform.position += new Vector3(-Speed / 250, 0, 0);


        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
        // print(hp);

    }


    //怪物攻擊動畫
    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "player(Clone)")

        {
            print("Enemy meet:" + collision.gameObject.name);



            Speed = 0;
           


        }


    }

    //執行怪物攻擊

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player(Clone)")
        {


            print("MonstererATK:" + collision.gameObject.name);
             hp -= 1;
        }

    }

    public void OnCollisionExit(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            Speed = 2;
            this.gameObject.transform.position += new Vector3(-Speed / 250, 0, 0);
        }
    }



}
