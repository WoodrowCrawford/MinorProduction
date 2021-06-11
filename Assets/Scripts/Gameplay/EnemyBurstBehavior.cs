using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBurstBehavior : MonoBehaviour
{
    [Tooltip("The barrel that is shooting the bullets!")]
    [SerializeField]
    private BulletSpawnBehaviour _BulletSpawner;

    [Tooltip("The speed of fow fast the bullets are being shot after each other")]
    [SerializeField]
    private float RateOfFire;

    [Tooltip("The amount of bullets per burst shot")]
    [SerializeField]
    private int shotsPerBurst;

    [Tooltip("The time between bursts")]
    [SerializeField]
    private float TimerBetweenBursts;

    private float timeBetweenBurstsBackup;
    
    [Tooltip("The bullet prefab being used")]
    [SerializeField]
    private GameObject _Bullet;

    public IEnumerator BurstFire(GameObject bullet, int AmountShot, float rateOfFire)
    {
        ///<summary>
        ///A for statement to shoot for each bullet in a burst.
        /// First the bullet is created with the istantiate function and set to a gameobject variable.
        /// The variable is applied with the bullet behavior script for movement and damage.
        /// The function then waits for time between bullets (RateOfFire timer) to repat.
        /// </summary>
        for(int i = 0; i < AmountShot; i++)
        {

            GameObject Bullet = Instantiate(_Bullet, _BulletSpawner.transform.position, new Quaternion());
            bullet.GetComponent<BulletBehaviour>();

            yield return new WaitForSeconds(rateOfFire);
        }
       
    }

    // Start is called before the first frame update
    void Start()
    {
        
        timeBetweenBurstsBackup = TimerBetweenBursts;

    }

    // Update is called once per frame
    void Update()
    {
        ///<summary>
        /// First it checks if the time between bursts is zero, if not it subtracts from time between frames.
        /// If so the coroutine is then excuted with the parameters passed in that is can be altered.
        /// Once the coroutine is finished the timer is then reset back to the amount stated
        /// </summary>
        if (timeBetweenBurstsBackup <= 0)
        {
            StartCoroutine(BurstFire(_Bullet, shotsPerBurst, RateOfFire));
            timeBetweenBurstsBackup = TimerBetweenBursts;
        }
        else
            timeBetweenBurstsBackup -= Time.deltaTime;
    }
}
