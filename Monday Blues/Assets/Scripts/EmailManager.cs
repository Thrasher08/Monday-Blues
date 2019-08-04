using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EmailManager : MonoBehaviour
{

    public int windowIndex;
    public WindowManager windowManager;

    public bool isRunning;

    public float replyTime;
    public float replyTimer;
    public Image replyTimerImage;

    public float lockoutTime;
    public float lockoutTimer;
    public GameObject lockoutScreen;
    public Text lockoutTimerText;

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

        lastEIndex = -1;

        NextEmail();

        lockoutScreen.SetActive(false);
    }

    void Update()
    {
        if (isRunning == true)
        {
            replyTimer = replyTimer - Time.deltaTime;
            replyTimerImage.fillAmount = replyTimer / replyTime;

            if (replyTimer <= 0.0f)
            {
                Lockout();
            }
        }
        else if (isRunning == false)
        {

            lockoutTimer = lockoutTimer - Time.deltaTime;
            lockoutTimerText.text = Mathf.CeilToInt(lockoutTimer).ToString() + "s Left!";

            if (lockoutTimer <= 0.0f)
            {
                
                isRunning = true;

                NextEmail();

                lockoutScreen.SetActive(false);

            }
        }

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
            Lockout();
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
            Lockout();
        }
    }

    public void NextEmail ()
    {
        lastEIndex = eIndex;
        eRandomiser();
        eName.text = emails[eIndex].name;
        eSubject.text = emails[eIndex].subject;
        eMessage.text = emails[eIndex].message;

        replyTimer = replyTime;
    }

    public void Lockout ()
    {
        isRunning = false;

        lockoutScreen.SetActive(true);

        lockoutTimer = lockoutTime;

        windowManager.SetFrontWindow(windowIndex);
    }

    
}
