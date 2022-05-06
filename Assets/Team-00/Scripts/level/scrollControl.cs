
using UnityEngine;

public class scrollControl : MonoBehaviour
{
    // Start is called before the first frame update
   public float panSpeed=20f;
   public float panBorderThickness=10f;

   public Vector2 panLimitUP;
   public Vector2 panLimitDown;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos=transform.position;
        if(Input.GetKey("w")||Input.mousePosition.y>=Screen.height-panBorderThickness)
        {
            pos.y+=panSpeed*Time.deltaTime;
        }
         if(Input.GetKey("s")||Input.mousePosition.y<=panBorderThickness)
        {
            pos.y-=panSpeed*Time.deltaTime;
        }

        pos.y=Mathf.Clamp(pos.y,-panLimitUP.y,panLimitDown.y); //限制畫面移動最頂(底)端的位置到哪裡
        transform.position=pos;
    }
}
