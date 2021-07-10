using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollTouch : MonoBehaviour
{
    public GameObject aniroll;
   //  public GameObject rollCard;
   // Vector3 move;
   // void start()
   //  {
   //      move = gameObject.transform.position;
   //  }

   
    
        //當捕獸夾圖卡觸碰敵方，則呼叫撞木動畫
        public void OnTriggerEnter2D(Collider2D col)
        {
           if (col.gameObject.tag == "Cat")
           {  
         //   Instantiate(aniroll, new Vector3(move.x+25f, move.y+30f, move.z), gameObject.transform.rotation);
         //   Instantiate(aniroll,new Vector3(40,20,0),Quaternion.Euler(0,0,0),rollCard.transform);

            Vector3 move = gameObject.transform.position;
            
             move = new Vector3(move.x, move.y+20f, move.z);
            Instantiate(aniroll, move, gameObject.transform.rotation);

           }


         }

    
}
