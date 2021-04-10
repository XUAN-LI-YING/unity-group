using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

  public GameObject aniexplo;

  // public GameObject enemy;

  bool collision = false;

  //滑鼠按下時，出現動畫aniexplo，且動畫位置為(X,y)(gameObject.transform.position, gameObject.transform.rotation)

  void Start()
  {

    // Correct();

  }

  void Update()
  {

  }

  public void OnTriggerExit2D(Collider2D other)
  {
    collision = false;
    if (other.gameObject.tag == "Cat")
    {
      Debug.Log("遇到貓沒點擊");

      // Instantiate(aniexplo, gameObject.transform.position, gameObject.transform.rotation);
      // Destroy(this.gameObject);

    }


  }




  public void OnTriggerStay2D(Collider2D other)
  {
    if ((other.gameObject.tag == "Cat") && (collision = true))
    {


      Debug.Log("meet cat");
    }







  }
  public void OnTriggerEnter2D(Collider2D other)
  {
    collision = true;
    Debug.Log("only meet ");
  }

  public void OnMouseDown()
  {
    if (collision == true)
    {

      Correct();

    }
    Debug.Log("click");
    Instantiate(aniexplo, gameObject.transform.position, gameObject.transform.rotation);
    Destroy(this.gameObject);

    // 欸都 全部敵人會一起爆裂 bug !!!!!!!! 

  }

  void Correct()
  {



    Debug.Log("meet cat and click");
    fearBar.instance.Increase();



  }


}


