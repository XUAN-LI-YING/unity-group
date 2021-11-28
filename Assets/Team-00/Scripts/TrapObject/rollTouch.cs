using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollTouch : MonoBehaviour
{
    public GameObject aniroll;
    public int rollTime;//碰到滾筒次數

    void Start() 
    {
      rollTime = 0;
    }

        //當滾筒圖卡觸碰敵方，則呼叫撞木動畫
        public void OnTriggerEnter2D(Collider2D col)
        {
           if (col.gameObject.tag == "Cat")
           {  
              rollTime +=1;

              switch(rollTime)
              {
                case 1 :
                Vector3 move = gameObject.transform.position;
            
                move = new Vector3(move.x, move.y+25f, move.z);
                Instantiate(aniroll, move, gameObject.transform.rotation);
                break;

                case 2 :
                rollTime=0;
                break;
              }
              Debug.Log("碰撞roll第"+(rollTime)+"次");
            
            

           }


         }

    
}
