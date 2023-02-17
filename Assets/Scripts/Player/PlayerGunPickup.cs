using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunPickup : MonoBehaviour
{
    public GameObject playerGun;
    public AudioSource pickupAudioSource;
    private PlayerEventManager pem;
    public bool hasGun = false;

    void Start() {
        pem = GetComponent<PlayerEventManager>();
    }
    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("GunPickup") && pem.totemCount == 3){
            other.gameObject.SetActive(false);
            playerGun.SetActive(true);
            pickupAudioSource.Play();
            hasGun = true;
            pem.hasGun = true;
            pem.ChangeMessage("R̡͢͝é̡͜t͘͞u̕͜r̡n͜ ̀͞͠t̵͢͝o̶͞҉́҉ ͘͠͠t̴̕͞h̵͏é̸͠ ͘̕͡l̸͟҉̧ą̴́k̶̀ȩ̧͜");
        }

        if(other.gameObject.tag.Equals("EndGame")){
            pem.EndGame();
        }
    }
}
