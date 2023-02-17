using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerEventManager : MonoBehaviour
{
    public int totemCount = 0;
    public TextMeshProUGUI tmp;
    private string inString;
    public GameObject[] houseLights;
    public bool hasGun = false;

    public void UpdateTotemCount(){
        totemCount++;
        Debug.Log(totemCount);
    }

    public void ChangeMessage(string inString_){
        
        StopAllCoroutines();
        
        inString = inString_;
        StopCoroutine(TypeWrite());
        tmp.text = "";
        StartCoroutine(TypeWrite());
    }

    IEnumerator TypeWrite(){
        for(int i = 0; i < inString.Length; i++){
            tmp.text = inString.Substring(0, i);
            yield return new WaitForSeconds(.1f);
        }
        tmp.text = inString;
    }

    
    public void DisableHouseLights() {
        for(int i = 0; i < houseLights.Length; i++) {
            houseLights[i].SetActive(false);
        }
    }

    public void EndGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(2);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
