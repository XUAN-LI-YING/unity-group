using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{

  public static MonsterController instance;
  public float Speed;
  public int ATK;

  public float delaySec;

  bool Checking = true;

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

    if (Checking)
    {
      Moving();
    }
  }

  public void Moving()
  {
    this.gameObject.transform.position += new Vector3(-Speed / 250, 0, 0);




  }

  //怪物攻擊動畫
  public void OnCollisionEnter2D(Collision2D collision)
  {


    if (collision.gameObject.name == "catPrefab(Clone)")

    {
      Checking = false;
      print("MONSTER meet:" + collision.gameObject.name);


      print("攻擊" + collision.gameObject.name + "並切換動畫");
      Speed = 0;

      BloodController.instance.Costblood();




    }


  }

  //執行怪物攻擊

  public void OnCollisionStay2D(Collision2D collision)
  {
    // 播放攻擊動畫
    if (collision.gameObject.name == "catPrefab(Clone)")
    {

      // 調用貓咪扣血code
      Waitingtime();
      //  hp -= 1;
    }

  }
  IEnumerator Waitingtime()
  {
    Debug.Log($"等待{delaySec}秒");
    yield return new WaitForSeconds(delaySec);



  }

  public void OnCollisionExit(Collision other)
  {

    if (other.gameObject.tag == "catPrefab(Clone)")
    {
      Moving();
    }
  }



}
