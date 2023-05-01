using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail : MonoBehaviour
{
    [SerializeField] ParticleSystem trail;
    [SerializeField] AudioClip Snowboarding;
    [SerializeField] AudioClip Jump;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            trail.Play();
            GetComponent<AudioSource>().PlayOneShot(Snowboarding);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            trail.Stop();
            GetComponent<AudioSource>().PlayOneShot(Jump);
        }
    }
}
