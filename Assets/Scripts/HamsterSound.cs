using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterSound : MonoBehaviour
{
    AudioSource source;
    Rigidbody rb;
    BallMovement ballMovement;
    [SerializeField] AudioClip rollWood;
    [SerializeField] AudioClip rollGlass;
    [SerializeField] AudioClip rollSoft;
    [SerializeField] AudioClip rollElastic;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody>();
        ballMovement = GetComponent<BallMovement>();
    }

    private void OnEnable()
    {
        ballMovement.OnSurfaceChange += ExecSwitchAudioClips;
    }
    private void OnDisable()
    {
        ballMovement.OnSurfaceChange -= ExecSwitchAudioClips;
    }

    private void Update()
    {
        if (rb.velocity.magnitude > 0) 
        { 
            if(!source.isPlaying) source.Play();
        }
        else source.Stop();
    }

    void ExecSwitchAudioClips(Surface surface)
    {
        switch (surface) 
        {
            case Surface.Wood:
                SwitchClip(rollWood);
                break;
            case Surface.Glass:
                SwitchClip(rollGlass);
                break;
            case Surface.Soft:
                SwitchClip(rollSoft);
                break;
            case Surface.Elastic:
                SwitchClip(rollElastic);
                break;
            case Surface.None:
                source.Stop();
                break;
        }
    }

    void SwitchClip(AudioClip clip)
    {
        source.Stop();
        source.clip = clip;
        source.Play();
    }

}
