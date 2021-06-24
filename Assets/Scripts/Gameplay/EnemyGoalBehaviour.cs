using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoalBehaviour : MonoBehaviour
{
    //Gets a reference of the player health for the game manager
    [SerializeField]
    private HealthBehavior _playerHealth;

    //When the other game objects collide
    private void OnTriggerEnter(Collider other)
    {
        //If the other game object was tagged as "Enemy"
        if(other.CompareTag("Enemy") == true)
        {
            //Destroy the other gameObject
            Destroy(other.gameObject);
            //Tell the player to takeDamage
            _playerHealth.TakeDamage(1);

            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }
    }
}
