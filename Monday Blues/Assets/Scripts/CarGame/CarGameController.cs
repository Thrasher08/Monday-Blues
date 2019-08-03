using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarGameController : MonoBehaviour
{
    public bool isRunning;

    public float waitTime;
    public float waitTimer;

    public PlayerCarScript playerCar;
    public EnemyCarSpwner enemySpawner;
    public DestroyEnemyCars enemyCleanup;
    public AudioSource audio;

    public GameObject failedScreen;
    public Text waitTimerText;

    void Start()
    {
        failedScreen.SetActive(false);
        isRunning = true;
    }

    void Update()
    {
        
        if (isRunning == false)
        {

            waitTimer = waitTimer - Time.deltaTime;
            waitTimerText.text = Mathf.CeilToInt(waitTimer).ToString() + "s Left!";

            if (waitTimer <= 0.0f)
            {


                isRunning = true;

                playerCar.Restart();
                enemySpawner.Restart();

                failedScreen.SetActive(false);

            }
        }

        

    }

    public void CarCrashed()
    {

        isRunning = false;

        playerCar.Stop();
        enemySpawner.Stop();
        audio.Play();
        enemyCleanup.DestroyCars();

        failedScreen.SetActive(true);

        waitTimer = waitTime;

    }

}
