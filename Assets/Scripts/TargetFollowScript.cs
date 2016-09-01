using UnityEngine;
using System.Collections;

public class TargetFollowScript : MonoBehaviour {

    public GameObject target;
    public float offset;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, target.transform.position.y + offset, transform.position.z);
	
	}
}
