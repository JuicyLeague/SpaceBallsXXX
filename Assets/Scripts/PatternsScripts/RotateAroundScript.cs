using UnityEngine;
using System.Collections;

public class RotateAroundScript : MonoBehaviour {

    public Transform target;
    Vector2 point;
    public int speed;
    Vector3 dir;
	// Use this for initialization
	void Awake () {
        point = (Vector2)target.position;
        if ((int)(Random.value * 100) % 2 == 0)
            dir = Vector3.back;
        else dir = Vector3.forward;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        
        transform.RotateAround(point, dir, speed * Time.fixedDeltaTime);

    }
}
