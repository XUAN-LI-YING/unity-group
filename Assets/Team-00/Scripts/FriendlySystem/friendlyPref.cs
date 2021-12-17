using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 //更動組員程式碼命名方式以及其解釋理由
 // 若更改造成有 bug 產生，還請多多見諒 !!
 // 很想要更改的地方：(commit上也看得到差異哦)
 // 
 // 產生每一友軍時間參數設置為全域變數
 // 解釋其理由：容易在 unity 調整數值方便團隊開發

public class friendlyPref : MonoBehaviour
{
  public static friendlyPref instance;
  //一開始沒有友軍為false
  public bool activeSelf;
  public GameObject friendlyForce;

  [Header("TIME")]
  public float delta = 0;
  // 友軍產生計時器
  public int createtime = 2;


  // 友軍產生位置
  void Update()
  {

    //如果時間累積到了5秒針，讓DELTA歸零且產生友軍
    this.delta += Time.deltaTime;
    if (this.delta > createtime)
    { //& appear_toggle==true

      this.delta = 0;
      GameObject go = Instantiate(friendlyForce) as GameObject;
      //定義產生位置
      go.transform.position = new Vector3(66, -15, 0);
    }

  }
  void Start()
  {
    instance = this;


 

  
  }






}