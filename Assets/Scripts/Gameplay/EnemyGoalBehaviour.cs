using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoalBehaviour : MonoBehaviour
{
    //Gets a reference of the player health for the game manager
    [SerializeField]
    private HealthBehavior _playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") == true)
        {
            Destroy(other.gameObject);
            _playerHealth.TakeDamage(1);
        }
    }
}
