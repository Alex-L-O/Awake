using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO Revisar si sirve esta clase
public class VolumeController : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    public void OnVolumeChanged(float value)
    {
        audioSource.volume = value;
    }
}
