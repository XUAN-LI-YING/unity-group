using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory trapselect;
    public GameObject slotGrid;
    //public slot slotPrefab;
    public GameObject emptySlot;
    public Text itemInfromation;

    public List<GameObject> slots = new List<GameObject>();
    /* void Awake()
    {
        if(instance != null)
            Destroy(this);
        instance =this;
    } */

    private void OnEnable()
    {
        //RefreshItem();
        //instance.itemInformation.text = "";
    }

    public static void UpdateItemInfo(string trapDescription)
    {
        instance.itemInfromation.text = trapDescription;
    }

    /* public StateMachineBehaviour void CreateNewItem(Item item)
    {
        Slot mewItem = instance(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
        newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
        CreateNewItem.slotItem = item;
        CreateNewItem.slotImage.sprite = item.itemImage;
        CreateNewItem.slotNum.text = item.itemHeld.ToString();
    } */

    public static void RefreshItem()    //myBag 參數須代換
    {
        for (int i = 0; i < instance.slotGrid.transform.childCount; i++)
        {
            if (instance.slotGrid.transform.childCount == 0)
                break;
            Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
        }

        /* for (int i = 0; i <instance.trapBox.itemList.Count; i++)
        {
            
            //CreateNewItem(instance.trapBox.itemList[i])
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.trapBox.itemList[i]);
        } */


    }




    


}
