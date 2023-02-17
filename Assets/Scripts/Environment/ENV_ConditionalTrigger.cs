using UnityEngine;
using UnityEngine.Events;

public class ENV_ConditionalTrigger : MonoBehaviour
{
    public PlayerEventManager pem;

    public UnityEvent lightsOutHouseEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (!pem.hasGun && !pem.houseLights[0].activeSelf)
        {
            Debug.Log(nameof(lightsOutHouseEnter));
            lightsOutHouseEnter?.Invoke();
        }
    }
}
