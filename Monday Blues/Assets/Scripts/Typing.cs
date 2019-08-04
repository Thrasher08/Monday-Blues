using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Typing : MonoBehaviour
{
    // Start is called before the first frame update#

    public string response;
    public TextMeshProUGUI inputResponse;
    public TextMeshProUGUI responseShadow;
    public float speed = 0.05f;
    int rLength;
    int index;

    public bool isResponseReady;

    public Messages messagesScript;

    void Start()
    {
        index = 0;
        rLength = response.Length;
        isResponseReady = false;

        inputResponse.text = "";
        responseShadow.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(ableToType);
        if (messagesScript.waitingForResponse == true)
        {
            if (responseShadow.text != response)
            {
                responseShadow.text = response;
            }

            if (Input.anyKeyDown)
            {
                if (Input.GetMouseButtonDown(0)
                 || Input.GetMouseButtonDown(1)
                 || Input.GetMouseButtonDown(2))
                {
                    return;
                }

                if (index > rLength - 1)
                {
                    Debug.Log("Finished Word");
                }
                else
                {
                    typeMessage(response);
                    index++;
                }
            }
        }

        if (inputResponse.text == response)
        {
            isResponseReady = true;
        }
        else
        {
            isResponseReady = false;
        }

    }

    public void typeMessage(string response)
    {
        //Debug.Log(response + index);
        inputResponse.text += response[index];
    }

    public void clearResponse ()
    {
        index = 0;
        inputResponse.text = "";
        responseShadow.text = "";
    }

    /*private IEnumerator AnimateTypingCoroutine(string response)
    {
        for (int i = 0; i < response.Length; i++)
        {
            inputResponse.text += response[i];
            i++;
        }

        yield return new WaitForSeconds(speed);
    }*/
}
