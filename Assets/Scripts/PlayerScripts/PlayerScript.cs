using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    DashStatus dashStatus = DashStatus.Ready;
    [HideInInspector] public int deathcount = 0;
    bool moving = false;
    private float yVelocity = 0.0F;
    public float smoothTime = 0.1F;

    float targetFloat;
    [HideInInspector] public int current_line = 3;

    GameObject universe;

    ParticleSystem dashEffect;
    float cameraDashSpeed = 0;
    public float dashMultiplier;
    public float dashTimer;
    float currentDashTimer;
    public float cooldownDashTimer;

    void Start()
    {
        dashEffect = GameObject.Find("DashEffect").GetComponent<ParticleSystem>();
        currentDashTimer = dashTimer;

        universe = GameObject.Find("Universe center");
    }


    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.A) & current_line != 1 )
            {
            current_line -= 1;
            targetFloat =  (current_line-2) * 2 - 2;     
            }

        if (Input.GetKeyDown(KeyCode.D) & current_line != 5)
        {
            current_line += 1;
            targetFloat = (current_line - 2) * 2 - 2;
        }

        if (Input.GetKeyDown(KeyCode.W) & dashStatus == DashStatus.Ready)               // Весь Dash ниже
        {
            universe.GetComponent<SpeedUpScript>().stopSpeedUp = true;
            universe.GetComponent<Rigidbody2D>().velocity *= dashMultiplier; 
            dashStatus = DashStatus.Dashing;
            dashEffect.Play();
        }

        if (dashStatus == DashStatus.Dashing)
        {

            if (currentDashTimer > 0)
            {
                currentDashTimer -= Time.deltaTime;
                cameraDashSpeed+= 1 * Time.deltaTime;
                GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TargetFollowScript>().offset = Mathf.Lerp(0, -1, cameraDashSpeed);
            }
            else
            {
                dashEffect.Stop();
                cameraDashSpeed = 0;
                universe.GetComponent<Rigidbody2D>().velocity /= dashMultiplier;
                universe.GetComponent<SpeedUpScript>().stopSpeedUp = false;
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
            }                                                                           // Конец Dash
        


        /*float newPosition = Mathf.SmoothDamp(transform.position.x, targetFloat , ref yVelocity, smoothTime);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);*/
        transform.position = Vector2.Lerp((Vector2)transform.position, new Vector2(targetFloat, transform.position.y), Time.deltaTime * smoothTime);            // новый способ перемещения

    }



    enum DashStatus {Ready, Dashing, Cooldown };

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(0);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall" & dashStatus != DashStatus.Dashing)
        {
            deathcount += 1;
        }
    }

   

}
