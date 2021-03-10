using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartQTE : MonoBehaviour
{
  public static StartQTE instance;
  // Start is called before the first frame update
  void Start()
  {
  instance = this;
  
  }

  // Update is called once per frame
  void Update()
  {

    if (Input.GetButtonDown("Jump"))
    {
      Debug.Log($"+1");
      QTE.instance.StartGame();
      // fearBar.instance.StartGame();
    }

  }
  void Detect()
  {

  }
}
