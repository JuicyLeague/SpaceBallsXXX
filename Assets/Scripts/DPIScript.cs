using UnityEngine;
using System.Collections;

public class DPIScript : MonoBehaviour {

    [HideInInspector]
    public float DP_SCALE;
    int[] Density = new int[5] { 120, 160, 240, 320, 480 };  // dpi
    Vector2 mPos, mPos2;
    public GameObject sphere;

    float CalculateDensity()
    {

        int p1, minDifference, minDifferencePos;
        minDifference = Mathf.Abs(Density[0] - (int)Screen.dpi);
        minDifferencePos = Density[0];



        for (int i = 1; i <= 4; i++)
        {
            p1 = Mathf.Abs(Density[i] - (int)Screen.dpi);
            
            if (p1 < minDifference)
            {
                minDifference = p1;
                minDifferencePos = Density[i];
            }
        }
        return (float)minDifferencePos / 160;               // px = dp * (dpi / 160)
    }


	void Awake () {
        DP_SCALE = CalculateDensity();

        



    }


	
	// Update is called once per frame
	void Update () {
      /*  if (Input.GetMouseButtonDown(0))
        {
            mPos = Input.mousePosition;
            mPos2 = Input.mousePosition;
            mPos2.x += 72F / DP_SCALE;
            mPos = Camera.main.ScreenToWorldPoint(mPos);
            mPos2 = Camera.main.ScreenToWorldPoint(mPos2);
            Instantiate(sphere, mPos, Quaternion.identity);
            
            Instantiate(sphere, mPos2, Quaternion.identity);
        }
        */

        


    }
}
