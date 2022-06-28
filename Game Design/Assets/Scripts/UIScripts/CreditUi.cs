using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditUi : MonoBehaviour
{
    public GameObject ui;

    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf);

    }

}
