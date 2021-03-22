using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//拖曳
public class TrapOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public Transform originalParent;        //原始所屬位置
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;      //與拖曳之物件交換位置
        transform.SetParent(transform.parent.parent);      //拖動時在其他圖層上
        transform.position = eventData.position;        //隨滑鼠位置拖動
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name == "Item Image")     //拖曳後 物件為ItemImage則兩者交換
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }
        //若slot為空 直接與空物件交換位置
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        //itemList物品儲存位置改變
        

        
        
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    
}
