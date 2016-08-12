using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ButtonEvents : MonoBehaviour {

    public GameManager gM;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LiftOff()
    {
        //Application.LoadLevel("RocketScene");
        SceneManager.LoadScene("RocketScene");
    }

    public void Retry()
    {
        gM.Start();
    }
}
