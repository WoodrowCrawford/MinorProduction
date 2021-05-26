using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehaviour : MonoBehaviour
{
    [Range(0.1f, 1)]public float speed;
    public Vector3 moveDirection;

    void OnTriggerStay(Collider other)
    {
        other.transform.position += moveDirection * speed * Time.deltaTime;
    }
}
