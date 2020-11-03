using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onclick : MonoBehaviour
{
    public GameObject Character01;
    public GameObject PlayerTower;
    public float scale;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) )
        {
        print("放大！"); 
        this.gameObject.transform.localScale += new Vector3(scale/5,scale/5,0f);

        }
    }
    void OnMouseDown()
    {
        GameObject ClonePlayer01 = (GameObject)Instantiate(Character01, PlayerTower.transform.position, new Quaternion(0, 0, 0, 0));
        print("角色：死侍");
       
    }
}
