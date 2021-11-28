
using UnityEngine;

public class magicTrap2 : MonoBehaviour
{
     public GameObject Ani;

    void OnMouseDown()
    {
        //     Debug.Log("按到我了");
            Instantiate(Ani, gameObject.transform.position, gameObject.transform.rotation);
            
            Destroy(this.gameObject);
        
    }
}
