using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FloatingCubeScript : MonoBehaviour {
    public Vector3 rot;
    public float rotChange;  // Время, после которого вращение будет изменено
    float currentTimer;
    int reverse = 1;
    bool lvlChanging = false;
    float interpolate;
    public GameObject Board1, Board2, Cam;
    float LerpBoardPosition;
    Camera camComp;
    AsyncOperation ao;
	// Use this for initialization
	void Start () {
        currentTimer = rotChange;
        camComp = Cam.GetComponent<Camera>();
        
        
    }
	
 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lvlChanging = true;
            ao = SceneManager.LoadSceneAsync(1);
            ao.allowSceneActivation = false;

        }

        if (lvlChanging)
        {
            if (interpolate >= 0.666)
                camComp.orthographic = true;
            if (interpolate >= 0.8)
            {
                ao.allowSceneActivation = true;
            }
        }
    }

	void FixedUpdate () {
        if (!lvlChanging)
        {
            currentTimer -= Time.fixedDeltaTime;
            if (currentTimer < 0)
            {
                currentTimer = rotChange;
                rot = new Vector3(rot.x * RandomSign(), rot.y * RandomSign(), rot.z * RandomSign());
            }
            transform.Rotate(rot);
        }

        if (lvlChanging)
        {
            interpolate += Time.fixedDeltaTime/3;
            transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, new Vector3(transform.eulerAngles.x - transform.eulerAngles.x%90, transform.eulerAngles.y - transform.eulerAngles.y % 90, transform.eulerAngles.z - transform.eulerAngles.z % 90), interpolate);

            LerpBoardPosition = Mathf.Lerp(Board1.transform.position.x, -2, interpolate);
            Board1.transform.position = new Vector3( LerpBoardPosition, Board1.transform.position.y, Board1.transform.position.z);
            Board2.transform.position = new Vector3( -LerpBoardPosition, Board2.transform.position.y, Board2.transform.position.z);

            Cam.transform.position = Vector3.Lerp(Cam.transform.position, new Vector3(0, 10, 0), interpolate-0.5F);
            Cam.transform.eulerAngles = Vector3.Lerp(Cam.transform.rotation.eulerAngles, new Vector3(90, 0, 0), interpolate-0.5F);
            
            
        }
    }

    int RandomSign()
    {
        return Random.Range(0, 2) * 2 - 1;
    } 
}
