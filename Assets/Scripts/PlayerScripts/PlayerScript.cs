using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {



   
    [HideInInspector] public int deathcount = 0;
    public int currentCoins = 0;
    public float smoothTime = 15f;

    float targetFloat;
    [HideInInspector] public int current_line = 3;

    GameObject universe;

    

    void Start()
    {

        universe = GameObject.Find("Universe center");
    }

    public void TurnLeft()
    {
        if (current_line != 1)
        {
            current_line -= 1;
            targetFloat = (current_line - 2) * 2 - 2;
        }
    }

    public void TurnRight()
    {
        if (current_line != 5)
        {
            current_line += 1;
            targetFloat = (current_line - 2) * 2 - 2;
        }
    }


    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.A) & current_line != 1)           // Возможно ты не видишь, но тут костыль для возможности управления на компе (не забыть убрать в финалке)
        {                                                              // Я сейчас про весь Update()
            current_line -= 1;
            targetFloat =  (current_line-2) * 2 - 2;     
            }

        if (Input.GetKeyDown(KeyCode.D) & current_line != 5)
        {
            current_line += 1;
            targetFloat = (current_line - 2) * 2 - 2;
        }


        



        transform.position = Vector2.Lerp((Vector2)transform.position, new Vector2(targetFloat, transform.position.y), Time.deltaTime * smoothTime);            // новый способ перемещения

    }





    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.R))
            if (Time.timeScale < 1F)
            {
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                Application.LoadLevel(0);
            }
            
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Coin")
        {
            currentCoins += 1;
            Destroy(other.gameObject);
        }

        if (other.tag == "Wall" & GetComponent<DashScript>().dashStatus != DashScript.DashStatus.Dashing)
        {
            deathcount += 1;
        }
    }

   

}
