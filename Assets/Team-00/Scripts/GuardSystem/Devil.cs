using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Devil : MonoBehaviour
{

    
    [Header("撞到敵軍次數")]
    public int  touchCat;
    public Animator playerAni;
    public bool IsAttacking;
    void Start()
    {
      IsAttacking = false ;
        touchCat=0;
    }
    void Update()
    {
        if(touchCat>=2)
        {
            SceneManager.LoadScene("gameOver");  
        }

        if(IsAttacking==true)
        {
            if(playerAni.GetInteger("status")==0)
              
                playerAni.SetInteger("status",1);
                // Debug.Log("IsAttacking");
         
        }
        else
        {
            if(playerAni.GetInteger("status")==1)
            {   
                playerAni.SetInteger("status",0);
            }
        }
    }
    
   
  void OnTriggerEnter2D(Collider2D col)
  {
      if (col.tag == "Cat")
    {
       touchCat+=1;
       IsAttacking = true ; 
        Invoke("stop", 2f);
      
    }
    if (col.tag == "bigEnemy")
    {
       touchCat+=1;
       IsAttacking = true ; 
       Invoke("stop", 2f);
      
    }
     if (col.tag == "DevilEnemy")
    {
       touchCat+=2;
       IsAttacking = true ; 
      Invoke("stop", 2f);
    }
  }

  //  void OnTriggerExit2D(Collider2D col)
  // {
  //     if (col.tag == "Cat")
  //   {
  //      IsAttacking = false ;
      
  //   }
  //   if (col.tag == "bigEnemy")
  //   {
  //     IsAttacking = false ; 
      
  //   }
  //    if (col.tag == "DevilEnemy")
  //   {
  //     IsAttacking = false ; 
      
  //   }
  // }

  void stop()
  {
    IsAttacking = false ;
  }
}
