using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class bigEnemyPra : MonoBehaviour
{
  public static bigEnemyPra instance;
  public GameObject catPrefab;       //第一關
   public GameObject bigPrefab;        //第二關
  
//   public static bigEnemyPra Instance;
  // 函式 instance公開使用繼承

  [Header("每__秒製造敵人")]
  public int createtime;

  [Header("已經製造幾隻敵人")]
  public int createNumber;

  [Header("是否要繼續製造敵人")]
  public bool createEnemy=true;

  [Header("顯示已經打死敵人數量的ui")]
  public Text ui_value;   // p.s 命名盡量要明確 _做什麼_的數值 e.g countenemy_value committed by 01
  
  [Header("已經打死敵人的數量")]
   public int enemyDie;

  [Header("顯示獲得多少魔力的ui")]
  public Text addfear_value;   //例如這樣子

  [Header("敵人產生計時器")]
  public float delta ;

  [Header("特效顯示時間長度")]
  public int count;
  
  void Start(){

    instance = this;
    delta = 0;
    createtime = 5; 
    createNumber=1;
    // Instance=this;
    enemyDie=0;
    addfear_value.text = "";
    count = 0;
  }
 
  
  // 怪物產生位置
  void Update()
  {
    
    if(createEnemy==true)
    {
        create();
    }
     
    


  }

  // void create()           //第一關       
  // {
  //   this.delta += Time.deltaTime;
  //   if (this.delta > createtime)
  //   {
  //     if(createNumber<11) //總共只能複製出10隻
  //     {
  //        GameObject go = Instantiate(catPrefab) as GameObject;
  //       //定義產生位置
  //       go.transform.position = new Vector3(-104, 25f, 0);
  //       this.delta = 0;
  //       createNumber+=1;

  //     }
  //     else{
  //       createEnemy=false;
  //     }
    
      
  //   }
  // }

 void create()           //第二關       
  {
    this.delta += Time.deltaTime;
    if (this.delta > createtime)
    {
      if(createNumber<6) //大隻總共只能複製出5隻
      {
         GameObject go = Instantiate(bigPrefab) as GameObject;
        //定義產生位置
        go.transform.position = new Vector3(-104, 27f, 6);
        this.delta = 0;
        createNumber+=1;

      }
      else if(createNumber>=6 && createNumber<=15)
      {
         GameObject go = Instantiate(catPrefab) as GameObject;
        //定義產生位置
        go.transform.position = new Vector3(-104, 25f, 0);
        this.delta = 0;
        createNumber+=1;
      }
      else{
        createEnemy=false;
      }
    
      
    }
  }


  public void addEnemyDie()
  {
    enemyDie+=1;
    ui_value.text = enemyDie.ToString() + ""; //將死掉的敵人數量變成text檔
    fearBar.instance.Increase();  
    // 放一個超大ui顯示砍死+20魔力值 XD
     InvokeRepeating("showHide", 0.3f, 0.3f);
    // 人眼頻率大概 25 fps  
    //然後再去操控他的透明度 我好厲害
    //想法來自 ae 內建 flicker 特效 
    // addfear_value.text = "";
    // if(enemyDie>=10)                                  //第一關
    // {
    //   SceneManager.LoadScene("gameWin"); 
    // }

    if(enemyDie>=15)                                    //第二關
    {
      SceneManager.LoadScene("gameWin"); 
    }

  }
  void showHide() {

    

    if (addfear_value.text == ""){ 

      addfear_value.text = "砍死+20魔力值!!!"; 

    }else{ 

    addfear_value.text = ""; 

    }
    count += 1;
    // Debug.Log(count);
    if(count == 10){

      addfear_value.text = "顯示一秒"; 
      CancelInvoke("showHide");
      addfear_value.text = ""; 
      count = 0;

    };
  }
}
