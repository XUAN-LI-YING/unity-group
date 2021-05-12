using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

  public GameObject aniexplo;

  // public GameObject enemy;

  bool collision = false;

  //滑鼠按下時，出現動畫aniexplo，且動畫位置為(X,y)(gameObject.transform.position, gameObject.transform.rotation)

 

  public void OnTriggerEnter2D(Collider2D other)
  {
    collision = true;
    Debug.Log("only meet sth");
  }


  public void OnTriggerStay2D(Collider2D other)
  {
    if ((other.gameObject.tag == "Cat") )
    {

      // Debug.Log("meet cat and plz click !!");
    }

  }
  public void OnTriggerExit2D(Collider2D other)
  {
    collision = false;
    //碰到任一object 且離開，collision 失效，使點擊無效

  }


  // public void OnTriggerExit2D(Collider2D other)
  // {
  //   collision = false;
  //   if (other.gameObject.tag == "Cat")
  //   {
  //     Debug.Log("遇到貓沒點擊");

  //   }


  // }

  public void OnMouseDown()
  {

    if (collision == true)
    {


      Correct();

    }

    Instantiate(aniexplo, gameObject.transform.position, gameObject.transform.rotation);
     Destroy(this.gameObject);

    // 日後再自動產生

  }

  void Correct()
  {
    Debug.Log("click correct");
    fearBar.instance.Increase();



  }


}


