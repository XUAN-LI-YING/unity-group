using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
public class bntUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject levelMenu;

     
    public void OnPointerEnter(PointerEventData eventData)    //滑鼠移入
    {
       levelMenu.SetActive(true); //顯示關卡畫面
    }

    public void OnPointerExit(PointerEventData eventData)    //滑鼠移出
    {
        levelMenu.SetActive(false); 
    }
     void OnMouseDown()
    {
            levelMenu.SetActive(true);
             
        
    }
   
}
