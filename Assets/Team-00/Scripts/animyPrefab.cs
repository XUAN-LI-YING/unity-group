using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animyPrefab : MonoBehaviour
{
    public GameObject catPrefab;
    float span = 5;
    float delta = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
       this.delta+=Time.deltaTime;
       if(this.delta>this.span){
           this.delta=0;
           GameObject go =Instantiate(catPrefab) as GameObject;
           go.transform.position=new Vector3(-32,-16,0);
       }
       
    }
}
