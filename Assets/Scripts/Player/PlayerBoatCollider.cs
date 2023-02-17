using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;

public class PlayerBoatCollider : MonoBehaviour
{
    public Animator boatAnimator;
    public string animateBoatString;
    public PlayerEventManager playerEventManager;

    public AudioSource[] disableTheseAudioSources;
    public GameObject[] disableTheseGameObjects;

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player") && playerEventManager.totemCount == 3 && playerEventManager.hasGun){
            boatAnimator.Play(animateBoatString);
            disableTheseAudioSources.ForEach(x => x.volume = 0);
            disableTheseGameObjects.ForEach(x => x.SetActive(false));
        }
    }
}
