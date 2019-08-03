using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EmailManager : MonoBehaviour
{
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

    private void Start()
    {
        eRandomiser();
        eName.text = emails[eIndex].name;
        eSubject.text = emails[eIndex].subject;
        eMessage.text = emails[eIndex].message;
    }

    public void eRandomiser()
    {
        eIndex = Random.Range(0, 6);
    }

    public void confirmEmail()
    {
        if (emails[eIndex].confirm)
        {
            Debug.Log("CORRECT CONFIRM");
        } else
        {
            Debug.Log("INCORRECT CONFIRM");
        }
    }

    public void denyEmail()
    {
        if (!emails[eIndex].confirm)
        {
            Debug.Log("CORRECT DENY");
        }
        else
        {
            Debug.Log("INCORRECT DENY");
        }
    }
}
