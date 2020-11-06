using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animyPrefab : MonoBehaviour
{
    public GameObject catPrefab;
    float span = 2;
    //怪物出現間隔時間
    float delta = 0;
    // 怪物產生計時器
    

    // 怪物產生位置
    void Update()
    {
       this.delta+=Time.deltaTime;
       if(this.delta>this.span){
           this.delta=0;
           GameObject go =Instantiate(catPrefab) as GameObject;
           go.transform.position=new Vector3(-32,-16,0);
       }
       //定義位置
       
    }
}
