using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class fearBar : MonoBehaviour 
{
    [Header("Time")]
    public int timeToAdd;
    public int timePress;
    public float delayBetweenAdd;

    [Range(0,100)]
    public float value_Min, value_Max;

    //UI
    [Header("UI")]
    public Image ui_fillBar;
    public Text ui_value;
    public Text ui_addvalue;
    public Text ui_costvalue;  
    public Text ui_countvalue;

    
    bool startAddFear = true;
    bool waitingForInput = false;
    bool createMonster = false;
    bool combo = false;


    //Other
    [Header("FearEvent")]
    public int points;
    public int autoAddValue;
    public int addValue;   
    public int costvalue;



    void Update()
    {        
        if (waitingForInput){

       CheckingForInput();


    //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。

    
    
    
    }
     
    // ui_fillBar.fillAmount = points;
    

       
    }

    //Start the game
    public void StartGame()
    {      
        // points = 0;
        ui_value.text = points.ToString();
        ui_addvalue.text = autoAddValue.ToString();
        ui_costvalue.text = costvalue.ToString();
        ui_countvalue.text = timeToAdd.ToString() + "sec";

        //Enable the boolean to check the input
        waitingForInput = true;



       if (startAddFear)
       {
          InvokeRepeating("AutoAddFear", 1, 1);  
          
       }
    }

 
    
    void Decrease()
    {
        Debug.Log("正在耗費恐懼!!");
        Debug.Log($"此動作耗費了{costvalue}恐懼值");

        points = points - costvalue;
        ui_value.text = $"恐懼值下降中!!\n 目前存量={points}";
        ui_fillBar.fillAmount = points ;              
    }

    // //When pressing the Increase key
    void Increase()
    {
        Debug.Log($"增加恐懼！！");
        Debug.Log($"此動作增加了{timePress}恐懼值");
        
        ui_fillBar.fillAmount = points ;  

        points = points + timePress;
        //Write points on the UI
        ui_value.text = $"Total points {points}";        
            
    }   
     
     
    

    // //Checking the input for key
    void CheckingForInput()
    {
        if (createMonster){


          Decrease();
        }
        if (combo)
        {
         Increase();
        }

        if (timeToAdd <= 0)
        {
        StartCoroutine(DelayAfterAdd()); 
 
       
        
        }
        
          
                    
    }
    void AutoAddFear()
    {

        timeToAdd -= 1;
        ui_countvalue.text = timeToAdd.ToString() + "sec";
        // 顯示倒數幾秒增加恐懼數值 
        Debug.Log($"{timeToAdd}");
        
    
    }


    IEnumerator DelayAfterAdd(){
    yield return new WaitForSeconds(delayBetweenAdd);
        startAddFear = false;
        points = points + autoAddValue;
        ui_value.text = points.ToString();
        
    timeToAdd = 10;  
    startAddFear = true;
    // ui_countvalue.text = $"add {autoAddValue}\nAllPoints={points}";  
    }





}
