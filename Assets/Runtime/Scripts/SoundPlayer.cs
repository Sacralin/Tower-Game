using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioSource source;

    public AudioClip arrowShot;
    public AudioClip cannonShot;
    public AudioClip magicShot;

    public AudioClip startMusic;
    public AudioClip levelMusic;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayArrowSound()
    {
        source.PlayOneShot(arrowShot);
    }
    public void PlayCannonSound()
    {
        source.PlayOneShot(cannonShot);
    }
    public void PlayMagicSound()
    {
        source.PlayOneShot(magicShot);
    }
    public void PlayStartMusic()
    {
        source.clip = startMusic;
        source.loop = true;
        source.Play();
    }
    public void StopStartMusic()
    {
        source.loop = false;
    }
    public void PlayLevelMusic()
    {
        source.clip = levelMusic;
        source.loop = true;
        source.Play();
    }
    public void StopLevelMusic()
    {
        source.loop = false;
    }


}
