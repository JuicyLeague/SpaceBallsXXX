using UnityEngine;
using System.Collections;

public class TimeScaleTest : MonoBehaviour {

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (Time.timeScale == 1.0F)
                Time.timeScale = 0.5F;
            else
                Time.timeScale = 1.0F;
            Time.fixedDeltaTime = 0.02F * Time.timeScale;
        }
    }
}
