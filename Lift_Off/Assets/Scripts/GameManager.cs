using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject asteroid, rocket, fuel;
    public Text fuelText;
    public Canvas GameOverCanvas;
    public float fuel_level;

    private bool rocketAlive = true;
    private float timer_s, timer_m, timer_l, time_fuel;
    private GameObject newAsteroid, newFuel;
    private float x, y;
    private Camera camera2d;    //чтобы взять координаты для генерации астероидов
    private int distance = 0;
    private float scoreTime = 1;

	// Use this for initialization
	public void Start () {
        rocketAlive = true;
        timer_s = 3;
        timer_m = 4;
        timer_l = 5;
        camera2d = FindObjectOfType<Camera>();
        rocket.transform.position = new Vector3(0, -2.58f, 0);
        GameOverCanvas.gameObject.SetActive(false);
        fuel_level = 300;
        fuelText = GameObject.Find("HUD/Fuel Text Obj").GetComponent<Text>();
    }

    public void GameOver()
    {
        rocketAlive = false;
        GameOverCanvas.gameObject.SetActive(true);
    }

	// Update is called once per frame
	void Update ()
    {
        if (rocketAlive)
        {
            GenerateAsteroids();

            fuel_level -= 1;
            fuelText.text = "Fuel: " + fuel_level.ToString();
            if (fuel_level <= 0)
            {
                GameOver();
            }
            time_fuel -= 1 * Time.deltaTime;
            if (time_fuel <= 0)
            {
                time_fuel = 3;
                newFuel = Instantiate(fuel, new Vector3(0, -100), Quaternion.identity) as GameObject;
            }
        }

    }

    private void GenerateAsteroids()
    {
        timer_s -= 1 * Time.deltaTime;
        timer_m -= 1 * Time.deltaTime;
        timer_l -= 1 * Time.deltaTime;
        if (timer_s <= 0)
        {
            timer_s = Random.Range(1f, 2f);
            x = Random.Range(-3f, 3f);
            y = camera2d.transform.position.y + 7;
            newAsteroid = Instantiate(asteroid, new Vector3(x, y), Quaternion.identity) as GameObject;
            newAsteroid.name = "s_asteroid";
        }
        if (timer_m <= 0)
        {
            timer_m = Random.Range(3, 4);
            x = Random.Range(-3f, 3f);
            y = camera2d.transform.position.y + 7;
            newAsteroid = Instantiate(asteroid, new Vector3(x, y), Quaternion.identity) as GameObject;
            newAsteroid.name = "m_asteroid";
        }
        if (timer_l <= 0)
        {
            timer_l = Random.Range(5, 8);
            x = Random.Range(-3f, 3f);
            y = camera2d.transform.position.y + 7;
            newAsteroid = Instantiate(asteroid, new Vector3(x, y), Quaternion.identity) as GameObject;
            newAsteroid.name = "l_asteroid";
        }
    }
}
