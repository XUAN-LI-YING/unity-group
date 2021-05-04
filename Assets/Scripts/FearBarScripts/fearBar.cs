using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class fearBar : MonoBehaviour
{
  public static fearBar instance;
  // 時間參數
  [Header("Timer")]
  public int timeToAdd;
  //倒數幾秒
  public int timePress;
  //QTE連擊次數 (先留者特殊加分用?)
  public float delayBetweenAdd;
  //倒數器間隔時間
  public float delaySec;
  // 扣血動畫延遲時間



  // 恐懼最大最小數值
  // [Range(0,100)]
  [Header("Value")]
  public int value_Min = 0;
  public float value_Max = 200;


  //各種 UI 
  [Header("UI")]
  public Image ui_fillBar;
  //主要血條 淺綠色
  public Image ui_Addeffect;
  public Image ui_Hurteffect;
  public Text ui_value;
  public Text ui_addvalue;
  public Text ui_costvalue;
  public Text ui_countvalue;


  bool waitingForInput = false;
  bool createMonster = false;
  bool combo = false;
  bool Checking = true;


  //Other 反應事件
  [Header("FearEvent")]
  public float points;
  //目前存量值
  public int autoAddValue;
  //倒數增加”值“
  public int addValue;
  //一般情況增加值
  public int costvalue;
  //一般情況耗費值
  public int eachpresscost;
  //出動友軍耗費值(單次)
  //關聯-- decrease01 函式

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
      FearEvent();
    }
    //判斷晉級或失敗事件  

  }


  //Start the game
  public void StartGame()
  {
    waitingForInput = true;
    // float fillAmount = points / value_Max;
    // points = 0 顯示初始數值
    ui_value.text = points.ToString() + " FearPoint";
    ui_addvalue.text = "add " + (autoAddValue.ToString()) + "points";
    ui_costvalue.text = "- " + (costvalue.ToString());
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
  // When pressing the Increase button
  public void Decrease()
  {

    Debug.Log($"此動作耗費了{costvalue}魔力值");
    DetectHurt();

    ui_value.text = $"魔力值下降中!!\n 目前存量={points}";
    //update points on the UI
    //更新分數顯示


  }
  public void Decrease01()
  {
    Checking = false;
    points = points - eachpresscost;
    float fillAmount = points / value_Max;
    ui_value.text = $"魔力值損耗{eachpresscost}!!\n 目前存量={points}";
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

    if (combo)
    {
      ui_value.text = $"魔力值增加 {timePress} !!\n 目前存量={points}";
    }
    // 本來用在 QTE 後來取消先留著 特殊加分

    // 其他一般狀況
    else
    {

      ui_value.text = $"魔力值增加{timePress}!!\n 目前存量={points}";

      Debug.Log($"{(points / value_Max) * 100}% 魔力值");
    }






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

  public void DetectAdd()
  {

    Checking = false;

    points = points + timePress;

    float fillAmount = points / value_Max;

    ui_Addeffect.fillAmount = fillAmount;


    Debug.Log("add進行中!!");

    StartCoroutine(DelayAddEffect());
    StartCoroutine(RepeatDecrease());
  }






  IEnumerator DelayAddEffect()
  {
    yield return new WaitForSeconds(delaySec);
    // 延遲獲得恐懼動畫

  }

  IEnumerator DelayCostEffect()
  {
    yield return new WaitForSeconds(delaySec);
    // 延遲獲得恐懼動畫
    float fillAmount = points / value_Max;
    ui_Addeffect.fillAmount = fillAmount;
    
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
      CancelInvoke("AutoAddFear");
      ui_countvalue.text = " (͡° ͜ʖ ͡°)  sec";
      points = points + autoAddValue;

      ui_value.text = points.ToString();



      //增加魔力值
      // startAddFear = false;
      // 上面參數沒用到預設是永遠增加;

      // 延遲幾秒重新計時
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
    // 重新設置倒數器
    timeToAdd = 5;
    //增加增魔所需時間  
    ui_countvalue.text = " LEVEL2 (͡° ͜ʖ ͡°)  ";
    InvokeRepeating("AutoAddFear", 5, 1);
    // 重新啟動計時器

  }
  void FearEvent()
  {
    if (points <= value_Min)
    {
      CancelInvoke("AutoAddFear");
      //   Debug.Log($"LOSE！");
      ui_fillBar.fillAmount = 0;

    }
    if (points >= value_Min)
    {
      CancelInvoke("AutoAddFear");
      //   Debug.Log($"WIN！");
      ui_fillBar.fillAmount = 1;
      StartCoroutine(RunSecvalue());


    }

  }




}
