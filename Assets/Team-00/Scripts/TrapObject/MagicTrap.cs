using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

  public GameObject aniexplo;

   public GameObject enemy;

   bool collision = false;

  //滑鼠按下時，出現動畫aniexplo，且動畫位置為(X,y)(gameObject.transform.position, gameObject.transform.rotation)

 

   public void OnTriggerEnter2D(Collider2D other)
   {
     collision = true;
    //  Debug.Log("only meet sth");
   }
   public void OnTriggerExit2D(Collider2D other)
  {
     collision = false;
     if (other.gameObject.tag == "Cat")
    {
      // Debug.Log("遇到敵方沒點擊");

    }


  }


  void update()
  {
    if ( Input.GetMouseButtonDown(0) ){　
    Debug.Log("滑鼠在點我了!");
    if (collision == true)
     {

      Correct();
     }
    Instantiate(aniexplo, gameObject.transform.position, gameObject.transform.rotation);
    Destroy(this.gameObject);
     
     }
  }

  //這串function無法觸發
  void OnMouseDown()
  {
     Debug.Log("滑鼠在點我了!");
     if (collision == true)
     {

      Correct();
     }
    
    
    // 日後再自動產生

  }

  void Correct()
  {
    
     Debug.Log("click correct");
    fearBar.instance.Increase();



  }


}


