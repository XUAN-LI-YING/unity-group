using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 更動組員程式碼開發方式以及其解釋理由
// 若更改造成有 bug 產生，還請多多見諒 !!
// 更改地方：(commit上也看得到差異哦)
// 將產生怪物時間設置變數以利團隊遊戲開發

public class EnemyPrefab : MonoBehaviour
{
  public GameObject catPrefab;

  [Header("TIME")]
  
  public float delta ;
  public int createtime;

  void Start(){

    delta = 0;
    createtime = 20;
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
      go.transform.position = new Vector3(-104, 13.6f, 0);



    }


  }

}
