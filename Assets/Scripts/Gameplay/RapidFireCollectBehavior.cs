using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireCollectBehavior : MonoBehaviour
{
    [SerializeField]
    private PowerUpScriptableObject RapidFirePowerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RapidFirePowerUp.isActive = true;
            Destroy(gameObject);
        }
    }
}
