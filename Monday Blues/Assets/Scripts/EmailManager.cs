using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailManager : MonoBehaviour
{
    public bool isRunning;

    public float waitTime;
    public float waitTimer;

    public GameObject failedScreen;
    public Text waitTimerText;

    [System.Serializable]
    public class Email
    {
        public string name;
        public string subject;
        public string message;

        public bool confirm;
    }

    public Email[] emails;

    public TextMeshProUGUI eName;
    public TextMeshProUGUI eSubject;
    public TextMeshProUGUI eMessage;

    public int eIndex;
    public int lastEIndex;

    private void Start()
    {
        eRandomiser();
        eName.text = emails[eIndex].name;
        eSubject.text = emails[eIndex].subject;
        eMessage.text = emails[eIndex].message;

        failedScreen.SetActive(false);
    }

    public void eRandomiser()
    {
        int i = 0;
        while (eIndex == lastEIndex && i < 10)
        {
            eIndex = Random.Range(0, 6);
            i++;
        }
                
    }

    public void confirmEmail()
    {
        if (emails[eIndex].confirm)
        {
            Debug.Log("CORRECT CONFIRM");
            NextEmail();
        } else
        {
            Debug.Log("INCORRECT CONFIRM");
            FailedEmail();
        }
    }

    public void denyEmail()
    {
        if (!emails[eIndex].confirm)
        {
            Debug.Log("CORRECT DENY");
            NextEmail();
        }
        else
        {
            Debug.Log("INCORRECT DENY");
            FailedEmail();
        }
    }

    public void NextEmail ()
    {
        lastEIndex = eIndex;
        eRandomiser();
        eName.text = emails[eIndex].name;
        eSubject.text = emails[eIndex].subject;
        eMessage.text = emails[eIndex].message;
    }

    public void FailedEmail ()
    {
        isRunning = false;

        failedScreen.SetActive(true);

        waitTimer = waitTime;
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

                NextEmail();

                failedScreen.SetActive(false);

            }
        }
    }
}
