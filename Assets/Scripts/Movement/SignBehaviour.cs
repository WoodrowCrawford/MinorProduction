using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehaviour : MonoBehaviour
{
    //Speed the objects will move at
    [Range(0.25f, 1)]public float speed;
    //Direction the objects will move in
    public Vector3 moveDirection;
    private GameManagerBehavior _gameManager;
    private int _tempScore;

    void Awake()
    {
        //Sets a refference to the GameManager
        _gameManager = GetComponent<GameManagerBehavior>();
        speed = 0.1f;
        if (gameObject.CompareTag("Across"))
        {
            //Add 0.1f to the speed
            speed = 0.25f;
        }

        if (gameObject.CompareTag("Down"))
        {
            //Add 0.1f to the speed
            speed = 1;
        }
    }

    private void Update()
    {
        //Always check score to apply the difficulty curve
        DifficultyCurve();
    }

    //When an enemy collides with this object, the enemy moves in the specified moveDirection
    void OnTriggerStay(Collider other)
    {
        //If the other collider is an enemy
        if (other.CompareTag("Enemy"))
        {
            //Apply the speed to the specified moveDirection
            other.transform.position += moveDirection * speed * Time.deltaTime;
        }
    }

    void DifficultyCurve()
    {
        //If the score in GameManager is divisible by 25
        if ((GameManagerBehavior.score % 25 == 0) && _tempScore != GameManagerBehavior.score)
        {
            //Set the score to be the tempScore
            _tempScore = GameManagerBehavior.score;

            //Add 0.1f to the speed
            speed += 0.05f;

            //If the speed is at the max (at 1) and goes across the stage
            if (speed == 1 && gameObject.CompareTag("Across"))
            {
                //Speed is set to the lowest number possible (0.25f)
                speed = 0.25f;
            }
        }
    }
}
