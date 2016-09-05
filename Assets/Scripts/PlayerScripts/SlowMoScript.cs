using UnityEngine;
using System.Collections;

public class SlowMoScript : MonoBehaviour {


    [HideInInspector]
    public bool downSwipe = false;                                  // эту ссанину переписать в виде функции
    enum SlowMoStatus { Ready, Slowdown, Cooldown };
    SlowMoStatus slowMoStatus = SlowMoStatus.Ready;
    public float timeScale;
    public float slowTimer;
    float currentSlowTimer;
    public float cooldownSlowTimer;


    void Start()
    {
        
        currentSlowTimer = slowTimer;
        slowTimer *= timeScale;

    }

    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Space)|| downSwipe == true) & slowMoStatus == SlowMoStatus.Ready)     // Возможно ты не видишь, но тут костыль для возможности управления на компе (не забыть убрать в финалке)
        {
            downSwipe = false;
            if (Time.timeScale == 1.0F)
            {
                Time.timeScale = timeScale;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                slowMoStatus = SlowMoStatus.Slowdown;
            }
        }

        if (slowMoStatus == SlowMoStatus.Slowdown)
        {
            if (currentSlowTimer > 0)
            {
                currentSlowTimer -= Time.deltaTime;
            }
            else
            {
                Time.timeScale = 1.0F;
                Time.fixedDeltaTime = 0.02F * Time.timeScale;
                currentSlowTimer = cooldownSlowTimer;
                slowMoStatus = SlowMoStatus.Cooldown;
            }
        }

        if (slowMoStatus == SlowMoStatus.Cooldown)
            {
                if (currentSlowTimer > 0)
                {
                    currentSlowTimer -= Time.deltaTime;
                }
                else
                {
                    slowMoStatus = SlowMoStatus.Ready;
                    currentSlowTimer = slowTimer;
                }
            }

        downSwipe = false;
    }
}
