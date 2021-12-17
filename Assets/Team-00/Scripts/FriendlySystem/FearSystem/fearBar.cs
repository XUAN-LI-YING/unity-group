using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class fearBar : MonoBehaviour
{
  public static fearBar instance;
  // 時間參數
  [Header("倒數幾秒")]
  public int timeToAdd;
  //倒數幾秒
  [Header("魔法地雷加分用")]
  public int timePress;
  //QTE連擊次數 (變為魔法地累加分用 參數名稱之後要改掉)
  [Header("倒數器間隔時間")]
  public float delayBetweenAdd;
  //倒數器間隔時間
  [Header("扣血動畫延遲時間")]
  public float delaySec;
  // 扣血動畫延遲時間



  // 恐懼最大最小數值
  // [Range(0,100)]
  [Header("魔力數值區間")]
  public int value_Min = 0;
  public float value_Max = 100;


  //各種 UI 
  [Header("UI")]
  public Image ui_fillBar;
  //主要血條 淺綠色
  [Header("增血特效")]
  public Image ui_Addeffect;
  [Header("扣血特效")]
  public Image ui_Hurteffect;
  public Text ui_value;
  public Text ui_addvalue;
  public Text ui_costvalue;
  public Text ui_countvalue;


  public bool waitingForInput = true;
  bool createMonster = false;
  bool combo = false;
  bool Checking = true;


  //Other 反應事件
  [Header("目前存量值")]
  public float points;
  //目前存量值
  [Header("增加值")]
  public int autoAddValue;
  //倒數增加”值“
  public int addValue;
  //一般情況增加值
  public int costvalue;
  //一般情況耗費值
  [Header("出動友軍耗費值")]
  public int eachpresscost;
  //出動友軍耗費值(單次)
  //關聯-- decrease01 函式

  public Button button;
  //開開關關

  // 持續偵測有無事件
  void Update()
  {

    if (waitingForInput)
    {

      CheckingForInput();


    }



  }
  void Start()
  {
    instance = this;
    StartGame();

  }
  void CheckingForInput()
  {
    //創立小怪事件
    if (createMonster)
    {


      Decrease();
    }
    //連段QTE
    if (combo)
    {
      Increase();
    }


    if (Checking)
    {
      //Convert the timeToClick to match the 0-1 ratio
      // 計時器轉換成圖像表示
      // 特效動畫完成後真正數值圖形增加

      float fillAmount = points / value_Max;
      //Apply the ratio to the bar UI fill amount
      // 載入 UI 物件
      ui_fillBar.fillAmount = fillAmount;
    }


    if (points <= value_Min || points >= value_Max)
    {
      CancelInvoke("AutoAddFear");
      waitingForInput = false;
      Checking = false;
      FearEvent();
      
      
      

    }
    else if(points > value_Min && points < value_Max){
        
      button.interactable = true;

    }
 

  }


  //Start the game
  public void StartGame()
  {
    button.interactable = true;
    waitingForInput = true;

    ui_value.text = points.ToString() + "";
    ui_countvalue.text = timeToAdd.ToString() + "sec";

    ui_Hurteffect.fillAmount = ui_fillBar.fillAmount;
    ui_Addeffect.fillAmount = ui_fillBar.fillAmount;

    //Enable the boolean to check the input
    //打開偵測事件開關
    waitingForInput = true;

    InvokeRepeating("AutoAddFear", 1, 1);
    //InokeRepeating 重複呼叫(“函式名”，第一次間隔幾秒呼叫，每幾秒呼叫一次)。
  }


  // 顯示耗費多少恐懼
  public void Decrease()
  {

    Debug.Log($"此動作耗費了{costvalue}魔力值");
    DetectHurt();

    ui_value.text = $"{points}";
    //update points on the UI
    //更新分數顯示


  }
  public void Decrease01()
  {
    Checking = false;
    points = points - eachpresscost;
    float fillAmount = points / value_Max;
    ui_value.text = $"{points}";
    Debug.Log($"出動友軍耗費{eachpresscost}魔力值");
    ui_fillBar.fillAmount = fillAmount;


    StartCoroutine(DelayCostEffect());
    StartCoroutine(RepeatDecrease());
  }

  
  
  //When pressing the Increase button

  public void Increase()
  {
    DetectAdd();

    // Debug.Log($"增加恐懼！！");
    // Debug.Log($"此動作增加了{timePress}魔力值");

    //update points on the UI
    //更新分數顯示

    // if (combo)
    // 有機會用在觸發後播放動畫判斷次數用
    // {
    //   ui_value.text = $"{points}";
    //   Debug.Log($"增加{timePress}!\n目前存量={points}");
    // }
    // 本來用在 QTE 後來取消先留著 特殊加分

    // 其他一般狀況
    // else
    // {

    //   ui_value.text = $"{points}";
    //   // debug 增加{timePress}!!\n目前存量=
    //   Debug.Log($"增加{timePress}!\n目前存量={points}");


    // }






  }



  public void DetectHurt()
  {

    Checking = false;

    points = points - costvalue;
    float fillAmount = points / value_Max;
    ui_fillBar.fillAmount = fillAmount;

    Debug.Log("傷害進行中!!");


    StartCoroutine(DelayCostEffect());
    StartCoroutine(RepeatDecrease());
  }

  // 顯示增加多少恐懼
  // 
  public void DetectAdd()
  {

    Checking = false;

    points = points + timePress;

    float fillAmount = points / value_Max;

    ui_Addeffect.fillAmount = fillAmount;


    // Debug.Log("add進行中!!");

    StartCoroutine(DelayAddEffect());
    StartCoroutine(RepeatDecrease());
  }






  IEnumerator DelayAddEffect()
  {
    yield return new WaitForSeconds(delaySec);
    // 延遲獲得恐懼動畫
    float fillAmount = points / value_Max;
    ui_fillBar.fillAmount = fillAmount;
    waitingForInput = true;

  }
  //這是特效動畫的延遲！！！ 我看錯好幾次了註解一下

  IEnumerator DelayCostEffect()
  {
    yield return new WaitForSeconds(delaySec);
    // 延遲獲得恐懼動畫
    float fillAmount = points / value_Max;
    ui_Hurteffect.fillAmount = fillAmount;

  }


  IEnumerator RepeatDecrease()
  {
    yield return new WaitForSeconds(delaySec);
    Checking = true;

  }

  // //Checking the input for button


  // 自動新增魔力值
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
      waitingForInput = false;
      CancelInvoke("AutoAddFear");
      // ui_countvalue.text = "++魔力值！"
      points = points + autoAddValue;
      float fillAmount = points / value_Max;
      ui_Addeffect.fillAmount = fillAmount;
      ui_value.text = points.ToString();

      StartCoroutine(DelayAddEffect());
      // 兩個delay搞錯.... 這是特效(effect)的delay 

      // 延遲幾秒重新計時 time delay 
      StartCoroutine(DelayAfterAdd());
    }


    // 顯示倒數幾秒增加恐懼數值 
    // Debug.Log($"{timeToAdd}");



  }


  IEnumerator DelayAfterAdd()
  {
    yield return new WaitForSeconds(delayBetweenAdd);
    // 重新設置倒數器
    timeToAdd = 4;
    InvokeRepeating("AutoAddFear", 1, 1);
    // 重新啟動計時器

  }


  IEnumerator RunSecvalue()
  {
    yield return new WaitForSeconds(delayBetweenAdd);
    ui_fillBar.fillAmount = 0;
    // 重新設置倒數器
    timeToAdd = 5;
    //增加增魔所需時間  
    ui_countvalue.text = " LEVEL2 (͡° ͜ʖ ͡°)  ";
    InvokeRepeating("AutoAddFear", 3, 1);
    // 重新啟動計時器

  }
  void FearEvent()
  {
    if (points <= value_Min)
    {
      points = 0;
      button.interactable = false;
      Debug.Log($"LOSE！");
      ui_fillBar.fillAmount = 0;

    }
    else if (points >= value_Max)
    {
      points = 100;
      //   Debug.Log($"WIN！");
      ui_fillBar.fillAmount = 1;
      // StartCoroutine(RunSecvalue());


    }
  }
  public void MgmineBuild()
  {
    Checking = false;

    points = points - 20;

    float fillAmount = points / value_Max;
    ui_fillBar.fillAmount = fillAmount;

    Debug.Log("建造陷阱中!");


    StartCoroutine(DelayCostEffect());
    StartCoroutine(RepeatDecrease());
  }
  public void DarktrapBuild()
  {
    Checking = false;

    points = points - 50;

    float fillAmount = points / value_Max;
    ui_fillBar.fillAmount = fillAmount;

    Debug.Log("建造陷阱中!");


    StartCoroutine(DelayCostEffect());
    StartCoroutine(RepeatDecrease());

  }
  public void BigtrapBuild()
  {
    Checking = false;

    points = points - 80;

    float fillAmount = points / value_Max;
    ui_fillBar.fillAmount = fillAmount;

    Debug.Log("建造陷阱中!");


    StartCoroutine(DelayCostEffect());
    StartCoroutine(RepeatDecrease());

  }




}
