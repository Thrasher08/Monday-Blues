using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Messages : MonoBehaviour
{

    public int windowIndex;
    public WindowManager windowManager;

    public TextMeshProUGUI userResponse;
    public List<TextMeshProUGUI> messageOrder;

    public GameObject messageContainer;
    public GameObject defaultTextObject;

    public string[] messages;
    public int mIndex;
    public int lastMIndex;

    public float messageTypingSpeed = 0.05f;

    public bool waitingForNewMessage;
    public float newMessageTime;
    public float newMessageTimer;

    public bool waitingForResponse;
    public float responseTime;
    public float responseTimer;

    public bool isLockedOut;
    public float lockoutTime;
    public float lockoutTimer;

    public Typing typingScript;

    public GameObject failedScreen;
    public Text waitTimerText;

    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        userResponse.text = "";
        foreach (TextMeshProUGUI textbox in messageOrder)
        {
            textbox.text = "";
        }

        lastMIndex = -1;
        mRandomiser();
        timeMessage();

        waitingForResponse = true;
        waitingForNewMessage = false;
        isLockedOut = false;

        failedScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (waitingForResponse == true)
        {

            responseTimer = responseTimer + Time.deltaTime;

            if (responseTimer > responseTime)
            {
                ResponseMissed();
            }

        }
        else if (waitingForNewMessage == true)
        {
            newMessageTimer = newMessageTimer + Time.deltaTime;

            if (newMessageTimer > newMessageTime)
            {
                timeMessage();
            }
        }
        else if (isLockedOut == true)
        {
            lockoutTimer = lockoutTimer - Time.deltaTime;

            waitTimerText.text = Mathf.CeilToInt(lockoutTimer).ToString() + "s Left!";

            if (lockoutTimer <= 0)
            {
                isLockedOut = false;
                waitingForNewMessage = true;

                newMessageTimer = 0;
                responseTimer = 0;

                failedScreen.SetActive(false);
            }
        }

    }

    public void mRandomiser()
    {
        int i = 0;
        while (mIndex == lastMIndex && i < 10)
        {
            mIndex = Random.Range(0, messages.Length);
            i++;
        }

    }

    public void PushUpMessages ()
    {
        GameObject temp = messageOrder[0].gameObject;
        messageOrder.RemoveAt(0);
        Destroy(temp); //destroy top text object

        GameObject newTMP = Instantiate(defaultTextObject, messageContainer.transform);
        messageOrder.Add(newTMP.GetComponent<TextMeshProUGUI>());

    }

    public void trySubmitResponse()
    {
        if (waitingForResponse == false)
        {
            Debug.LogWarning("No Response Needed Yet");
            return;
        }

        if (typingScript.isResponseReady == false)
        {
            Debug.LogWarning("Response is not Ready Yet");
            return;
        }

        Debug.Log("Submitted Response");

        PushUpMessages();

        messageOrder[messageOrder.Count - 1].text = userResponse.text;
        messageOrder[messageOrder.Count - 1].alignment = TextAlignmentOptions.Right;

        userResponse.text = "";

        waitingForNewMessage = true;
        waitingForResponse = false;

        responseTimer = 0.0f;
        newMessageTimer = 0.0f;

        typingScript.clearResponse();

        ResponseSuccessful();
    }

    public void submitFailedResponse ()
    {
        PushUpMessages();

        messageOrder[messageOrder.Count - 1].text = "[This User Failed To Respond To Your Message]";
        messageOrder[messageOrder.Count - 1].alignment = TextAlignmentOptions.Right;

    }

    public void timeMessage()
    {
        Debug.Log("New Message");

        PushUpMessages();

        AnimateDialogueBox(messages[mIndex], messageOrder[messageOrder.Count - 1]);

        waitingForNewMessage = false;
        waitingForResponse = true;

        responseTimer = 0.0f;
        newMessageTimer = 0.0f;

        audio.Play();

        typingScript.clearResponse();
    }

    public void AnimateDialogueBox(string dialogue, TextMeshProUGUI textBox)
    {
        if (textBox == null)
        {
            Debug.LogError("Non-Existat TextBox");
            return;
        }

        //Debug.Log("Work please");
        lastMIndex = mIndex;
        mRandomiser();
        StartCoroutine(AnimateTextCoroutine(dialogue, textBox));
    }

    private IEnumerator AnimateTextCoroutine(string dialogue, TextMeshProUGUI textBox)
    {
        textBox.text = "";
        int i = 0;

        while (i < dialogue.Length)
        {
            if (textBox == null)
            {
                Debug.LogWarning("Non-Existat TextBox");
                break;
            }

            textBox.text += dialogue[i];

            i++;

            yield return new WaitForSeconds(messageTypingSpeed);
        }
        yield return null;
    }

    public void ResponseMissed()
    {
        //lockout
        //wait for new message

        Debug.Log("Response Missed");

        submitFailedResponse();
        

        lockoutTimer = lockoutTime;

        isLockedOut = true;
        waitingForNewMessage = false;
        waitingForResponse = false;

        failedScreen.SetActive(true);

        windowManager.SetFrontWindow(windowIndex);

        typingScript.clearResponse();

    }

    public void ResponseSuccessful()
    {
        //wait for new message
        Debug.Log("Response Successful");

        waitingForNewMessage = true;
        waitingForResponse = false;

        responseTimer = 0;
        newMessageTimer = 0;

        typingScript.clearResponse();
    }

}
