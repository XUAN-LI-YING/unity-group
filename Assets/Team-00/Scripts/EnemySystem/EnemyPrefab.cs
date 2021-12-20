using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class EnemyPrefab : MonoBehaviour
{
  public GameObject catPrefab;

  [Header("每__秒製造敵人")]
  public int createtime;

  [Header("計時器")]
  
  public float delta ;
  
  void Start(){

    delta = 0;
    createtime = 5;  // 2021.10.03 改久一點方便齡移偵錯看 log 場上兩隻會產生的狀況夠燒腦ㄌ
  }
 
  
  // 怪物產生位置
  void Update()
  {
    
    
    this.delta += Time.deltaTime;
    if (this.delta > createtime)
    {
      this.delta = 0;
      GameObject go = Instantiate(catPrefab) as GameObject;
      //定義產生位置
      go.transform.position = new Vector3(-104, 25f, 0);



    }


  }

}
