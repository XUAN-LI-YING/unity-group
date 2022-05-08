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
    Animator animator;
    public bool isCooling = false;//是否為冷卻
    public bool isLaunch ; //可否觸發 true為可發動 false為已使用

    private bool Built;
    private bool IsLadder;
    int i = 0;
    public static coldtime instance;
    //private Player Build;
    
    // Start is called before the first frame update
    
    void Start()
    {
        //instance = this;
        //Switch = GameData.Switch;
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
        Built = GameData.Built;
        IsLadder = GameData.IsLadder;
        //Debug.Log(Built + "02");
        //Switch = GameData.Switch;
        //Debug.Log("Player.Switch="+GameData.Switch);
        //Debug.Log(Switch);
        if(IsLadder == false)
        Built = false;

        if(Built == true)
        CD();
        //AFbuild();
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

                //Player.instance.LaunchTrap();
                
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

    void CD()
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
    }

    void AFbuild()
    {
        //Debug.Log(Switch);
        //if(Built == true)
        {
            //Debug.Log(Built + "02");
            if(isLaunch == true)
            {
                return;
            }
            //Build.instance;
            isCooling = true;   
        }
    }

    public void OnShow()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            
            //if(Switch == true)
            AFbuild();
            /*if(Switch == true)
            {
                if(isLaunch == true)
                {
                    return;
                }
                //Build.instance;
                isCooling = true;
            }*/
            //Debug.Log(Switch);             
        }
    }
}
