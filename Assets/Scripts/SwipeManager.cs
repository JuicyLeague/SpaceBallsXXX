using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {
    float dpiScale;                                                              // px = dp * (dpi / 160)
    bool fingerTrack, cancelSwipe = false;
    public float swipeOffsetX, swipeOffsetY = 50F;
    Vector2 startTouchPosition, currentTouchPosition;


    PlayerScript playerScript;
    SlowMoScript slowMoScript;
    DashScript dashScript;

	// Use this for initialization
	void Start () {
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();
        slowMoScript = GameObject.Find("Player").GetComponent<SlowMoScript>();
        dashScript = GameObject.Find("Player").GetComponent<DashScript>();
        dpiScale = GetComponent<DPIScript>().DP_SCALE;
        print(dpiScale);
        swipeOffsetX = swipeOffsetX * dpiScale;
        swipeOffsetY = swipeOffsetY * dpiScale;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.touchCount > 0)
        {
            foreach(Touch touch in Input.touches)
            {
                if (fingerTrack == false & touch.phase == TouchPhase.Began)
                {
                    fingerTrack = true;
                    startTouchPosition = touch.position;
                }
                if (fingerTrack == true & touch.phase == TouchPhase.Began)
                    cancelSwipe = true;

                if (fingerTrack == true & touch.phase == TouchPhase.Moved & cancelSwipe == false)
                {
                    currentTouchPosition = touch.position;
                    if (Mathf.Abs(currentTouchPosition.x - startTouchPosition.x)> swipeOffsetX)
                    {
                        if (currentTouchPosition.x > startTouchPosition.x)
                            playerScript.TurnRight();
                        else
                            playerScript.TurnLeft();

                        fingerTrack = false;

                    }
                    if (Mathf.Abs(currentTouchPosition.y - startTouchPosition.y) > swipeOffsetY)
                    {
                        if (currentTouchPosition.y > startTouchPosition.y)
                            dashScript.upSwipe = true;
                        // up move
                        else
                            slowMoScript.downSwipe = true;
                        //down move

                        fingerTrack = false;

                    }
                }
            }

        }
        
        if (cancelSwipe == true)
            cancelSwipe = false;
    }
    void FixedUpdate()
    {

        /* print(startTouchPosition.x);
         print(currentTouchPosition);*/ 
    }
}
