using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

   public GameObject Aniboom;

   

   public bool collision = false;

  //滑鼠按下時，出現動畫Aniboom，且動畫位置為(X,y)(gameObject.transform.position, gameObject.transform.rotation)

 

   public void OnTriggerEnter2D(Collider2D other)
   {
    //  collision = true;
    //  Debug.Log("only meet sth");
   }   
   public void OnTriggerStay2D(Collider2D other)
   {
     collision = true;
    
   }

   public void OnTriggerExit2D(Collider2D other)
  {
     collision = false;
     if (other.gameObject.tag == "Cat")
    {

    }


  }


  void update()
  {

    if(Input.GetMouseButtonDown(0))
    {
      	Debug.Log("Pressed left click.");
    }
		

  }

  void OnMouseDown()
  {
     Debug.Log("滑鼠在點我了!");
     if (collision == true)
     {

      Correct();
     }

       Instantiate(Aniboom, gameObject.transform.position, gameObject.transform.rotation);
       Destroy(this.gameObject);
    

  }

  void Correct()
  {
    
     Debug.Log("click correct");
    fearBar.instance.Increase();



  }


}


