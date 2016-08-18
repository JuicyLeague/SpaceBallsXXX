using UnityEngine;
using System.Collections;

public class CreatorFollowScript : MonoBehaviour {

    public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2(transform.position.x, target.transform.position.y + 10);
	
	}
}
