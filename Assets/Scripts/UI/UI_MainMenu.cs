using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.Rendering.PostProcessing;

public class UI_MainMenu : MonoBehaviour
{
    public void LoadScene(int sceneID){
        Debug.Log("Loading scene " + sceneID);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SceneManager.LoadScene(sceneID);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private bool inSettings = false;
    public GameObject mainMenu;
    public GameObject settingsMenu;

    public PostProcessProfile ppp;

    public void SetPostProcess(bool value)
    {
        ppp.settings.ForEach(x => x.active = value);
    }


    public void ToggleSettings(bool doOtherThing = true)
    {

        var bbs = FindObjectsOfType<BetterButton>();
        bbs.ForEach(x => x.OnPointerExit(null));

        if (!doOtherThing)
        {
            return;
        }
        
        if(inSettings) {
            DisableSettings();
        } else {
            EnableSettings();
        }
    }

    void EnableSettings(){
        settingsMenu.SetActive(true);
        mainMenu.SetActive(false);
        Debug.Log("Settings enabled");
        inSettings = true;
    }

    void DisableSettings(){
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
        Debug.Log("Settings disabled");
        inSettings = false;
    }


    public AudioMixer mixer;

    public void SetMasterLevel(float sliderVal){
        mixer.SetFloat("MasterVolume", Mathf.Log10(sliderVal) * 20);
    }
    public void SetSFXLevel(float sliderVal){
        mixer.SetFloat("SFXVolume", Mathf.Log10(sliderVal) * 20);
    }
    public void SetAmbienceLevel(float sliderVal){
        mixer.SetFloat("AmbienceVolume", Mathf.Log10(sliderVal) * 20);
    }


    public TMP_Dropdown resolutionDropdown;
    Resolution[] resolutions;
    void Start() {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        
        if(resolutionDropdown == null) { Debug.Log("No res dropdown"); return; }
        inSettings = settingsMenu.activeInHierarchy;

        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;

        for(int i = 0; i < resolutions.Length; i++){
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].width == Screen.currentResolution.height){
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
    }


    public void SetResolution(int resolutionIndex) {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen); 
        Debug.Log(resolution.ToString());
    }

    public void Quit(){
        Debug.Log("Quit");
        Application.Quit();
    }

}
