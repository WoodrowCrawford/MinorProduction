using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoalBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy") == true)
        {
            Destroy(other.gameObject);
            //call take damage for the player here
            //it should negate the health on the HUD
        }
    }
}
