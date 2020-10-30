using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip soundLaser; 
    AudioSource myAudio; 
    public static SoundManager instance;  
    private void Awake()
    {
        if (SoundManager.instance == null) 
        {
            SoundManager.instance = this; 
        }

    }

    // Use this for initialization
    void Start ()
    {
        myAudio = this.gameObject.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void PlaySound()
    {
        myAudio.PlayOneShot(soundLaser);
    }

}
