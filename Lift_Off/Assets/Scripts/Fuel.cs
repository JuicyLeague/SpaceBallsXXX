using UnityEngine;
using System.Collections;

public class Fuel : MonoBehaviour {

    public Rocket rocket;
    public Camera camera2d;
    public int speed = 3;

    private float x;

	// Use this for initialization
	void Start () {
        camera2d = FindObjectOfType<Camera>();
        rocket = FindObjectOfType<Rocket>();
        x = rocket.transform.position.x * (-1);
        gameObject.transform.position = new Vector3(x, camera2d.transform.position.y + 10, 0);

    }
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y <= camera2d.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
        gameObject.transform.position -= new Vector3(0, speed * Time.deltaTime, 0);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
