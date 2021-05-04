using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BloodController : MonoBehaviour
{
  public static BloodController instance;

  public int hp;
  public float max_hp;
  public Image ui_fillBar;

  public GameObject MONSTER;

  // Start is called before the first frame update
  public void Start()
  {
    // float ratio = ((float)hp / (float)max_hp);
    instance = this;

    Debug.Log($"血量狀態：{hp}/{max_hp}");

  }

  // Update is called once per frame
  void Update()
  {
    float fillAmount = hp / max_hp;

    ui_fillBar.fillAmount = fillAmount;



    if (hp <= 0)
    {
      Destroy(MONSTER);
    }

  }
  public void Costblood()
  {
    float fillAmount = hp / max_hp;
    hp -= 30;
    ui_fillBar.fillAmount = fillAmount;
    Debug.Log($"血量狀態：{hp}/{max_hp}");

  }
}
