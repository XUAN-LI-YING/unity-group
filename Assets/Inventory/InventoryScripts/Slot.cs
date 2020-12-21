using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    //public Text slotNum;
    public string slotInfo;   //物件資訊 字串

    public GameObject itemInSlot;
    public void  ItemOnClicked()  //按鈕點擊
    {
        
        InventoryManager.UpdateItemInfo(slotInfo);   //更新物件資訊
    }
    
    public void SetupSlot(Item item)
    {
        if (item == null)    //若值為空
        {
            itemInSlot.SetActive(false);    //不顯示
            return;
        }

        slotImage.sprite = item.itemImage;
        //slotNum.text = item.itemHeld.ToString();
        slotInfo = item.itemInfo;


    }


}
