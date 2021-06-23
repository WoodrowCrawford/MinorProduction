using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFireCollectBehavior : MonoBehaviour
{
    [Tooltip("The power up that is used when picked up!")]
    [SerializeField]
    private PowerUpScriptableObject RapidFirePowerUp;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RapidFirePowerUp.isActive = true;
            Destroy(gameObject);

            FindObjectOfType<AudioManager>().Play("PowerPickUp");
        }
    }
}
