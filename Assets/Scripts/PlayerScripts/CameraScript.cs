using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    GameObject Player;
    GameObject Universe;
    int line;
    Vector2 targetPosition;
    public int speed;


    void Start()
    {
        Player = GameObject.Find("Player");
        Universe = GameObject.Find("Universe center");


    }

	void FixedUpdate ()
    {
        
        line = Player.GetComponent<PlayerScript>().current_line;                                                            // Сдвиг камеры

        switch (line)
        {
            case 3:
                Follow(0, speed);
                break;

            case 4: 
                Follow(2, speed);
                break;

            case 2: 
                Follow(-2, speed);
                break;

            case 5:
                Follow(2, speed);
                break;

            case 1:
                Follow(-2, speed);
                break;
        }


    }

    void Follow(int direction, int curSpeed)
    {
        //transform.position = Vector3.Lerp(transform.position, new Vector3(direction, Universe.transform.position.y + 5, -10), Time.deltaTime * curSpeed);
        transform.position = Vector3.Lerp(transform.position, new Vector3(direction, transform.position.y, transform.position.z), Time.deltaTime * curSpeed);
    }
}
