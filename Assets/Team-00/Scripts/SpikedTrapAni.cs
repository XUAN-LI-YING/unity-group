using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedTrapAni : MonoBehaviour
{
  public static SpikedTrapAni instance;
  public bool touch;
  
  public GameObject monster;
  void Start()
  {
      instance = this;
  }
  public GameObject explo;

  public void bomb()
  {
    Instantiate(explo, monster.gameObject.transform.position, monster.gameObject.transform.rotation);
    touch = false;
  }
  public void Update()
  {
    if(CoolDown.instance.filledImage.fillAmount == 0)
    {
      if(touch == true)
      bomb();
    }
  }
  //產生黃色爆炸物件
  public void OnTriggerEnter2D(Collider2D col)
  {
    //Instantiate(explo, transform.position, transform.rotation);
    /*if(CoolDown.Update.isStartTime == false)
    {

    }*/
    //if(CoolDown.instance.timer == 5)
    if (col.tag == "Cat")
    {
      //Debug.Log(col);
      touch = true;
      monster = col.gameObject;

      //Instantiate(explo, col.gameObject.transform.position, col.gameObject.transform.rotation);
    }
    
  }
  
}
