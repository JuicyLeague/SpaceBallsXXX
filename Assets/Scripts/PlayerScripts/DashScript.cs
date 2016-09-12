using UnityEngine;
using System.Collections;

public class DashScript : MonoBehaviour {

    [HideInInspector]
    public bool upSwipe = false;                        // эту ссанину переписать в виде функции

    GameObject universe;
    SpeedUpScript universeVelocity;

    [HideInInspector]    public enum DashStatus { Ready, Dashing, Cooldown };
    [HideInInspector]    public DashStatus dashStatus = DashStatus.Ready;
    ParticleSystem dashEffect;
    float cameraDashSpeed = 0;
    public float dashMultiplier;
    public float dashTimer;
    float currentDashSpeed;
    float currentDashTimer;
    public float cooldownDashTimer;
    int id;
    

    // Use this for initialization
    void Start () {
        dashEffect = GameObject.Find("DashEffect").GetComponent<ParticleSystem>();
        currentDashTimer = dashTimer;
        universe = GameObject.Find("Universe center");
        universeVelocity = universe.GetComponent<SpeedUpScript>();
        id = universeVelocity.GetFreeVelocitySlot();

    }
	
	// Update is called once per frame
	void Update () {

        if ((Input.GetKeyDown(KeyCode.W) || upSwipe == true) & dashStatus == DashStatus.Ready)               // Весь Dash ниже
        {                                                                                                   // Возможно ты не видишь, но тут костыль для возможности управления на компе (не забыть убрать в финалке)       
            upSwipe = false;
            currentDashSpeed = universeVelocity.rawVelocity * dashMultiplier;
            universeVelocity.SetVelocity(id, currentDashSpeed);
            dashStatus = DashStatus.Dashing;
            dashEffect.Play();
        }

        if (dashStatus == DashStatus.Dashing)
        {

            if (currentDashTimer > 0)
            {
                currentDashTimer -= Time.deltaTime;
                cameraDashSpeed += 1 * Time.deltaTime;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TargetFollowScript>().offset = Mathf.Lerp(0, -1, cameraDashSpeed);
            }
            else
            {
                dashEffect.Stop();
                cameraDashSpeed = 0;
                universeVelocity.SetVelocity(id, 0);
                dashStatus = DashStatus.Cooldown;
                currentDashTimer = cooldownDashTimer;
            }
        }

        if (dashStatus == DashStatus.Cooldown)
        {
            if (currentDashTimer > 0)
            {
                currentDashTimer -= Time.deltaTime;
                cameraDashSpeed += 1 * Time.deltaTime;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TargetFollowScript>().offset = Mathf.Lerp(-1, 0, cameraDashSpeed);
            }

            else
            {
                cameraDashSpeed = 0;
                dashStatus = DashStatus.Ready;
                currentDashTimer = dashTimer;
            }
        }
        // Конец Dash
        upSwipe = false;

    }
}
