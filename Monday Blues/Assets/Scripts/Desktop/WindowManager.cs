using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{

    public Canvas desktop;
    public List<Canvas> windows;

    public bool showDesktop;
    public int activeWindow;

    private void Start()
    {
        showDesktop = false;
        activeWindow = 0;
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

        windows[_windowNum].gameObject.SetActive(true);
        SetFrontWindow(_windowNum);

    }

}
