using UnityEngine;
using System.Collections;

public class AmmoScript : MonoBehaviour {

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
