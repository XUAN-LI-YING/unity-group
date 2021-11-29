using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapOnRoad : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;
    //public GameObject Slot;//copytrap

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            AddNewItem();
            Destroy(gameObject);
        }          
    }

    /*void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Instantiate(Slot, this.gameObject.transform.position,Quaternion.identity);
        }
    }
    public void AddItem()
    {
        if(Input.GetMouseButton(0))
        {
            Instantiate(Slot, this.gameObject.transform.position,Quaternion.identity);
        }
    }*/

    public void AddNewItem()
    {
        if (!playerInventory.itemList.Contains(thisItem))
        {
            playerInventory.itemList.Add(thisItem);     //添加列表中項目
            //InventoryManager.CreateNewItem(thisItem);     //因InventoryManager 使用OnEnable調用RefreshItem
        }
        else
        {
            thisItem.itemHeld += 1;     //列表持有+1
        }
         
        //這裡有問題
        InventoryManager.RefreshItem();
    }
}
