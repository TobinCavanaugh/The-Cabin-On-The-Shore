using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PlayerInteractable : MonoBehaviour
{
    public PlayerEventManager pm;
    public KeyCode keybind;
    private string a;
    private string text = "Press E to curse";
    public bool interacted;
    public GameObject staticSound;
    public AudioSource deactivateSound;
    public PlayerCameraShaker playerCameraShaker;

    void Start() {
        a =  keybind.ToString();
        text = "Press " + a + " to curse";
        interacted = false;
    }

    void OnTriggerStay(Collider other){
        if(other.gameObject.tag.Equals("Player") && interacted == false){
            if(Input.GetKey(keybind)){
                interacted = true;
                StartCoroutine(UpdateText());
            }
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.Equals("Player") && interacted == false){
            pm.ChangeMessage(text);
        }
    }

    void OnTriggerLeave(Collider other){
        if(other.gameObject.tag.Equals("Player") && interacted == false){
            pm.ChangeMessage("");
        }
    }

    IEnumerator UpdateText(){
        pm.UpdateTotemCount();        
        playerCameraShaker.Shake();

        if(pm.totemCount > 2){
            pm.ChangeMessage("͜G͢e͞t͜ t̴h̕e̷  g̨u͏n̕");
            pm.DisableHouseLights();
            Debug.Log("aa");
            StopCoroutine(UpdateText());
        } else {
            pm.ChangeMessage(pm.totemCount + "/3 totems found");
            yield return new WaitForSeconds(0.1f);            
        }

        staticSound.SetActive(false);
        deactivateSound.Play();
    }

    [Button("UpdateTheThing")]
    public void UpdateText1(){
        interacted = true;
        StartCoroutine(UpdateText());
    }

}
