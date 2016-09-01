using UnityEngine;
using System.Collections;

public class SpeedUpScript : MonoBehaviour {
    Rigidbody2D rb2d;
    public float startingSpeed;
    public float maxSpeed;
    public bool stopSpeedUp = false;                    // Данный скрипт должен висеть только на universe center

    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0, startingSpeed);


    }

    void FixedUpdate()
    {
        if (!stopSpeedUp)
        {
            if (rb2d.velocity.y < maxSpeed)
                rb2d.velocity = new Vector2(0, rb2d.velocity.y + Time.fixedDeltaTime / 30);       // Набор скорости до max speed затем отключение скрипта
            if (rb2d.velocity.y > maxSpeed)
            {
                rb2d.velocity = new Vector2(0, maxSpeed);
                Destroy(GameObject.Find("Player").GetComponent<PlayerSpeedScript>());
                GetComponent<SpeedUpScript>().enabled = false;

            }
            //  print(rb2d.velocity.magnitude.ToString());           // Принт скорости
        }


    }
}
