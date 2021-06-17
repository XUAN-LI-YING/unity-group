using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyButton : MonoBehaviour
{   
    // public GameObject friendly_force;
    // public bool appear_toggle = false;
    //點擊時friendly_force這個空物(並之後掛上friendlyforce物件)會去掛上的物件friendlyforce找到裡面的activeSelf，
    //並把他變否
    public void Object_Toggle(GameObject friendly_force)
    {   
        // appear_toggle = !appear_toggle;
        // Debug.Log("我正在prefab" + appear_toggle);
        friendly_force.SetActive( !friendly_force.activeSelf);
      
    }
}
