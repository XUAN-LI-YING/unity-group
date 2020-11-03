using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallcreater : MonoBehaviour
{
    public GameObject Wall;
    public GameObject Wallup ;
    // Start is called before the first frame update
    void Start()
    {
          Instantiate(Wall, new Vector3(48, 15, 0), Quaternion.identity);
          Instantiate(Wallup, new Vector3(0, 33, 0), Quaternion.identity);
          Instantiate(Wall, new Vector3(-48, 15, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
