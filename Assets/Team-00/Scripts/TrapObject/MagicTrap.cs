using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

   public GameObject Aniboom;

   

<<<<<<< HEAD
  //  bool collision = false;
=======
   public bool collision = false;
>>>>>>> 88bf90e4ef40953704d09b0085d39a2e10416f72

  // //滑鼠按下時，出現動畫Aniboom，且動畫位置為(X,y)(gameObject.transform.position, gameObject.transform.rotation)

 

<<<<<<< HEAD
  //  public void OnTriggerEnter2D(Collider2D other)
  //  {
  //    collision = true;
  //   //  Debug.Log("only meet sth");
  //  }
  //  public void OnTriggerExit2D(Collider2D other)
  // {
  //    collision = false;
  //    if (other.gameObject.tag == "Cat")
  //   {
  //     // Debug.Log("遇到敵方沒點擊");
=======
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
>>>>>>> 88bf90e4ef40953704d09b0085d39a2e10416f72

  //   }


  // }

<<<<<<< HEAD
    
  //   if (collision == true)
  //    {

  //     Correct();
  //    }
     
     
  // }

  
   void OnMouseDown()
   {
      Debug.Log("滑鼠在點我了!");
   }
  //    if (collision == true)
  //    {

  //     Correct();
  //    }
    
    
  //   // 日後再自動產生
=======
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
    
>>>>>>> 88bf90e4ef40953704d09b0085d39a2e10416f72

  // }

  // void Correct()
  // {
    
<<<<<<< HEAD
  //   //  Debug.Log("click correct");
  //   fearBar.instance.Increase();
=======
     Debug.Log("click correct");
    fearBar.instance.Increase();
>>>>>>> 88bf90e4ef40953704d09b0085d39a2e10416f72



  // }

  
}



