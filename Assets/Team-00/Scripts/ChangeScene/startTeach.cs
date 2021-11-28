using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startTeach : MonoBehaviour
{
//    //切換畫面到gamescene
//    public void ButtonMoveScene(string gamescene) 
//    {
//        SceneManager.LoadScene(gamescene);
//    }
private void TeachScene()
{
    if (Input.GetKeyUp(KeyCode.Space))
    {
        SceneManager.LoadScene("TeachingSlide");
    }
}

}
