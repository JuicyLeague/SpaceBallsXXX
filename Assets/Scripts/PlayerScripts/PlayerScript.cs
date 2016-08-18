using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    public int deathcount = 0;
    bool moving = false;
    private float yVelocity = 0.0F;
    public float smoothTime = 0.1F;

     float targetFloat;
    public int current_line = 3;

    void Start()
    {

    }


    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.A) & current_line != 1 )
            {
            current_line -= 1;
            targetFloat =  (current_line-2) * 2 - 2;     
            }

        if (Input.GetKeyDown(KeyCode.D) & current_line != 5)
        {
            current_line += 1;
            targetFloat = (current_line - 2) * 2 - 2;
        }

      
            float newPosition = Mathf.SmoothDamp(transform.position.x, targetFloat , ref yVelocity, smoothTime);
            transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);

        


    }


    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Application.LoadLevel(0);
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            deathcount += 1;
        }
    }

   

}
