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

   
        // if (startAddFear == true)
        // {
        //   AutoAddFear();  
        // }
        
    
    
    
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

       InvokeRepeating("AutoAddFear", 1, 1);  
        //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。

    }

 
    
    public void Decrease()
    {
        Debug.Log("正在耗費恐懼!!");
        Debug.Log($"此動作耗費了{costvalue}恐懼值");

        points = points - costvalue;
        ui_value.text = $"恐懼值下降中!!\n 目前存量={points}";
        ui_fillBar.fillAmount = points ;              
    }

    // //When pressing the Increase key
    public void Increase()
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
 

        
          
                    
    }
    void AutoAddFear()
    {

 
        timeToAdd -= 1;
        ui_countvalue.text = timeToAdd.ToString() + "sec";
        
        if (timeToAdd <= 0)
        {
        CancelInvoke("AutoAddFear");
        ui_countvalue.text =  " ☝( ◠‿◠ )☝ sec";
        points = points + autoAddValue;
        ui_value.text = points.ToString();
        
        // startAddFear = false;
        StartCoroutine(DelayAfterAdd()); 
 
        }

        
        // 顯示倒數幾秒增加恐懼數值 
        Debug.Log($"{timeToAdd}");


    
    }


    IEnumerator DelayAfterAdd(){
    yield return new WaitForSeconds(delayBetweenAdd);
        // startAddFear = false;
        timeToAdd = 4;  

        InvokeRepeating("AutoAddFear", 1, 1); 
    
    // ui_countvalue.text = $"add {autoAddValue}\nAllPoints={points}";  
    }





}
