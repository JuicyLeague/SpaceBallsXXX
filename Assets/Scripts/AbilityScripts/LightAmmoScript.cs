using UnityEngine;
using System.Collections;

public class LightAmmoScript : AbilityClassScript{

    private GameObject ammoPrefab, ammoClone;
    private GameObject player;
    private float speed;


	// Use this for initialization
	void Start ()
    {
        speed = GameObject.Find("Universe center").GetComponent<SpeedUpScript>().totalVelocity;
        player = GameObject.Find("Player");
        ammoPrefab = Resources.Load<GameObject>("Ammo");
        print("Light ammo ability attached!");
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
        ammoClone = Instantiate(ammoPrefab, player.transform.position, Quaternion.identity) as GameObject;
        ammoClone.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15 + speed);
    }

    public override void Acting()
    {
    }

    public override void Cooldown()
    {
    }

}
