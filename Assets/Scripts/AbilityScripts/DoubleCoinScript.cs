using UnityEngine;
using System.Collections;

public class DoubleCoinScript : AbilityClassScript
{

    PlayerScript coinGrabber;

    // Use this for initialization
    void Start()
    {
        print("Double coin ability ability attached!");
        coinGrabber = GameObject.Find("Player").GetComponent<PlayerScript>();
        coinGrabber.coinMultiplier = 2;
    }

    public override void Ready()                                                    // Сделано в виде методов без особой на то причины
    {
    }

    public override void Acting()
    {
    }

    public override void Cooldown()
    {
    }
}
