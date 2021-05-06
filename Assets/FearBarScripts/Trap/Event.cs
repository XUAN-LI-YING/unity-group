using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Event : MonoBehaviour
{
    
    [SerializeField] 
    private Rigidbody2D rb;
     [SerializeField] 
    private Animator anim;  
    
    public Collider2D coll;
    public int fearvalue;

    // Start is called before the first frame update
    void Start()
    {
        // fearvalue = Getscript <>(); 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {

    
        if (other.tag == "Enemy")
        {
            fearvalue += 1;

            Debug.Log(coll);
            Debug.Log(fearvalue);
            
            fearBar.instance.Increase();
                
                

            // Destroy(other.gameObject);

        }
    }

    

}
