using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager s_instance;
    [SerializeField] private AudioSource _grabSource;

    public void Awake() {
        if (s_instance != null) {
            Destroy(s_instance.gameObject);
        }
        s_instance = this;
    }

    public void PlaySound(SoundType soundType) {
        switch (soundType) {
            case SoundType.Grab:
                _grabSource.Play();
                break;
        }
    }
}

public enum SoundType {
    Grab
}