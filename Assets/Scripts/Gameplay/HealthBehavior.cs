using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    //This is the health that the player or enemy can use.
    //It gets removed from the game when the healh equals 0.
    [SerializeField]
    private float _health;



    //This will be used when the object hits another object in the game.
    //It will decrease the health by a certain value.
    //The values can be changed.
    void takeDamage()
    {
        //makes the new health value equal to the preivious health minus 1 (or any given number).
        _health = _health - 1;
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //If health is less than or equal to 0, this will destroy the game object
        if (_health <= 0)
        {
            //Destroys the current object from the scene.
            Destroy(gameObject);
        }

    }
}
