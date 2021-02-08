﻿using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class QTE : MonoBehaviour 
{

    //Time 設置判斷時間參數
    [Header("Time")]
    public float maxTimeToClick;
    float timeToClick;
    public float delayBetweenClick;
    public int playtime;
    [Range(0,100)]
    public float timeRangeToClick_Min, timeRangeToClick_Max;

    //UI 介面顯示
    [Header("UI")]
    public Image ui_fillBar;
    public Image ui_fillBar_short;
    public Text ui_key;

    //Key handling 產生隨機字母    
    int keyID;
    char[] keys= "ZXCVBNM".ToCharArray();    
    bool waitingForInput = false;
    // bool waitingReturnBack = false;


    //Other 得分數
    [Header("Others")]
    public int points;    

    void Update()
    {        
        if (waitingForInput){
        CheckingForInput();

        }
    

     
    }

    //Start the game
    public void StartGame()
    {
        playtime = 0;
        //Reset the click timer
        // 重置計時器
        timeToClick = 0;        
        //Assign a random ID for the key
        //隨機產生字母
        keyID = Random.Range(0, keys.Length);        
        //Write the key on the UI (according to the chosen keyID)
        //顯示隨機產生字母
        ui_key.text = keys[keyID].ToString();
        //Reset the points
        //重置分數
        points = 0;

        //Enable the boolean to check the input
        // 開始偵測鍵盤輸入
        waitingForInput = true;
    }
        //Checking the input for key
    void CheckingForInput()
    {
        //Increase the time click key
        // 計時器計時
        timeToClick += Time.deltaTime;
        //Convert the timeToClick to match the 0-1 ratio
        // 計時器轉換成圖像表示
        float fillAmount = timeToClick / maxTimeToClick;
        //Apply the ratio to the bar UI fill amount
        // 載入 UI 物件
        ui_fillBar.fillAmount = fillAmount;
        float v = (float)(fillAmount - 0.03);
        // 新增導引線遮罩
        ui_fillBar_short.fillAmount = v;
        //    If time to click passes the total time to Click Fail
        // 超過時間輸入 = 導引線至終點
        if (timeToClick > (maxTimeToClick +1) )
            {    
            waitingForInput = false;
            // timeToClick = 0;
            // waitingReturnBack = true;
            //Debug.Log($"waiting next");
            playtime += 1;
            ui_key.text = $"Miss\n失敗第{playtime}次";
            StartCoroutine(DelayAfterFailed());   
            }
        //Check all keyboard input
        // 確認所有按鍵輸入
        foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
        {
            // kcode.ToString().Length==1 &&

            if ( Input.GetKeyDown(kcode) )
            {
                if (char.Parse(kcode.ToString()) == keys[keyID] && IsInRange() )
                    {
                    //Debug.Log($"Correct check");
                    
                    Correct();
                    }
                else
                {
                                   
                //If it's not the same call Failed method
                  
                    //Debug.Log($"failed key");
                    
                    Failed(); 
                }    
                
 
           
            }




                     
        }
         if (playtime > 2)
        {
            waitingForInput = false;
            timeToClick = 0;

            ui_key.text = $"還敢失敗rr\n失敗第{playtime}次";
            Debug.Log("END QTE");
            // QTE 無效扣恐懼值

        }
    }

    //Check if in range of time input
    // 確認是否在正確範圍輸入
    bool IsInRange()
    {
        //Getting the 0-1 value then x100 to make equivalent to 100%
        
        float currentRatio = (timeToClick / maxTimeToClick)*100;
        //Check if the current time ratio is between the Min and the Max
        if (currentRatio > timeRangeToClick_Min && currentRatio < timeRangeToClick_Max)
        {
          //Debug.Log(currentRatio);            
          //Debug.Log(timeRangeToClick_Min);
          //Debug.Log(timeRangeToClick_Max);
         

            //Debug.Log($"IsInRange-true");
            return true;
            
            
        }

            
        else
        //Debug.Log(currentRatio);            
        //Debug.Log($"IsInRange-false");
           return false;
           
    }

    //When pressing the correct key
    void Correct()
    {
        waitingForInput = false;
        // 顯示成功並落在哪個區間
        //Debug.Log($"Correct Key");
        //Debug.Log($"Clicked at ratio {(timeToClick / maxTimeToClick) * 100}");
        //Disable the boolean for input check
        //停止偵測鍵盤輸入
        
        //Gain point
        // 得分數+1
        points++;
        //Write points on the UI
        // 顯示成功共得幾分
        ui_key.text = $"獲得 {points} 分";        
        //Reset the bar
        // 重置導引線
        ui_fillBar.fillAmount = 0;
        //增加恐懼值
        // call fearbar script
        
        fearBar.instance.Increase();


        
        //Call the delay before next key
        // 開始等待下次判斷時間
        StartCoroutine(DelayAfterCorrect());           
    }   

    IEnumerator DelayAfterCorrect()
    {
        //Wait (delayBetweenClick) seconds
        // 輸入等待時間
        yield return new WaitForSeconds(delayBetweenClick);
        //Reset the click timer
        // 重置計時器
        timeToClick = 0;
        //Assign a random ID for the key
        keyID = Random.Range(0, keys.Length);
        //Write the key on the UI (according to the chosen keyID)
        ui_key.text = keys[keyID].ToString();

        //Enable the boolean to check the input
        waitingForInput = true;
        
    }
    IEnumerator DelayAfterFailed()
    {
        yield return new WaitForSeconds(delayBetweenClick);
 

         //Reset the click timer
        // 重置計時器
        timeToClick = 0;
        //Assign a random ID for the key
        keyID = Random.Range(0, keys.Length);
        //Write the key on the UI (according to the chosen keyID)
        ui_key.text = keys[keyID].ToString();

        //Enable the boolean to check the input
        waitingForInput = true;

    }
   
      //When clicking the wrong key
    void Failed()
    {
         waitingForInput = false;
        // 顯示失敗並落在哪個區間
        Debug.Log("lose");
        Debug.Log($"Clicked at ratio {(timeToClick / maxTimeToClick) * 100}");
        //Stop the boolean for input check
        //停止偵測鍵盤輸入
       
        //Write losing text on UI
        // 顯示失敗 
        playtime += 1;
        ui_key.text = $"Miss\n失敗第{playtime}次";
        //Reset the bar
        // 重置導引線
        ui_fillBar.fillAmount = 0; 
  
        StartCoroutine(DelayAfterFailed());                   
    }





}
