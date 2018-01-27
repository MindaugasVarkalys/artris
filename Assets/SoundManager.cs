using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public static SoundManager instance;
	// Use this for initialization
	void Start () {
        if (instance==null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this);
	}

    public void ButtonSound()
    {
        transform.GetComponents<AudioSource>()[1].Play();
    }

    public void FallSound()
    {
        transform.GetComponents<AudioSource>()[2].Play();
    }

    public void LoseSound()
    {
        transform.GetComponents<AudioSource>()[3].Play();
    }

    public void MoveSound()
    {
        transform.GetComponents<AudioSource>()[4].Play();
    }
    public void WinSound()
    {
        transform.GetComponents<AudioSource>()[5].Play();
    }
	
}
