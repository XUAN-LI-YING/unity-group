using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//物件資訊
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")] //新增物件 prject右鍵>Inventory>New Item
public class Item : ScriptableObject
{
    public string itmeName;
    public Sprite itemImage;
    public int itemHeld;        //持有數
    
    [TextArea]
    public string itemInfo;

    
}
