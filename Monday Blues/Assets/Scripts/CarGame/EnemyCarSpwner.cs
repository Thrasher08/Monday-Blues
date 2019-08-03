using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCarSpwner : MonoBehaviour
{

    public bool isRunning;

    public GameObject enemyCarPrefab;

    public RectTransform spawnPoint1;
    public RectTransform spawnPoint2;
    public RectTransform spawnPoint3;

    public float minWaitTime;
    public float maxWaitTime;

    public float waitTimer;


    // Start is called before the first frame update
    void Start()
    {
        isRunning = true;
        waitTimer = Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == false)
        {
            return;
        }

        if (waitTimer > 0.0f)
        {
            waitTimer = waitTimer - Time.deltaTime;
        }
        else if (waitTimer <= 0.0f)
        {
            SpawnEnemyCar();
            waitTimer = Random.Range(minWaitTime, maxWaitTime);
        }
    }

    public void SpawnEnemyCar ()
    {
        int spawnPoint = Random.Range(0, 3); //0, 1, or 2

        GameObject newEnemyCar = Instantiate(enemyCarPrefab, this.transform);

        if (spawnPoint == 0)
        {
            newEnemyCar.GetComponent<RectTransform>().localPosition = spawnPoint1.localPosition;
        }
        else if (spawnPoint == 1)
        {
            newEnemyCar.GetComponent<RectTransform>().localPosition = spawnPoint2.localPosition;
        }
        else if (spawnPoint == 2)
        {
            newEnemyCar.GetComponent<RectTransform>().localPosition = spawnPoint3.localPosition;
        }
    }

    public void Stop()
    {
        isRunning = false;
    }
    public void Restart()
    {
        isRunning = true;
        waitTimer = Random.Range(minWaitTime, maxWaitTime);
    }
}
