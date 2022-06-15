using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class SAudioController : MonoBehaviour//Used to play the audios
    {
        [SerializeField] AudioSource audioSource;


        public AudioClip[] clips;//lose, win, main music

        public static SAudioController _instance;
        public static SAudioController Instance { get { return _instance; } }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }
      

        public void ChangeMusicClip(int clipIndex)
        {
            audioSource.clip = clips[clipIndex];
            audioSource.Play();
        }
    }
}
