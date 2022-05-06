﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class friendlyButton : MonoBehaviour
{   
    public static friendlyButton instance;
    // public GameObject friendly_force;
    // public bool appear_toggle = false;
    //點擊時friendly_force這個空物(並之後掛上friendlyforce物件)會去掛上的物件friendlyforce找到裡面的activeSelf，
    //並把他變否

    public GameObject turnonoff;
    public Sprite StopbuttonImage;
    public Sprite OrginalbuttonImage;
    public Button button;

    public int turnon = 1;


    
    public void Object_Toggle(GameObject friendly_force)
    {   
        // appear_toggle = !appear_toggle;
        // Debug.Log("我正在prefab" + appear_toggle);
        friendly_force.SetActive( !friendly_force.activeSelf);
      
    }
    void Update() {
        
    }
    public void Start() {

         instance = this;

        turnonoff.SetActive(true);

        InvokeRepeating("AutocostFear", 1, 2);

        button.onClick.AddListener(TurnEffect);

        

    }
    public void TurnEffect()
    {
    Debug.Log(turnonoff.activeSelf); 
    if (!turnonoff.activeSelf)
    {
        button.image.sprite = StopbuttonImage;
        turnon = 2;
        Debug.Log($"關閉友軍扣魔力"); 
        // fearBar.instance.Decrease01(); 
            CancelInvoke("AutocostFear");

       
     
    }
    else if (turnonoff.activeSelf)
    {
        button.image.sprite = OrginalbuttonImage;
        turnon = 1;
        InvokeRepeating("AutocostFear", 4, 2);
    }
    else{};
    
    
    


    
    }
    public void AutocostFear()
    {
    Debug.Log($"出動友軍"); 
    fearBar.instance.Decrease01(); 
    }

}
