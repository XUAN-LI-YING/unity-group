using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiddleManager : MonoBehaviour
{
    static MiddleManager instance;

    public Inventory trapBox;
    //public Inventory trapselect;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInformation;
    public List<GameObject> slots = new List<GameObject>();
    
    void Awake()
    {
        if (instance != null)
            Destroy(this);
        instance = this;   
    }

    /* public static void CreateNewItem(Item item)     //建立新的Item
    {
        Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        newItem.slotItem = item;
        newItem.slotImage.sprite = item.itemImage;
        newItem.slotNum.text = item.itemHeld.ToString();
    } */

    
    private void OnEnable()
    {
        RefreshItem();
        instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string trapDescription)
    {
        
        instance.itemInformation.text = trapDescription;
    }

    /* //public StateMachineBehaviour void CreateNewItem(Item item)
    {
        //Slot newItem = instance(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        //newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        //CreateNewItem.slotItem = item;
        //CreateNewItem.slotImage.sprite = item.itemImage;
        //CreateNewItem.slotNum.text = item.itemHeld.ToString();
    } */ 

    public static void RefreshItem()    //myBag 參數須代換
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)        //銷毀所有子級直到0
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);        //循環到第i個子物件
            instance.slots.Clear();
        }

        for (int i = 0; i <instance.trapBox.itemList.Count; i++)
        {
            
            //CreateNewItem(instance.trapBox.itemList[i])       //重新創造列表中物件
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.trapBox.itemList[i]);
        }


    }
}
