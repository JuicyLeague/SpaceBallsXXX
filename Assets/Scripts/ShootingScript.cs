using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

    public static void Fire()
    {
        GameObject ammo = Resources.Load("Ammo") as GameObject;
        //GameObject player = GameObject.Find("Player");
        PlayerScript playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();

        if (playerScript.reloading == 0)
        {
            Instantiate(ammo, playerScript.gameObject.transform.position, Quaternion.identity);
            playerScript.reloading = 3;
        }

    }
}
