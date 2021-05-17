using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedTrapAni : MonoBehaviour
{
  public GameObject explo;
  //產生黃色爆炸物件
  void OnTriggerEnter2D(Collider2D col)
  {
    //Instantiate(explo, transform.position, transform.rotation);
    if (col.tag == "Cat")
    {
      Debug.Log("pink meet cat");
      Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
    }
    if (col.tag == "Player")
    {
      Debug.Log("trap meet player");
      Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
    }
  }
}
