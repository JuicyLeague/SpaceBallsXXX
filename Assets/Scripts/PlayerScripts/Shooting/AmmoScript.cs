using UnityEngine;
using System.Collections;

public class AmmoScript : MonoBehaviour {

    float speed;

    // Use this for initialization
    void Start ()
    {
        speed = GameObject.Find("Universe center").GetComponent<SpeedUpScript>().totalVelocity;
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15 + speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(other.gameObject);  // Сменить на SetActive
            Destroy(gameObject);  // Сменить на SetActive
        }

    }
}
