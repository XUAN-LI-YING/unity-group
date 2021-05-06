using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{  
   //血條設定，current為當前血條
   public const int maxHealth=100;
   public int currentHealth=maxHealth;
   //血量條(不懂)
   public RectTransform HealthBar,Hurt;
    // Update is called once per frame
    void Update()
    {   //當物體碰到陷阱，扣10滴血
        /* void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag=="trap")
            {
                currentHealth=currentHealth-10;
            }
        } */
        if(Input.GetKeyDown(KeyCode.H))
        {
            currentHealth=currentHealth-10;
        }
            //將綠色血條同步到當前血量長度
            HealthBar.sizeDelta=new Vector2(currentHealth,HealthBar.sizeDelta.y);
            //紅色血條漸減到綠色長度
            if(Hurt.sizeDelta.x>HealthBar.sizeDelta.x)
            {   
                Hurt.sizeDelta+=new Vector2(-1,0)*Time.deltaTime*10;
            }
        
        
    }
}
