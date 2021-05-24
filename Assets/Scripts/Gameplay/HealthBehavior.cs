using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    //This is the health that the player or enemy can use.
    //It gets removed from the game when the healh equals 0.
    [SerializeField]
    private float _health;


    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }

    //This will be used when the object hits another object in the game.
    //It will decrease the health by a certain value.
    //The values can be changed.
   public void TakeDamage(float damage)
    {
        //makes the new health value equal to the preivious health minus 1 (or any given number).

        _health -= damage;

        if (_health <= 0)
            _health = 0;
    }

    //A function that can heal the player by a given value. Can be used for a powerup.
    public void Heal(int value)
    {
        Health += value;
        if (Health <= 3)
            Health = 3;
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
