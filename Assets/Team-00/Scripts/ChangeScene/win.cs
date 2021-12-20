using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class win : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
  {
    if (col.tag == "Friendly")
    {
      SceneManager.LoadScene("gameWin");  
    }

    }
}
