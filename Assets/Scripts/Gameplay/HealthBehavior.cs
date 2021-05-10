using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    //This is the health that the player or enemy can use.
    //It gets removed from the game when the healh equals 0.
    [SerializeField]
    float health;



    //This will be used when the object hits another object in the game.
    //It will decrease the health by a certain value.
    void takeDamage()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<HealthBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        //If health is less than or equal to 0, this will destroy the game object
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
