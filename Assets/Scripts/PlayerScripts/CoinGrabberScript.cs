﻿using UnityEngine;
using System.Collections;

public class CoinGrabberScript : MonoBehaviour
{

    enum CapacityState {Penalty, Normal, Accelerate };
    CapacityState capacityState = CapacityState.Normal;

    [HideInInspector]
    public int currentCoins = 0;

    public int fuelCapacity = 100;
    public float fuelConsumption, accelerateFuelConsuption, fuelPenalty, acceleration;
    float currentAccelerate, lastAccelerate;
    bool accelerateState, penaltyState = false;
    float stolenSpeed;

    SpeedUpScript universeVelocity;
    int id;

    public int coinReward;

    public float tickRate; // Интервал между тиками расхода топлива
    float currentTimer;


    // Use this for initialization
    void Start()
    {
        currentTimer = tickRate;
        universeVelocity = GameObject.Find("Universe center").GetComponent<SpeedUpScript>();
        id = universeVelocity.GetFreeVelocitySlot();
        
    }


    void FixedUpdate()
    {
        //print(universeRb2d.velocity.y);
        //print(GetComponent<Rigidbody2D>().velocity.y);
        currentTimer -= Time.fixedDeltaTime;
        if (currentTimer < 0 & fuelCapacity > 0)
        {
            if (fuelCapacity <= 100)
                fuelCapacity -= (int)fuelConsumption;
            else
                fuelCapacity -= (int)accelerateFuelConsuption;
            currentTimer = tickRate;
        }


        if (fuelCapacity > 1 & fuelCapacity < 100)
        {
            if (accelerateState == true)
            {
                accelerateState = false;
                universeVelocity.SetVelocity(id, 0);
                lastAccelerate = 0;
                currentAccelerate = 0;
            }
            if (penaltyState == true)
            {
                penaltyState = false;
                universeVelocity.SetVelocity(id, 0);
                stolenSpeed = 0;
            }
            return;
        }

        if (fuelCapacity > 100)                  // Ускорение
        {
            currentAccelerate += universeVelocity.rawVelocity * acceleration;
            universeVelocity.SetVelocity(id, currentAccelerate);
            accelerateState = true;
        }

        if (fuelCapacity <= 0)
        {
            stolenSpeed += universeVelocity.rawVelocity * fuelPenalty;
            universeVelocity.SetVelocity(id,- stolenSpeed);
            penaltyState = true;
            
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            Destroy(other.gameObject);
            currentCoins += 1;
            fuelCapacity += coinReward;
        }
    }
}
