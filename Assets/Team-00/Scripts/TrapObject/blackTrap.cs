using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackTrap : MonoBehaviour
{
    
    public GameObject darkAni;
    public int blackAnimationTime;//是否播放過黑暗陷阱動畫
    void Start()
    {
        blackAnimationTime = 0;
    }

    
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        

            if (other.gameObject.tag == "Cat")
            {
          

              blackAnimationTime+=1;

              switch(blackAnimationTime)
              {
                case 1 :
                Vector3 move = gameObject.transform.position;
            
                move = new Vector3(move.x, move.y+10f, move.z);
                Instantiate(darkAni, move, gameObject.transform.rotation);
                break;

                case 2 :
                 blackAnimationTime =0;
                break;
              }
            }
    }
    
    
}


