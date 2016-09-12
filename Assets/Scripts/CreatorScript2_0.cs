using UnityEngine;
using System.Collections;
using System.Collections.Generic; // 

public class CreatorScript2_0 : MonoBehaviour {
    List<GameObject> freeePool = new List <GameObject>(); // динамический массив для пула
    List<GameObject> engagedPool = new List<GameObject>();


    public GameObject[] Patterns;       // массив с паттернами
    public float Tick;
    public int minCondition, maxCondition;
    int condition;
    float lastPosition;
    float timer;
    // Use this for initialization
    void Awake()
    {
        timer = Tick;
        lastPosition = transform.position.y;
        Spawn();
        condition = Random.Range(minCondition, maxCondition);

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        timer -= Time.fixedDeltaTime;
        if (timer < 0)
        {
            if (transform.position.y - lastPosition > condition)            // спавн препятсвий через определенное кол-во метров
            {
                Spawn();
                timer = Tick;
                lastPosition = transform.position.y;
                condition = Random.Range(minCondition, maxCondition);
            }
        }
    }

    void Spawn()
    {
        if (freeePool.Count == 0)
            Instantiate(Patterns[Random.Range(0, Patterns.GetLength(0))], transform.position, Quaternion.identity);
        else
        {
            
            
               
        }
    }
}
