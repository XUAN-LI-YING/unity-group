using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class QUIT : MonoBehaviour
{
    // Start is called before the first frame update
   public void QuitGame()
   {
       Application.Quit();
    //    EditorApplication.isPlaying = false;
   }
}
