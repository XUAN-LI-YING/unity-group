using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomNumber : MonoBehaviour
{
public static RandomNumber instance;
public int randomnum;

    void Start () {
        
        instance = this;
        RandomPick();

    }
    void Update () {

    
    }
    void RandomPick(){

            
            randomnum = Random.Range(0, 100);

            //偵測是否有存回
            Debug.Log ("randomnum ="+randomnum);
            }

}
