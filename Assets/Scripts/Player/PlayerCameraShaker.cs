using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using EZCameraShake;

public class PlayerCameraShaker : MonoBehaviour
{
    public float magn = 3f;
    public float rough = 1f;
    public float fadeIn = .4f;
    public float fadeOut = .4f;
    public CameraShaker cm;
    [Button("Shake")]
    public void Shake(){
        CameraShaker.Instance.ShakeOnce(magn, rough, fadeIn, fadeOut);
    }
}
