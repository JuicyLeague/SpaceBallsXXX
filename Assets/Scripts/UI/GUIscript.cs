using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {
    public Rect deathCount;
    public Rect speedLvl;
    public Rect coinCount;
    public GameObject universe;
    public GameObject player; // Убрать в будущем




    

    void OnGUI()
    {
        GUI.Label(deathCount, "Death counter: " + player.GetComponent<PlayerScript>().deathcount);     // Подлежит удалению
        GUI.Label(speedLvl, "SpeedLvl: " + Mathf.Round(universe.GetComponent<Rigidbody2D>().velocity.magnitude));
        GUI.Label(coinCount, "Coins: " + player.GetComponent<PlayerScript>().currentCoins);     
    }
}
