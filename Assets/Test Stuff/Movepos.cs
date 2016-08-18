using UnityEngine;
using System.Collections;

public class Movepos : MonoBehaviour {



    public int speed;
    public Transform kek;
    public Vector2 mmm;


    void Start()
    {
        //rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        transform.position = Vector2.Lerp((Vector2)transform.position, mmm, Time.fixedDeltaTime*speed );

        /*float newPosition = Mathf.SmoothDamp(transform.position.x, velocity.x, ref yVelocity, smoothTime);
        transform.position = new Vector3(newPosition, transform.position.y, transform.position.z);*/
    }
}
