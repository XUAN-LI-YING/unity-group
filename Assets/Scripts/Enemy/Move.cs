using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public bool hitTrap;
    // Start is called before the first frame update
    void Start()
    {
        hitTrap = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitTrap)
        {
            transform.Translate(new Vector2(1, 0) * Time.deltaTime);
        }
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Collection")
        {
            hitTrap = false;
            transform.Translate(new Vector2(0, 0) * Time.deltaTime);
            Debug.Log("hittrap");
            

            Destroy(other.gameObject);

        }
    }
}
