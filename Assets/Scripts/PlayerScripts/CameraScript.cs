using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
    GameObject Player;
    int line;



    void Start()
    {
        Player = GameObject.Find("Player");  
        

    }

	void FixedUpdate ()
    {
        line = Player.GetComponent<PlayerScript>().current_line;                                                            // Сдвиг камеры
        if (Player.transform.position.x < -2 | Player.transform.position.x > 2)
            gameObject.transform.position = new Vector3(transform.position.x, Player.transform.position.y + 5, -10);
        else
            gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, -10);



    }
}
