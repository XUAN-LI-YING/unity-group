using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

    public GameObject aniexplo;
//滑鼠按下時，出現動畫aniexplo，且動畫位置為(X,y)(gameObject.transform.position, gameObject.transform.rotation)
    void OnMouseDown()
    {    

         Instantiate(aniexplo, gameObject.transform.position, gameObject.transform.rotation);
         Destroy(this.gameObject);

    }
}
