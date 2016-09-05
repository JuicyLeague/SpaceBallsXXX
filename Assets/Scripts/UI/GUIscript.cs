using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
    public Rect frame;
    public Rect frame2;
    public GameObject universe;
    public GameObject player; // Убрать в будущем




    

    void OnGUI()
    {
        GUI.Label(frame, "Death counter: " + player.GetComponent<PlayerScript>().deathcount);     // Подлежит удалению
        GUI.Label(frame2, "SpeedLvl: " + Mathf.Round(universe.GetComponent<Rigidbody2D>().velocity.magnitude));
    }
}
