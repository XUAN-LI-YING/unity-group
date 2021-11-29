using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory trapBox;
    //public Inventory trapselect;
    public GameObject slotGrid;
    //public Slot slotPrefab;
    public GameObject emptySlot;
    public GameObject emptySlot2;
    public GameObject emptySlot3;
    public GameObject emptySlot4;
    public GameObject emptySlot5;
    public GameObject emptySlot6;
    public Text itemInformation;
    public List<GameObject> slots = new List<GameObject>();
    //public GameObject SubTrap;//copy
    public Item Slot;
    //public Item Slot2;

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

    
    /*void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(emptySlot, this.transform.position,Quaternion.identity);
        }
    }*/
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
        }

        for (int i = 0; i <instance.trapBox.itemList.Count; i++)
        {
            
            //CreateNewItem(instance.trapBox.itemList[i])       //重新創造列表中物件
            
            instance.slots.Add(Instantiate(instance.emptySlot));
            instance.slots.Add(Instantiate(instance.emptySlot2));
            instance.slots.Add(Instantiate(instance.emptySlot3));
            instance.slots.Add(Instantiate(instance.emptySlot4));
            instance.slots.Add(Instantiate(instance.emptySlot5));
            instance.slots.Add(Instantiate(instance.emptySlot6));
            instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            if(i==0)
            {
                //instance.slots.Add(Instantiate(instance.emptySlot));
                instance.slots[0].GetComponent<Slot>().SetupSlot(instance.trapBox.itemList[0]);
            }
            
            if(i==1)
            {
                //instance.slots.Add(Instantiate(instance.emptySlot2));
                instance.slots[1].GetComponent<Slot2>().SetupSlot(instance.trapBox.itemList[1]);
            }
            
            if(i==2)
            {
                instance.slots[2].GetComponent<Slot3>().SetupSlot(instance.trapBox.itemList[2]);
            }

            if(i==3)
            {
                instance.slots[3].GetComponent<Slot4>().SetupSlot(instance.trapBox.itemList[3]);
            }

            if(i==4)
            {
                instance.slots[4].GetComponent<Slot5>().SetupSlot(instance.trapBox.itemList[4]);
            }

            if(i==5)
            {
                instance.slots[5].GetComponent<Slot6>().SetupSlot(instance.trapBox.itemList[5]);
            }
        }


    }




    


}
