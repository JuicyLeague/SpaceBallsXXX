using UnityEngine;
using System.Collections;

public class ShieldScript : MonoBehaviour {

   /* private GameObject player;
    private EquipmentScript equipScript;

    // Use this for initialization
    void Start ()
    {
        player = GameObject.Find("Player");
        equipScript = player.GetComponent<PlayerScript>().equipScript;
        equipScript.left_to = equipScript.duration;
        gameObject.transform.parent = player.transform;
        transform.position = player.transform.position + new Vector3(0, 1, 0);
    }


    void FixedUpdate()
    {
        if (equipScript.left_to > 0)
        {
            equipScript.left_to -= Time.deltaTime;
        }
        else
        {
            equipScript.left_to = equipScript.duration;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }*/
}
