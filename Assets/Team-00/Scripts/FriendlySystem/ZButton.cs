using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZButton : MonoBehaviour
{
    private Button thisButton;

    private void Start()
    {
        PowerButton.PowerButtonClicked += TurnButtonOnAndOff;
        thisButton = GetComponent<Button>();
    }

    private void TurnButtonOnAndOff(bool isOn)
    {
        thisButton.interactable = isOn;
    }

    private void OnDestroy()
    {
        PowerButton.PowerButtonClicked -= TurnButtonOnAndOff;
    }
}
