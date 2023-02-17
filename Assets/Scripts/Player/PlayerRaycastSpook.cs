using System.Collections;
using UnityEngine;

public class PlayerRaycastSpook : MonoBehaviour
{
    public AudioSource audioSourcea;
    public GameObject spooke;
    public PlayerGunPickup pgp; 
    private bool spookOver = false;
    public LayerMask lm;
    public float showSpookTime = 1f;
    private void FixedUpdate()
    {
        if (spookOver || !pgp.hasGun)
        {
            return;
        }
        
        if (!spookOver && !pgp.hasGun)
        {
            spooke.SetActive(false);
        }

        if (Physics.SphereCast(transform.position, .5f, transform.forward, out var hit, 10, lm))
        {
            StartCoroutine(Disable());
            spooke.SetActive(true);
            spookOver = true;
            audioSourcea.Play();
        }
    }

    IEnumerator Disable()
    {
        yield return new WaitForSeconds(showSpookTime);
        spooke.SetActive(false);
    }
}
