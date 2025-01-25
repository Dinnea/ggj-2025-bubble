using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SFX_Manager : MonoBehaviour
{
    [SerializeField] AudioSource sourceSFX;

    [SerializeField] AudioClip collectSFX;
    [SerializeField] List<AudioClip> pillowImpacts;


    private void OnEnable()
    {
        BallMovement.OnCollected += PlayCollectSFX;
        BallMovement.OnPillowDrop += PlayImpact;
    }
    private void OnDisable()
    {
        BallMovement.OnCollected -= PlayCollectSFX;
        BallMovement.OnPillowDrop += PlayImpact;
    }
    void PlayCollectSFX(GameObject go)
    {
        PlaySFX(collectSFX, go.transform.position);
    }

    void PlayImpact(Vector3 position)
    {
        int random = Random.Range(0, pillowImpacts.Count);
        PlaySFX(pillowImpacts[random], position);
    }

    void PlaySFX(AudioClip clip, Vector3 position)
    {
        AudioSource audioSource = Instantiate(sourceSFX, position, Quaternion.identity);
        audioSource.clip = clip;
        audioSource.Play();
        Destroy(audioSource.gameObject, audioSource.clip.length);
    }
}
