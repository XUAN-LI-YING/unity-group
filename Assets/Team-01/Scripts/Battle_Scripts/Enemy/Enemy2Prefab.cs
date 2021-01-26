using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Prefab : MonoBehaviour
{
    public GameObject smallEnemy01;
    // Start is called before the first frame update
    void Start()
    {
         GameObject go =Instantiate(smallEnemy01) as GameObject;
         go.transform.position=new Vector3(-180,35,0);
    }

    // Update is called once per frame
    void Update()
    {
        //討論產生敵人頻率以及寫法
        
    }
}
