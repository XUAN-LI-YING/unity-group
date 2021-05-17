using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyPref : MonoBehaviour
{
  public static friendlyPref instance;
  //一開始沒有怪物為false
  public bool activeSelf = false;
  public GameObject friendlyForce;

  [Header("TIME")]
  public float span = 1;
  //怪物出現間隔時間
  public float delta = 0;
  // 怪物產生計時器


  // 怪物產生位置
  void Update()
  {

    //如果時間累積到了5秒針，讓DELTA歸零且產生敵人
    this.delta += Time.deltaTime;
    if (this.delta > 10f)
    { //& appear_toggle==true

      this.delta = 0;
      GameObject go = Instantiate(friendlyForce) as GameObject;
      //定義產生位置
      go.transform.position = new Vector3(70, -19, 0);
    }

  }
  void Start()
  {
    instance = this;
    fearBar.instance.Decrease01();
    //目前只扣一次

  }




}