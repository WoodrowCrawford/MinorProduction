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
        //When triggered, the chunks will teleport to z 80
        other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 80);
    }
}
