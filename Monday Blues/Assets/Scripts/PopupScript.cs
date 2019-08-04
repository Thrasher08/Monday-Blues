using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupScript : MonoBehaviour
{

    public float showHeight;
    public float hideHeight;
    public float slideDuration;
    public float showDuration;

    public RectTransform rectTrans;

    public void TriggerPopup ()
    {
        Debug.Log("Show Downloading Paused Popup");
        StartCoroutine(DisplayPopup());
    }

    IEnumerator DisplayPopup ()
    {
        Show();
        yield return new WaitForSeconds(slideDuration + showDuration);
        Hide();
    }

    public void Show ()
    {
        StartCoroutine(SlidePopup(hideHeight, showHeight, slideDuration));
    }

    public void Hide ()
    {
        StartCoroutine(SlidePopup(showHeight, hideHeight, slideDuration));
    }

    IEnumerator SlidePopup(float _startHeight, float _endHeight, float _duration)
    {

        float timer = 0.0f;

        while (timer < _duration)
        {
            timer = timer + Time.deltaTime;
            rectTrans.anchoredPosition = new Vector3(rectTrans.anchoredPosition.x, Mathf.Lerp(_startHeight, _endHeight, timer / _duration));
            yield return new WaitForEndOfFrame();
        }

        yield return null;
    }
}
