using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class UI_PauseMenu : MonoBehaviour
{
    public FirstPersonMovement movement;
    public FirstPersonLook fpLook;
    public GameObject pauseMenu;
    public GameObject inGameMenu;
    public bool paused = false;

    public UnityEvent startPause;
    public UnityEvent endPause;
    

    public void Pause(){
        paused = true;
        movement.canMove = false;
        fpLook.canLook = false;
        pauseMenu.SetActive(true);
        inGameMenu.SetActive(false);
        startPause?.Invoke();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Unpause(){
        paused = false;
        movement.canMove = true;
        fpLook.canLook = true;
        pauseMenu.SetActive(false);
        inGameMenu.SetActive(true);
        endPause?.Invoke();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            TogglePause();
        }
    }

    public void LoadScene(int value)
    {
        SceneManager.LoadScene(value);
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void TogglePause(){
        if(paused) {
            Unpause();
        } else {
            Pause();
        }
    }
}
