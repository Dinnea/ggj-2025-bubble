using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SFX_Manager : MonoBehaviour
{
    [SerializeField] AudioSource sourceSFX;

    [SerializeField] AudioClip collectSFX;
    [SerializeField] AudioClip deathSFX;
    [SerializeField] AudioClip elasticImpactSFX;
    [SerializeField] AudioClip woodImpacySFX;
    [SerializeField] AudioClip glassImpactSFX;
    [SerializeField] List<AudioClip> pillowImpacts;


    private void OnEnable()
    {
        BallMovement.OnCollected += PlayCollectSFX;
        BallMovement.OnDrop += PlayImpact;
        BallMovement.OnDeath += PlayShatter;
    }
    private void OnDisable()
    {
        BallMovement.OnCollected -= PlayCollectSFX;
        BallMovement.OnDrop += PlayImpact;
        BallMovement.OnDeath -= PlayShatter;
    }
    void PlayCollectSFX(GameObject go)
    {
        PlaySFX(collectSFX, go.transform.position);
    }
    void PlayShatter(Vector3 position)
    {
        PlaySFX(deathSFX, position);
    }

    void PlayImpact(JumpInfo jump)
    {
        int random = Random.Range(0, pillowImpacts.Count);
        Surface surface = jump.surface;

        switch (surface)
        {
            case Surface.Soft:
                PlaySFX(pillowImpacts[random], jump.location);
                break;
            case Surface.Elastic:
                PlaySFX(elasticImpactSFX, jump.location);
                break;
            case Surface.Wood:
                PlaySFX(woodImpacySFX, jump.location);
                break;
            case Surface.Glass:
                PlaySFX(glassImpactSFX, jump.location);
                break;
        }
    }

    void PlaySFX(AudioClip clip, Vector3 position)
    {
        AudioSource audioSource = Instantiate(sourceSFX, position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
