using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPositionBehaviour : MonoBehaviour
{
    [Tooltip("The time before despawning the bullet.")]
    [SerializeField]
    private float _despawnTime;

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject, _despawnTime);
    }
}
