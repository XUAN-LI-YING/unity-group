﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class StartchangScene : MonoBehaviour
{
    public void PlayGame()
    {
       SceneManager.LoadScene("Loading");
    }
    public void Treach()  //這應該是 Teach？ 可以載這個 vscode 套件 https://marketplace.visualstudio.com/items?itemName=streetsidesoftware.code-spell-checker
    {
       SceneManager.LoadScene("TeachingSlide");
    }
    

    public void QuitGame()
   {
       Application.Quit();
      // EditorApplication.isPlaying = false;
   }

    public void LoadScene(string sceneName)
    {
       SceneManager.LoadScene(sceneName);
    }

}
