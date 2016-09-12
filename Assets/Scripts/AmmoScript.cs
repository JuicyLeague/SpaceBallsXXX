using UnityEngine;
using System.Collections;

public class AmmoScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 15);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // other.tag == "WallHolder" || 
        if (other.tag == "Wall")
        {
            Destroy(other.gameObject);  // Сменить на SetActive
            Destroy(gameObject);  // Сменить на SetActive
        }

    }
}
