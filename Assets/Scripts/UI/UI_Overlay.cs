using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Overlay : MonoBehaviour
{
    public TextMeshProUGUI tmp;

    // Update is called once per frame
    void FixedUpdate()
    {
        DateTime theTime = DateTime.Now;
        string date = theTime.ToString("yyyy-MM-dd");
        string time = theTime.ToString("HH:mm:ss");
        string datetime = theTime.ToString("yyyy-MM-dd\\THH:mm:ss");

        tmp.text = (time + "\n" + date);
    }
}
