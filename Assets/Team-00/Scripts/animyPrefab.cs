using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animyPrefab : MonoBehaviour
{
    public GameObject catPrefab;
    [Header("TIME")] 
    public float span = 4;
    //怪物出現間隔時間
    public float delta = 0;
    // 怪物產生計時器
    

    // 怪物產生位置
    void Update()
    {
       this.delta+=Time.deltaTime;
       if(this.delta>this.span){
           this.delta=0;
           GameObject go =Instantiate(catPrefab) as GameObject;

           go.transform.position=new Vector3(-158,35,0);
    //    transform.localScale = new Vector3(1.5f, 1.5f,1.5f);
    //更改為1.5倍大
           

       }
       //定義位置
       
    }


    //請閱讀：https://dometi.com.tw/blog/unity-2d-lesson3/
}
