using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DarkCloudGame
{
    public class EnemyHealth : MonoBehaviour//COntrols the enemy health and Die. The last part should be in a EnemyDie class
    {
        [SerializeField] SOEnemyStats enemyStats;
        [SerializeField] GameObject dieEffect;
        [SerializeField] SOAudioClips dieClip;
        [SerializeField] AudioSource audioSource;


        Collider2D _collider;

        float health;
        // Start is called before the first frame update
        void Start()
        {
            health = enemyStats.enemyHealth;
            _collider = GetComponent<Collider2D>();
        }
        
        public void GetDamage(float damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
                Destroy(gameObject, 3);
            }
        }
               

        void Die()
        {
            SEnemiesHolder.Instance.RemoveEnemieFromEnemiesList(gameObject);
            GameObject go = Instantiate(dieEffect, transform.position, Quaternion.identity);
            dieClip.PlayAudio(audioSource);
            Destroy(go,2);
            _collider.enabled = false;
            transform.GetChild(0).gameObject.SetActive(false);
        }

       
    }
}
