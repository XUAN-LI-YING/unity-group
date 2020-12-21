using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory/New Inventory")]//新增物件 prject右鍵>Inventory>New Inventory
public class Inventory : ScriptableObject
{
    public List<Item> itemList = new List<Item>();  //列表新增欄位
}

