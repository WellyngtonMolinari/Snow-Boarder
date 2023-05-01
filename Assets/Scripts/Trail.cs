using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] ParticleSystem trail;
    [SerializeField] AudioClip Jump;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the player or the ground object
        audioSource = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            trail.Play();
            audioSource.Play();
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            trail.Stop();
            audioSource.Stop();
            GetComponent<AudioSource>().PlayOneShot(Jump);
        }
    }
}
