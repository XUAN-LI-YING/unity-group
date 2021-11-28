using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigTrap : MonoBehaviour
{
    public GameObject aniBig;
    

    void Start() 
    {
      
    }

       
        public void OnTriggerEnter2D(Collider2D col)
        {
           if (col.gameObject.tag == "Cat")
           {  
               Debug.Log("撞到了啦");
                 Debug.Log(Screen.currentResolution);
                //1920 x 1080 @ 60Hz

                //Output the current screen window width in the console
                Debug.Log("Screen Width : " + Screen.width);
                //Screen Width : 1920

                //Output the current screen window height in the console
                Debug.Log("Screen Height : " + Screen.height);
                //Screen Height : 1080
                Vector3 move = gameObject.transform.position;
            
                move = new Vector3(move.x, move.y+10f, move.z);
                Instantiate(aniBig, move, gameObject.transform.rotation);
                
              }
              
           

         }
}

