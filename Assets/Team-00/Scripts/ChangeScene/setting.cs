using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setting : MonoBehaviour
{
    Coroutine c=null;
    public void showPop(GameObject g)
    {
        if(c!=null)
        {
            StopCoroutine(c);
            StopCoroutine(Pop(g,Vector3.one));
        }
    }
    public void hidePop(GameObject g)
    {
        if(c!=null)
        {
            StopCoroutine(c);
            StopCoroutine(Pop(g,Vector3.zero));
        }
    }
    IEnumerator Pop(GameObject g,Vector3 v3){
        float i=0;
        while(i<1)
        {
            i+=Time.deltaTime;
            g.transform.localScale=Vector3.Lerp (g.transform.localScale,v3,i);
            yield return new WaitForFixedUpdate();
        }
        c=null;
    }

}
