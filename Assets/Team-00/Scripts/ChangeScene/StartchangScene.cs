using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class StartchangScene : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("DevilDefend");
    }
    public void Treach()
    {
       SceneManager.LoadScene("TeachingSlide");
    }
    

    public void QuitGame()
   {
       Application.Quit();
      //  EditorApplication.isPlaying = false;
   }

}
