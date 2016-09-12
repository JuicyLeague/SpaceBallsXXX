using UnityEngine;
using System.Collections;

public class TogetherScript : MonoBehaviour
{
    public float smoothTime = 0.3F;
    public int direction;
    bool pushingFase = true;
    bool pullingFase = false;
    float timeLeft;
    public int speed;

    // Use this for initialization
    void Awake()
    {

        timeLeft = smoothTime;                      // Препятсивие с этим скриптом скорее всего говно
                                                    // Добавить привзяку к скорости игрока, спаун на разных фазах движения


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (pushingFase)

            transform.position = Vector2.Lerp((Vector2)transform.position, new Vector2(0, transform.position.y), Time.fixedDeltaTime * speed);
        if (pullingFase)
            transform.position = Vector2.Lerp((Vector2)transform.position, new Vector2(direction * 2, transform.position.y), Time.fixedDeltaTime * speed);


        timeLeft -= Time.fixedDeltaTime;
        if (timeLeft < 0)
        {
            if (pushingFase)
            {
                pushingFase = false;
                pullingFase = true;
                timeLeft = smoothTime;
                return;
            }
            if (pullingFase)
            {
                pullingFase = false;
                pushingFase = true;

                timeLeft = smoothTime;
            }
        }
    }
}
