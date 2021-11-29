using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoolDown : MonoBehaviour
{
    
    public float timer = 2.0f;   //定義冷卻時間
    public float coldTime = 0;        //計時器
    public Image filledImage;      //填充圖
    
    
    public bool isStartTime = false;   //定義標誌量，開始計時
    //GameObject trap = GameObject.FindWithTag("BuildTrap");
    //GameObject[] traps = GameObject.FindGameObjectsWithTag("BuildTrap");
    // Start is called before the first frame update
    public static CoolDown instance;
    void Start()
    {
        instance = this;
        filledImage = transform.Find("FillImage").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Alpha1))
            isStartTime = true;*/
        if (isStartTime)              //當開始計時執行下列代碼
        {
            coldTime += Time.deltaTime;
            filledImage.fillAmount = (timer - coldTime) / timer;
            if(timer<=coldTime)       //判斷是否到達冷卻時間
            {  
                filledImage.fillAmount = 0;//冷卻不顯示
                coldTime = 0;//重置計時器
                isStartTime = false;  //結束計時      
            }//Debug.Log(timer);
            if(filledImage.fillAmount == 0)
            {
                if(SpikedTrapAni.instance.touch == true)
                SpikedTrapAni.instance.bomb();
            }
            //Debug.Log(filledImage.fillAmount);
        }
    }

    
    public void OnShow()               //定義點擊按鈕觸發
    {
                    //當點擊時開始計時
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            isStartTime = true;
        }

        /*if (other.gameObject.CompareTag("Cat"))
        {
            isStartTime = true;
        }*/

    }
    

}
