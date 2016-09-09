using UnityEngine;
using System.Collections;

public class CoinScript : MonoBehaviour {

	// Use this for initialization
	
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
    }

   

}
