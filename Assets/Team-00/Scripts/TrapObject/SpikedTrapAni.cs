using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikedTrapAni : MonoBehaviour
 {
  public static SpikedTrapAni instance;
  public bool touch;
  public float fill=1;
  
  public GameObject monster;
  void Start()
  {
      instance = this;
  }
  public GameObject explode=null;

  public void bomb()
  {
    
    Instantiate(explode, monster.gameObject.transform.position, monster.gameObject.transform.rotation);
    touch = false;
  }
  public void Update()
  {

    //這裡有問題
    if(coldtime.instance.filledImage.fillAmount == 0)
    {
      if(touch == true)
       bomb();
      
    }
   
  }
  //產生黃色爆炸物件
  public void OnTriggerStay2D(Collider2D col)
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
  
    }
    
  }

  public void OnTriggerEnter2D(Collider2D col)
  {
    
    if (col.tag == "Cat")
    {
      Instantiate(explode, transform.position, transform.rotation);
      // coldtime.filledImage.fillAmount =fill;

    }
    
  }

  
}
