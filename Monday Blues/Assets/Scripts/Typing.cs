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
    public float speed = 0.05f;
    int rLength;
    int index;
    public bool ableToType;


    void Start()
    {
        index = 0;
        rLength = response.Length;
        ableToType = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (ableToType)
        {
            if (Input.anyKeyDown)
            {
                typeMessage(response);
                index++;

                if (index > rLength)
                {
                    Debug.Log("HI");
                }
            }
        }

    }

    public void typeMessage(string response)
    {
        Debug.Log(response + index);
        inputResponse.text += response[index];
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
