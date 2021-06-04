using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehaviour : MonoBehaviour
{
    //Speed the objects will move at
    [Range(0.1f, 1)]public float speed;
    //Direction the objects will move in
    public Vector3 moveDirection;

    void OnTriggerStay(Collider other)
    {
        //On trigger, move the other object to the specified direction, at the specified speed
        other.transform.position += moveDirection * speed * Time.deltaTime;
    }
}
