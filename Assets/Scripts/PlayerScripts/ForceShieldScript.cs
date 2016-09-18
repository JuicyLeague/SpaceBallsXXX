using UnityEngine;
using System.Collections;

public class ForceShieldScript : MonoBehaviour {
    enum Shield {Ready, Protecting, Cooldown };
    Shield shieldState = Shield.Ready;
    public GameObject Protector;
    float currentTimer;
    public float protectingTimer, cooldownTimer;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.C) & shieldState == Shield.Ready)
        {
            shieldState = Shield.Protecting;
            Protector.SetActive(true);
            currentTimer = protectingTimer;
        }
	
	}

    void FixedUpdate()
    {
        if (currentTimer > 0)
            currentTimer -= Time.fixedDeltaTime;
        else
        {


            if (shieldState == Shield.Protecting )
            {
                shieldState = Shield.Cooldown;
                Protector.SetActive(false);
                currentTimer = cooldownTimer;

            }

            if (shieldState == Shield.Cooldown )
            {
                shieldState = Shield.Ready;


            }
        }
    }
}
