using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour
{
    public static event Action<bool> PowerButtonClicked = delegate { };

    private bool powerOn;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
        powerOn = true;
    }

    private void ButtonClicked()
    {
        powerOn ^= true;
        PowerButtonClicked(powerOn);
    }
}
