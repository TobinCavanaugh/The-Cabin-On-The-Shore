using UnityEngine;
using UnityEngine.Events;

public class ENV_WaterSplash : MonoBehaviour
{
    public ParticleSystem ps;
    public Transform respawnSpot;
    public AudioSource as_;
    
    public UnityEvent touchEvent;
    
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Player"){
            
            touchEvent?.Invoke();
            ps.transform.position = other.transform.position;
            ps.Play();

            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.gameObject.transform.position = respawnSpot.position;

            as_.transform.position = other.gameObject.transform.position;
            as_.Play();
        }
    }

}
