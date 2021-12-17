using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//拖曳
public class TrapOnDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    public GameObject Slot;//copytrap
    public Transform originalParent;
    static InventoryManager instance;
    public void OnBeginDrag(PointerEventData eventData)
    {
        originalParent = transform.parent;      //與拖曳之物件交換位置
        transform.SetParent(transform.parent.parent);      //拖動時在其他圖層上
        transform.position = eventData.position;        //隨滑鼠位置拖動
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        /*if(Input.GetMouseButton(0))
        {
            var newSlot = Instantiate(Slot, this.gameObject.transform.position,Quaternion.identity);
            newSlot.transform.SetParent(instance.slotGrid.transform);
        }*/
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject.name == "Item Image") //若物件為Item Image互換位置
        {
            transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform.parent.parent);
            transform.position = eventData.pointerCurrentRaycast.gameObject.transform.parent.parent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.position = originalParent.position;
            eventData.pointerCurrentRaycast.gameObject.transform.parent.SetParent(originalParent);
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            return;
        }

        //if(eventData.pointerCurrentRaycast.gameObject.name == "slot1(Clone)")
        
        transform.SetParent(eventData.pointerCurrentRaycast.gameObject.transform);
        transform.position = eventData.pointerCurrentRaycast.gameObject.transform.position;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
            
        
        
    }

    
}
