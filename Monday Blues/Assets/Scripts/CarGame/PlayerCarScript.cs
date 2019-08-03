using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCarScript : MonoBehaviour
{
    public bool isRunning;

    public CarGameController controller;

    public RectTransform rect;
    int position; // 1 = top, 0 = middle, -1 = bottom

    void Start()
    {
        position = 0;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning == false)
        {
            return;
        }

        if (Input.GetKeyDown("up"))
        {
            MoveUp();
        }
        else if (Input.GetKeyDown("down"))
        {
            MoveDown();
        }
    }

    public void CentreCar ()
    {
        if (position == 1)
        {
            position = 0;
            //move to mid

            rect.localPosition = rect.localPosition + new Vector3(0.0f, -100.0f, 0.0f);
        }
        else if (position == 0)
        {
            return;
        }
        else if (position == -1)
        {
            position = 0;
            //move to mid

            rect.localPosition = rect.localPosition + new Vector3(0.0f, 100.0f, 0.0f);
        }
    }

    public void MoveUp()
    {
        if (position == 1)
        {
            return;
        }
        else if (position == 0)
        {
            position = 1;
            //move to top

            rect.localPosition = rect.localPosition + new Vector3(0.0f, 100.0f, 0.0f);
        }
        else if (position == -1)
        {
            position = 0;
            //move to mid

            rect.localPosition = rect.localPosition + new Vector3(0.0f, 100.0f, 0.0f);
        }
    }
    public void MoveDown()
    {
        if (position == -1)
        {
            return;
        }
        else if (position == 0)
        {
            position = -1;
            //move to bottom

            rect.localPosition = rect.localPosition + new Vector3(0.0f, -100.0f, 0.0f);
        }
        else if (position == 1)
        {
            position = 0;
            //move to mid

            rect.localPosition = rect.localPosition + new Vector3(0.0f, -100.0f, 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
                
        if (collision.tag == "Enemy Car")
        {
            //trigger failure
            controller.CarCrashed();
        }
    }

    public void Stop()
    {
        isRunning = false;
    }
    public void Restart()
    {
        isRunning = true;
        CentreCar();
    }

}
