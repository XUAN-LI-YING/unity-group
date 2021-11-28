using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boomAnimation : MonoBehaviour
{
   
     void AnimationEnd() 
     {
     Destroy (this.gameObject); //當動畫結束消滅此爆炸物件
    
     }  
}
