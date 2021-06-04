using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkMovementBehaviour : MonoBehaviour
{
    [Tooltip("The maximum magnitude this enemy's velocity can have.")]
    [SerializeField]
    private float _velocity;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Chunks will move at a fixed velocity every frame!
        Vector3 tempPos = new Vector3(transform.position.x, transform.position.y, -80);
        transform.position = Vector3.MoveTowards(transform.position, tempPos, _velocity * Time.deltaTime);
    }
}
