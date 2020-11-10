using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class fearBar : MonoBehaviour 
{
    // 時間參數
    [Header("Time")]
    public int timeToAdd;
    public int timePress;
    public float delayBetweenAdd;

    // 恐懼最大最小數值
    [Range(0,100)]
    public float value_Min, value_Max;



    //各種 UI 
    [Header("UI")]
    public Image ui_fillBar;
    public Text ui_value;
    public Text ui_addvalue;
    public Text ui_costvalue;  
    public Text ui_countvalue;

    
    // bool startAddFear = true;
    //改用滑鼠觸發
    bool waitingForInput = false;
    bool createMonster = false;
    bool combo = false;


    //Other 反應事件
    [Header("FearEvent")]
    public int points;
    public int autoAddValue;
    public int addValue;   
    public int costvalue;


    // 持續偵測有無事件
    void Update()
    {        
    
     if (waitingForInput){

       CheckingForInput();
    
    
    }
       
    }

    //Start the game
    public void StartGame()
    {      
        // points = 0 顯示初始數值
        ui_value.text = points.ToString() + " FearPoint";
        ui_addvalue.text = "add"  + (autoAddValue.ToString())+"points";
        ui_costvalue.text = "- " + (costvalue.ToString());
        ui_countvalue.text = timeToAdd.ToString() + "sec";

        //Enable the boolean to check the input
        //打開偵測事件開關
        waitingForInput = true;

       InvokeRepeating("AutoAddFear", 1, 1);  
        //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。

        // ui_fillBar.fillAmount = points;  
        //將數值 （江直樹) 轉換為圖案
    }

 
    // 顯示耗費多少恐懼
    // When pressing the Increase button
    public void Decrease()
    {
        Debug.Log("正在耗費恐懼!!");
        Debug.Log($"此動作耗費了{costvalue}恐懼值");

        points = points - costvalue;
        ui_value.text = $"恐懼值下降中!!\n 目前存量={points}";
        //update points on the UI
        //更新分數顯示
        ui_fillBar.fillAmount = points ;              
    }

    //When pressing the Increase button

    public void Increase()
    {
        Debug.Log($"增加恐懼！！");
        Debug.Log($"此動作增加了{timePress}恐懼值");
        
        ui_fillBar.fillAmount = points ;  

        points = points + timePress;
        //update points on the UI
        //更新分數顯示
        ui_value.text = $"恐懼值增加{timePress}次!!\n 目前存量={points}";        
            
    }   
     
     
    

    // //Checking the input for button
    void CheckingForInput()
    {
        //創立小怪事件
        if (createMonster){


          Decrease();
        }
        //連段QTE
        if (combo)
        {
         Increase();
        }
          
                    
    }

    // 自動新增恐懼值
    void AutoAddFear()
    {

        //update time on the UI
        //更新倒數顯示
        timeToAdd -= 1;
        ui_countvalue.text = timeToAdd.ToString() + "sec";
    
        //小於零停止倒數計時
        //並秀出 ☝( ◠‿◠ )☝ 文字
        if (timeToAdd <= 0)
        {
        CancelInvoke("AutoAddFear");
        ui_countvalue.text =  " ☝( ◠‿◠ )☝ sec";
        points = points + autoAddValue;
        ui_value.text = points.ToString();
        
        //增加恐懼值
        // startAddFear = false;
        // 上面參數沒用到 bool startAddFea;

        // 延遲幾秒重新計時
        StartCoroutine(DelayAfterAdd()); 
        }

        
        // 顯示倒數幾秒增加恐懼數值 
        Debug.Log($"{timeToAdd}");


    
    }


    IEnumerator DelayAfterAdd(){
    yield return new WaitForSeconds(delayBetweenAdd);
        // 重新設置倒數器
        timeToAdd = 4;  
        InvokeRepeating("AutoAddFear", 1, 1); 
        // 重新啟動計時器

    }





}
