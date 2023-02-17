using System.Collections;
using UnityEngine;

public class ENV_LightFlicker : MonoBehaviour
{
    float minLight = .2f;
    float maxLight = 3.65f;
    private Light light;
    void Start() {
        light = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker(){
        yield return new WaitForSeconds(Random.Range(.1f, .5f));

        light.intensity = Random.Range(minLight, maxLight);

        StartCoroutine(Flicker());
    }
}
