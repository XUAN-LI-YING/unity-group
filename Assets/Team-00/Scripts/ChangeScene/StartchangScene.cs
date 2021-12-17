using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

}
