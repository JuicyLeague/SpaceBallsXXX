using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {
    float dpiScale;                                                              // px = dp * (dpi / 160)
    Touch touch;
    bool fingerTrack, cancelSwipe = false;                                     
    public float swipeOffsetX, swipeOffsetY = 50F;
    Vector2 startTouchPosition, currentTouchPosition;

    PlayerScript playerScript;
    GameObject GameManager;
    AbilityHolder UpAbility, DownAbility, DoubleAbility;

    void GameManagerInitialization()
    {
        GameManager = GameObject.Find("GameManager");
        foreach (AbilityHolder i in GameManager.GetComponents<AbilityHolder>())
        {
            switch (i.HolderMove)
            {
                case AbilityHolder.AbilityHolderMove.Up:
                    UpAbility = i;
                    break;

                case AbilityHolder.AbilityHolderMove.Down:
                    DownAbility = i;
                    break;

                case AbilityHolder.AbilityHolderMove.Double:
                    DoubleAbility = i;
                    break;

                default:
                    break;

            }
        }
    }

    void Start () {
        GameManagerInitialization();
        playerScript = GameObject.Find("Player").GetComponent<PlayerScript>();

        dpiScale = GetComponent<DPIScript>().DP_SCALE;
        print("DPI scale: " + dpiScale);
        swipeOffsetX = swipeOffsetX * dpiScale;
        swipeOffsetY = swipeOffsetY * dpiScale;
    }
	
	void Update () {

        // Простой контроллер на PC для тестов
        if (Input.GetKeyDown(KeyCode.W))
            UpAbility.currentAbility.ActivateAbility = true;
        if (Input.GetKeyDown(KeyCode.Space))
            DownAbility.currentAbility.ActivateAbility = true;
        if (Input.GetKeyDown(KeyCode.F))
            DoubleAbility.currentAbility.ActivateAbility = true;




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
                        if (UpAbility!= null)
                            UpAbility.currentAbility.ActivateAbility = true;
                        // up move
                    else
                        if (DownAbility != null)
                            DownAbility.currentAbility.ActivateAbility = true;
                        //down move
                    cancelSwipe = true;
                }
            }
        }

        if (Input.touchCount > 1)
            cancelSwipe = true;
        if (Input.touchCount == 0)
            cancelSwipe = false;                            // Swipe end

        if (touch.tapCount == 2)            // Дабл тап переделать, дефолтный метод юнити полное говно
        {
            // Double tap action
            if (DoubleAbility != null)
                DoubleAbility.currentAbility.ActivateAbility = true;
            
        }
    }
    void FixedUpdate()
    {

        /* print(startTouchPosition.x);
         print(currentTouchPosition);*/ 
    }
}
