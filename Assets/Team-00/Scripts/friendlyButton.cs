using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class friendlyButton : MonoBehaviour
{   
    public GameObject friendly_force;
    public void Object_Toggle(GameObject friendly_force)
    {   Debug.Log("我正在prefab");
        friendly_force.SetActive( !friendly_force.activeSelf);
    }
}
