using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowDemoScript : MonoBehaviour
{

    public float defaultTime;
    public float timer;
    public Button button;

    // Start is called before the first frame update
    void Start()
    {

        timer = defaultTime;

    }

    // Update is called once per frame
    void Update()
    {
        
        timer = timer - Time.deltaTime;

        if (timer <= 0.0f)
        {
            Debug.Log("Fail scrublord");
        }
    }

    public void Reset()
    {

        timer = defaultTime;

    }
}
