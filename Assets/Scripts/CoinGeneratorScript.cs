using UnityEngine;
using System.Collections;

public class CoinGeneratorScript : MonoBehaviour {
    private int[] line = new int[] { -4, -2, 0, 2, 4 };
    public GameObject coin;
    public int minRow, maxRow;
    int currentRow;
    public float condition;
    public float spawnTimer;
    float lastCoinPos;

    bool canCreate = true;

    float timer;

	// Use this for initialization
	void Start () {
        timer = spawnTimer;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {


            if ((transform.position.y - lastCoinPos > condition) & canCreate == true)
            {
                canCreate = false;

                CreateRow();
            }
        
	
	}

    void CreateRow()
    {
        currentRow = Random.Range(minRow, maxRow);
        for (int i = 1; i <= currentRow; i++)
        {

            Instantiate(coin, new Vector3(line[Random.Range(0,line.Length)], transform.position.y + i, 0), Quaternion.identity);
            if (i == currentRow)
                lastCoinPos = transform.position.y;
        }
        canCreate = true;

    }

}
