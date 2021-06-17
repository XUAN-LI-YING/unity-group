using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animyPrefab : MonoBehaviour
{
  public GameObject catPrefab;
  [Header("TIME")]
  
  public float delta = 0;
  
  // 怪物產生位置
  void Update()
  {
    // Debug.Log(catPrefab.transform);
    //如果時間累積到了5秒針，讓DELTA歸零且產生敵人
    this.delta += Time.deltaTime;
    if (this.delta > 10f)
    {
      this.delta = 0;
      GameObject go = Instantiate(catPrefab) as GameObject;
      //定義產生位置
      go.transform.position = new Vector3(-104, 13.6f, 0);



    }


  }

}
