﻿using UnityEngine;
using System.Collections;

public class SlowMoScript : AbilityClassScript {
   // public enum AbilityFase { Ready, Acting, Cooldown };
   // public AbilityFase abilityState = AbilityFase.Ready;
   //// new public bool ActivateAbility = false;          Не указано т.к. лежит в Родителе (если вдруг значение родителя и дочерних классов копируются то эт говно)
   // public float actingTimer, cooldownTimer;
   // public float currentTimer;
    public  float timeScale;



    void Start()
    {
        actingTimer *= timeScale;
        print("SlowMo ability attached!");
    }

    void FixedUpdate()
    {
        if (abilityState == AbilityFase.Ready & ActivateAbility == true)
        {
            ActivateAbility = false;
            abilityState = AbilityFase.Acting;      
            Ready();
            currentTimer = actingTimer;
        }

        if (currentTimer > 0)
            currentTimer -= Time.fixedDeltaTime;
        else
        {
            switch (abilityState)
            {
                case AbilityFase.Acting:
                    abilityState = AbilityFase.Cooldown;
                    Acting();
                    currentTimer = cooldownTimer;
                    break;
                case AbilityFase.Cooldown:
                    Cooldown();
                    abilityState = AbilityFase.Ready;
                    break;
            }
        }
    }


    public override void Ready()                                                    // Сделано в виде методов без особой на то причины
    {
        if (Time.timeScale == 1.0F)
        {
            Time.timeScale = timeScale;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }

    public override void Acting()
    {
        Time.timeScale = 1.0F;
        Time.fixedDeltaTime = 0.02F * Time.timeScale;
    }

    public override void Cooldown()
    {
    }

}
