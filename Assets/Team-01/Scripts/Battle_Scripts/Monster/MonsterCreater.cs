using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCreater : MonoBehaviour
{
    
    public GameObject Monster;
    // public GameObject HP_Bar;

    
    
    void Start()
    {
          //執行生成怪物程式碼(每秒一次)
        CreatMonster();
        // InvokeRepeating("CreatMonster", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreatMonster()

    {

        int MonsterNum =1;

        //隨機決定要生成幾個怪物(0-2個隨機)

        // MonsterNum = Random.Range(0, 3);

        //開始生成怪物

        for (int i = 0; i < MonsterNum; i++)

        {

            //宣告生成的X座標

            float x;

            //產生隨機的X座標

            x = Random.Range(25, 32);

            //生成怪物

            Instantiate(Monster, new Vector3(x, 0.8f, 0), Quaternion.identity);


            // CreatHP();
        }

    }
    // public void CreatHP()
    
    // {
    
    
    // Instantiate(HP_Bar, new Vector3(Monster.transform.position.x,(Monster.transform.position.y)+3,0), Quaternion.identity);

    

    // }

}
