using UnityEngine;
using System.Collections;

public class SwipeManager : MonoBehaviour {

	// Use this for initialization                          // Under development
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            print(touchDeltaPosition);
        }
    }
}
