using UnityEngine;
using System.Collections;

public class MagnetScript : AbilityClassScript
{

    public float magnetRadius;
    public float magnetPower;

    private GameObject player;
    private Collider2D[] colliders;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
        print("Magnet ability attached!");
    }

    void FixedUpdate()
    {
        if (abilityState == AbilityFase.Ready & ActivateAbility == true)
        {
            ActivateAbility = false;
            abilityState = AbilityFase.Acting;
            //Ready();
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

        if (currentTimer > 0 & abilityState == AbilityFase.Acting)
        {
            Ready();
        }
    }


    public override void Ready()                                                    // Сделано в виде методов без особой на то причины
    {
        Rigidbody2D rb2d;

        colliders = Physics2D.OverlapCircleAll(player.transform.position, magnetRadius);
        foreach (Collider2D i in colliders)
        {
            if (i.tag == "Coin")
            {
                rb2d = i.GetComponent<Rigidbody2D>();
                rb2d.velocity = (player.transform.position - i.transform.position) * magnetPower;
            }
        }
    }

    public override void Acting()
    {
    }

    public override void Cooldown()
    {
    }
}
