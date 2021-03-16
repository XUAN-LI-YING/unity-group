using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTrap : MonoBehaviour
{

    public GameObject aniexplo;

    void OnMouseDown()
    {
         Instantiate(aniexplo, gameObject.transform.position, gameObject.transform.rotation);
         Destroy(this.gameObject);

      
    }
}
