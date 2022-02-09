using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
public class pauseMenu : MonoBehaviour
{
    public GameObject PauseMenu;
    public void PauseGame()
    {
        PauseMenu.SetActive(true); //顯示暫停畫面
        Time.timeScale=0f;         //遊戲畫面暫停
    }
    public void ResumeGame()
    {
        PauseMenu.SetActive(false); //不顯示暫停畫面
         Time.timeScale=1f;         //遊戲畫面不暫停
    }

     public void QuitGame()
   {
       Application.Quit();
      EditorApplication.isPlaying = false;
   }

    public void LoadScene(string sceneName)
    {
       SceneManager.LoadScene(sceneName);
        Time.timeScale=1f;
    }
}
