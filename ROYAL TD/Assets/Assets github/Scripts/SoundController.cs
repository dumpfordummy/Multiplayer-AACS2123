using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioSource sound;
    public AudioClip batClip;
    public AudioClip crabClip;
    public AudioClip ratClip;
    public AudioClip slimeClip;
    public AudioClip golemClip;

    void Update()
    {
        if (GameObject.Find("Bat(Clone)"))
        {
            GetComponent<AudioSource>().clip = batClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Crab(Clone)"))
        {
            GetComponent<AudioSource>().clip = crabClip;
            GetComponent<AudioSource>().volume = 0.05f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Rat(Clone)"))
        {
            GetComponent<AudioSource>().clip = ratClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Spiked Slime(Clone)"))
        {
            GetComponent<AudioSource>().clip = slimeClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Golem Phase 1(Clone)"))
        {
            GetComponent<AudioSource>().clip = golemClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
        else if (GameObject.Find("Golem Phase 3(Clone)"))
        {
            GetComponent<AudioSource>().clip = golemClip;
            GetComponent<AudioSource>().volume = 0.2f;
            if (!sound.isPlaying)
            {
                sound.Play();
            }
        }
    }
}
