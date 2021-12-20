using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingButton: MonoBehaviour
{
    // Start is called before the first frame update
     public void Object_Toggle(GameObject setting_Button)
    {   
        // appear_toggle = !appear_toggle;
        // Debug.Log("我正在prefab" + appear_toggle);
       setting_Button.SetActive( !setting_Button);
      
    }
}
