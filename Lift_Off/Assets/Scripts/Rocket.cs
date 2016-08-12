using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Rocket : MonoBehaviour {

    public GameManager gM;
    public Camera camera2d;
    public Vector2 speed = new Vector2(0, 0);
    public Rigidbody2D rb2dD;

	// Use this for initialization
	void Start () {
        //speed = Vector2(8, 0);
        rb2dD = GetComponent<Rigidbody2D>();
        gM = GameObject.Find("Main Camera/GameManager").GetComponent<GameManager>();
	}

    private void MoveRocket()
    {
        float move = Input.GetAxis("Horizontal");
        speed.x = move * 6;
        rb2dD.MovePosition(rb2dD.position + speed * Time.deltaTime);
    }

	// Update is called once per frame
	void Update ()
    {
        MoveRocket();
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fuel")
        {
            gM.fuel_level += 200;
        }
        else if (other.tag == "Asteroid")
        {
            gM.GameOver();
        }
    }

}
