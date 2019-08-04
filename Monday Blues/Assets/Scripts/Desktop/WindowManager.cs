using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    public Canvas desktop;
    public List<Canvas> windows;

    public bool showDesktop;
    public int activeWindow;

    public ParticleSystem clickEffect;

    private void Start()
    {
        showDesktop = false;
        activeWindow = 0;

        for (int i = 0; i < windows.Count; i++)
        {
            if (i == 0)
            {
                windows[i].sortingOrder = 1;
            }
            else
            {
                windows[i].sortingOrder = -1;
            }
        }
    }

    public void SetFrontWindow(int _windowNum)
    {

        if (_windowNum < 0 || _windowNum > windows.Count - 1)
        {

            Debug.LogError("Invalid Window Num");
            return;

        }

        if (activeWindow == _windowNum)
        {
            Debug.LogWarning("Already the active window");
            return;
        }

        for (int i = 0; i < windows.Count; i++)
        {

            if (i == _windowNum)
            {
                windows[i].sortingOrder = 1;
            }
            else
            {
                windows[i].sortingOrder = -1;
            }

        }

        activeWindow = _windowNum;

    }

    public void ActivateWindow(int _windowNum)
    {

        if (_windowNum < 0 || _windowNum > windows.Count - 1)
        {

            Debug.LogError("Invalid Window Num");
            return;

        }

        Vector2 mousePosT = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        //Transform mousePos = mousePosT
        //Instantiate(clickEffect, Input.mousePosition);
        windows[_windowNum].gameObject.SetActive(true);
        SetFrontWindow(_windowNum);

    }

}
