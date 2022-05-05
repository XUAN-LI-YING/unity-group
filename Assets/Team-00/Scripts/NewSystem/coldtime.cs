using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coldtime : MonoBehaviour
{
    public float timeCount = 0;//計時器
    public float  timeCD = 2.0f;//CD
    public Image filledImage;//遮罩圖片
    //public Text text;//計時文本
    //public Button btn;//按鈕
    public bool isCooling = false;//是否為冷卻
    public bool isLaunch ; //可否觸發 true為可發動 false為已使用
    
    int i = 0;
    public static coldtime instance;
    
    // Start is called before the first frame update
    
    void Start()
    {
        instance = this;
        //filledImage = transform.Find("FillImage").GetComponent<Image>();
    }

    /*public void BtnEvent()
    {
        if(!isCooling)
        {
            image.fillAmount = 1;//圖片fillAmount=1
            image.gameObject.SetActive(true);//顯示圖片
            text.gameObject.SetActive(true);//數字文本
            text.text = timeCD.ToString("f1");
            isCooling = true;
            timeCount = timeCD;
        }
    }*/
    // Update is called once per frame
    void Update()
    {
        
        if(isCooling)
        {
            timeCount += Time.deltaTime;//計時器
            filledImage.fillAmount = (timeCD - timeCount) / timeCD;
            //text.text = timeCount.ToString("f1");
            if(timeCount>=timeCD)
            {
                filledImage.fillAmount = 0;
                timeCount = 0;
                isCooling = false;
                //filledImage.gameObject.SetActive(false);
                //text.gameObject.SetActive(false);
            }
        }

        /*if(isLaunch)
        {
            isCooling = false;
        }*/

        
        if(isCooling == true)
        {
            i += 1; 
            if(i == 1) 
            {
                isLaunch = true;

                Player.instance.LaunchTrap();
                
            }
            
        }
        
        
        
        /*if(!isCooling)
        {
            filledImage.fillAmount = 1;//圖片fillAmount=1
            filledImage.gameObject.SetActive(true);//顯示圖片
            //text.gameObject.SetActive(true);//數字文本
            //text.text = timeCD.ToString("f1");
            isCooling = true;
            timeCount = timeCD;
        }*/
    }

    public void OnShow()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(isLaunch == true)
            {
                return;
            }
            isCooling = true;             
        }
    }
}
