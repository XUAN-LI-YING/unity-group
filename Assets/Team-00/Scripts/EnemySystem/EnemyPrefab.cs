using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyPrefab : MonoBehaviour
{
  public static EnemyPrefab instance;
  public GameObject catPrefab;
  
  public static EnemyPrefab Instance;
  // 函式 instance公開使用繼承

  [Header("每__秒製造敵人")]
  public int createtime;

  [Header("已經製造幾隻敵人")]
  public int createNumber;

  [Header("是否要繼續製造敵人")]
  public bool createEnemy=true;

  [Header("顯示已經打死敵人數量的ui")]
  public Text ui_value;

  
  [Header("已經打死敵人的數量")]
   public int enemyDie;

  [Header("計時器")]
  public float delta ;
  
  void Start(){

    instance = this;
    delta = 0;
    createtime = 5; 
    createNumber=1;//計算以複製出幾隻敵人，目前已經有一隻敵人在場面上
    Instance=this;
    enemyDie=0;
  }
 
  
  // 怪物產生位置
  void Update()
  {
    
    if(createEnemy==true)
    {
        create();
    }
     
    


  }

  void create()
  {
    this.delta += Time.deltaTime;
    if (this.delta > createtime)
    {
      if(createNumber<10) //總共只能複製出10隻
      {
         GameObject go = Instantiate(catPrefab) as GameObject;
        //定義產生位置
        go.transform.position = new Vector3(-104, 25f, 0);
        this.delta = 0;
        createNumber+=1;
        //註解 放這邊
        fearBar.instance.Increase();   
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
    if(enemyDie>=10)
    {
      SceneManager.LoadScene("gameWin"); 
    }
  }
}
