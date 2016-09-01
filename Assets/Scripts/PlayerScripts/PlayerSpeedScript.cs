using UnityEngine;
using System.Collections;

public class PlayerSpeedScript : MonoBehaviour {

    GameObject universe;                    // Оооооочень похоже на костыль, но иначе проблематично менять скорость player относительно OY не задевая при этом скорость других объектов

    
    void Start () {
        universe = GameObject.Find("Universe center");
	}
	

	void FixedUpdate () {
        GetComponent<Rigidbody2D>().velocity = universe.GetComponent<Rigidbody2D>().velocity;
	
	}
}
