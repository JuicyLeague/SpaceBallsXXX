using UnityEngine;
using System.Collections;

public class SpeedUpScript : MonoBehaviour {                // Данный скрипт должен висеть только на universe center
    Rigidbody2D rb2d;
    float[] VelocityArray = new float[10];          // raw velocity = VelocityArray[0]
    [HideInInspector]
    public float rawVelocity;

    bool gameOver = false;

    float totalVelocity;
    int freeArraySlot = 1;

    public float startingSpeed, maxSpeed, targetTime; // Ввод target time в минутах
    float targetSpeed;
    bool stopSpeedUp = false; 

    public float tickRate = 1F;
    float currentTimer;

    void Start () {
        targetTime *= 60;               // Перевод в секунды
        print(VelocityArray.Length);
        rawVelocity = VelocityArray[0] = startingSpeed;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, rawVelocity);
        currentTimer = tickRate;


    }

    void FixedUpdate()
    {
        if (stopSpeedUp == false)
        { 
        currentTimer -= Time.fixedDeltaTime;
            if (currentTimer < 0)
            {
                currentTimer = tickRate;

                if (rawVelocity <= maxSpeed)
                    rawVelocity += targetSpeed / targetTime;

                if (rawVelocity > maxSpeed)
                {
                    rawVelocity = maxSpeed;
                    stopSpeedUp = true;
                }
            }
            
        }
        if (gameOver != true)
            ChangeVelocity();

    }

    void ChangeVelocity()
    {
        for (int i = 0; i <= (freeArraySlot - 1); i++)
            totalVelocity += VelocityArray[i];
        rb2d.velocity = new Vector2(0, totalVelocity);
        if (totalVelocity <= 0.5F)
        { 
            gameOver = true;
            rb2d.velocity = new Vector2(0, 0);
        }
        totalVelocity = 0;
    }

    public int GetFreeVelocitySlot()
    {
        freeArraySlot += 1;
        return (freeArraySlot -1);
    }

    public void SetVelocity(int id, float f)
    {
        VelocityArray[id] = f;
    }

}
