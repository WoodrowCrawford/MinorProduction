using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTeleporterMovement : MonoBehaviour
{
    [Tooltip("The position the chunks will be teleported to")]
    [SerializeField]
    private Transform _teleportPosition;

    public Transform TeleportPosition
    {
        get
        {
            return _teleportPosition;
        }
        set
        {
            _teleportPosition = value;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(0, 0, 80);
    }
}
