using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class PlayerAudio : MonoBehaviour//This is used to play audio related to the player. OBS.: It need an upgrade.
    {
        [SerializeField] AudioSource audioSource;
        [SerializeField] SOAudioClips[] playerClips;
        [SerializeField] SOPlayerStats playerStats;


        private void OnEnable()
        {
            EnemyPowerAttack.playerGetHurt += PlayPlayerAudio;
        }

        void PlayPlayerAudio()
        {
            if (playerStats.playerHealth < 0)
            {
                playerClips[0].PlayAudio(audioSource);
            }
            else
            {
                playerClips[1].PlayAudio(audioSource);
            }
        }

        private void OnDisable()
        {
            EnemyPowerAttack.playerGetHurt -= PlayPlayerAudio;
        }
    }
}
