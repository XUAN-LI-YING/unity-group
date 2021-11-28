using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rollanimation : MonoBehaviour
{
   
     void AnimationEnd() 
     {
     Destroy (gameObject); //當動畫結束消滅此爆炸物件
    
     }  
}
