using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messages_Old : MonoBehaviour
{
    public TextMeshProUGUI userResponse;
    public TextMeshProUGUI[] messageOrder;
    public string[] messages;
    public int mIndex;
    public int lastMIndex;

    float timer;
    float speed = 0.05f;

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
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 15f)
        {
            timeMessage();
            timer = 0.0f;
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

    public void submitResponse()
    {
        messageOrder[5].text = messageOrder[4].text;
        messageOrder[4].text = messageOrder[3].text;
        messageOrder[3].text = messageOrder[2].text;
        messageOrder[2].text = messageOrder[1].text;
        messageOrder[1].text = messageOrder[0].text;
        messageOrder[0].text = userResponse.text;

        userResponse.text = "";
    }

    public void timeMessage()
    {
        messageOrder[5].text = messageOrder[4].text;
        messageOrder[4].text = messageOrder[3].text;
        messageOrder[3].text = messageOrder[2].text;
        messageOrder[2].text = messageOrder[1].text;
        messageOrder[1].text = messageOrder[0].text;

        AnimateDialogueBox(messages[mIndex]);           //NEEDS TO BE AUTOMATED OVERTIME
    }

    public void AnimateDialogueBox(string dialogue)
    {
        //Debug.Log("Work please");
        lastMIndex = mIndex;
        mRandomiser();
        StartCoroutine(AnimateTextCoroutine(dialogue));
    }

    private IEnumerator AnimateTextCoroutine(string dialogue)
    {
        messageOrder[0].text = "";
        int i = 0;

        while (i < dialogue.Length)
        {
            messageOrder[0].text += dialogue[i];

            i++;

            yield return new WaitForSeconds(speed);
        }
    }

}
