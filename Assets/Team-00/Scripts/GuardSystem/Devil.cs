using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Devil : MonoBehaviour
{
    
    [Header("撞到敵軍次數")]
    public int  touchCat;
    void Start()
    {
        touchCat=0;
    }
    void Update()
    {
        if(touchCat>=2)
        {
            SceneManager.LoadScene("gameOver");  
        }
    }
    
   
  void OnTriggerEnter2D(Collider2D col)
  {
      if (col.tag == "Cat")
    {
       touchCat+=1;
      
    }
  }
}
