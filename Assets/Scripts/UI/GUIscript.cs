using UnityEngine;
using System.Collections;

public class GUIscript : MonoBehaviour {

    public Rect deathCount;
    public Rect speedLvl;
    public Rect coinCount, fuelCapacity;
    public Rect upAbility;
    public Rect doubleAbility;
    public Rect downAbility;
    public GameObject universe;
    public GameObject player;


    void OnGUI()
    {
        GUI.Label(deathCount, "Death counter: " + player.GetComponent<PlayerScript>().deathcount);     // Подлежит удалению
        GUI.Label(speedLvl, "SpeedLvl: " + Mathf.Round(universe.GetComponent<Rigidbody2D>().velocity.magnitude));
        GUI.Label(coinCount, "Coins: " + player.GetComponent<PlayerScript>().currentCoins);
        GUI.Label(fuelCapacity, "Capacity: " + player.GetComponent<CoinGrabberScript>().fuelCapacity);
        /*GUI.Label(upAbility, "UpReloading: " + universe.GetComponent<SwipeManager>().UpAbility.currentAbility.currentTimer);
        GUI.Label(doubleAbility, "DoubleReloading: " + universe.GetComponent<SwipeManager>().DoubleAbility.currentAbility.currentTimer);
        GUI.Label(downAbility, "DownReloading: " + universe.GetComponent<SwipeManager>().DownAbility.currentAbility.currentTimer);*/
    }
}
