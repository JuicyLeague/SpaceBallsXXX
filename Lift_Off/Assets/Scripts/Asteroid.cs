using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {


    private int rotationSpeed, velocity;
    private float size;
    private Camera camera2d;
    private float route;

	// Use this for initialization
	void Start () {
        camera2d = FindObjectOfType<Camera>();
        rotationSpeed = Random.Range(50, 200);
        velocity = getVelocity(gameObject) * 2;
        size = getSize(gameObject);
        gameObject.transform.localScale = new Vector3(size, size, 1);
        setRoute();
    }

    private float getSize(GameObject ast) {
        float retSize;

        retSize = 0.3f;
        if (ast.name == "s_asteroid") 
            retSize = Random.Range(0.1f, 0.2f);
        if (ast.name == "m_asteroid")
            retSize = Random.Range(0.3f, 0.4f);
        if (ast.name == "l_asteroid")
            retSize = Random.Range(0.5f, 1f);

        return retSize;
    }

    private int getVelocity(GameObject ast)
    {
        int retVel;

        retVel = 3;
        if (ast.name == "s_asteroid")
            retVel = Random.Range(3, 4);
        if (ast.name == "m_asteroid")
            retVel = Random.Range(2, 3);
        if (ast.name == "l_asteroid")
            retVel = Random.Range(1, 3);

        return retVel;
    }

    void setRoute()
    {
        if (gameObject.transform.position.x <= -1)
            route = -1;
        else if (gameObject.transform.position.x >= 1)
            route = 1;
        else
            route = Random.Range(-0.5f, 0.5f);
    }

	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.y <= camera2d.transform.position.y - 10)
        {
            Destroy(gameObject);
        }
        
        gameObject.transform.position -= new Vector3(route * Time.deltaTime, velocity * Time.deltaTime, 0);
        gameObject.transform.Rotate(new Vector3(0, 0, rotationSpeed) * Time.deltaTime);

    }
    
}
