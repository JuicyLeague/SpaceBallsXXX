using UnityEngine;
using System.Collections;

public class CreatorScript : MonoBehaviour {
    public GameObject[] Patterns;
    public float spawnerTimer;
    public int condition;
    float lastPosition;
    float timer;
	// Use this for initialization
	void Awake () {
        timer = spawnerTimer;
        lastPosition = transform.position.y;
        Spawn();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        timer -= Time.fixedDeltaTime;
        if (timer<0)
        {
            if (transform.position.y - lastPosition > condition)            // спавн препятсвий через определенное кол-во метровы
            {
                Spawn();
                timer = spawnerTimer;
                lastPosition = transform.position.y;
            }
        }
	}
    void Spawn()
    {
        Instantiate(Patterns[Random.Range(0, Patterns.GetLength(0))], transform.position, Quaternion.identity);
    }
}
