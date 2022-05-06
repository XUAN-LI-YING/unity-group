using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Changimage : MonoBehaviour
{
    public Sprite newButtonImage;
    public Button button;
    void Start()
    {

    }
    void Update()
    {

    }
    public void ChangeButtonInage()
    {

        button.image.sprite = newButtonImage;
    }


}