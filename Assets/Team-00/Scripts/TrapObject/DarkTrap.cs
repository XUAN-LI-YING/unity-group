using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkTrap : MonoBehaviour
{
    public GameObject enemy;
    bool collision = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        collision = true;
        // Debug.Log("only catch sth");

            if (other.gameObject.tag == "Cat")
            {
            Debug.Log("遇到守衛");

            }
    }
    void Correct()
    {
        Debug.Log("catch enemy");
        fearBar.instance.Increase();



    }
}
