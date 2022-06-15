using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    [CreateAssetMenu(menuName = "Scriptable Objects / Audio Clips", fileName = "Audio Clips")]
    public class SOAudioClips : ScriptableObject
    {
        public AudioClip clip;

        public void PlayAudio(AudioSource audioSource)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
