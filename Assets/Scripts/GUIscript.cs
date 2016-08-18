using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
    public Rect frame;
    public Rect frame2;
    public GameObject player;




    

    void OnGUI()
    {
        GUI.Label(frame, "Death counter: " + player.GetComponent<PlayerScript>().deathcount);
        GUI.Label(frame2, "SpeedLvl: " + Mathf.Round(player.GetComponent<Rigidbody2D>().velocity.magnitude));
    }
}
