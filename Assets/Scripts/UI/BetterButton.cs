using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[System.Serializable]
public class BetterButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public TextMeshProUGUI tmp;
    
    public string defaultText = "";
    public string modifiedText = "><";

    public AudioSource as_;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        tmp.text = modifiedText;
        as_.Play();
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("exitt");
        tmp.text = defaultText;
        as_.Play();

    }
}
