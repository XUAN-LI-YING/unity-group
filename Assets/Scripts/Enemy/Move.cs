using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public bool move;
    // Start is called before the first frame update
    void Start()
    {
        move = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.Translate(new Vector2(10, 0) * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collection")
        {
            move = false;
            transform.Translate(new Vector2(0, 0) * Time.deltaTime);
            Debug.Log("stopmove");
            

            // Destroy(other.gameObject);

        }
    }
}
