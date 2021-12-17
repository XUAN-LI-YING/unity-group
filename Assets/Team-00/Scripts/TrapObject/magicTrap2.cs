
using UnityEngine;

public class magicTrap2 : MonoBehaviour
{
     public GameObject Ani;

    void OnMouseDown()
    {
             Debug.Log("按到我了");
            Vector3 move = gameObject.transform.position;
            
            move = new Vector3(move.x, move.y+10f, move.z);
            Instantiate(Ani, move, gameObject.transform.rotation);
            //Instantiate(Ani, gameObject.transform.position, gameObject.transform.rotation);
            
            Destroy(this.gameObject);
        
    }
}
