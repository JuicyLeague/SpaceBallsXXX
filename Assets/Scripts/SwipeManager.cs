using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {
    float dpiScale;                                                              // px = dp * (dpi / 160)
    Touch touch;
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
        print("DPI scale: " + dpiScale);
        swipeOffsetX = swipeOffsetX * dpiScale;
        swipeOffsetY = swipeOffsetY * dpiScale;
    }
	
	void Update () {
        if (Input.touchCount > 0)
            touch = Input.GetTouch(0);

        if (Input.touchCount == 1 & cancelSwipe == false)                                   // Swipe start
        {  
            if (touch.phase == TouchPhase.Began)
            {
                startTouchPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                currentTouchPosition = touch.position;
                if (Mathf.Abs(currentTouchPosition.x - startTouchPosition.x)> swipeOffsetX)
                {
                    if (currentTouchPosition.x > startTouchPosition.x)
                        playerScript.TurnRight();
                    else
                        playerScript.TurnLeft();

                    cancelSwipe = true;
                }

                if (Mathf.Abs(currentTouchPosition.y - startTouchPosition.y) > swipeOffsetY)
                {
                    if (currentTouchPosition.y > startTouchPosition.y)
                        dashScript.upSwipe = true;
                    // up move
                    else
                        slowMoScript.downSwipe = true;
                    //down move
                    cancelSwipe = true;
                }
            }
        }

        if (Input.touchCount > 1)
            cancelSwipe = true;
        if (Input.touchCount == 0)
            cancelSwipe = false;                            // Swipe end

        if (touch.tapCount == 2)
        {
            // Double tap action
            ShootingScript.Fire(playerScript.equipment, playerScript.transform.position);  // Огонь
            // Привязку делать не стал, т.к. метод static. К нему напрямую ссылаться можно, без потери ресурсов.
        }
    }
    void FixedUpdate()
    {

        /* print(startTouchPosition.x);
         print(currentTouchPosition);*/ 
    }
}
