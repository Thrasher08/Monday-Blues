using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TaskbarScript : MonoBehaviour
{

    public Canvas desktop;
    public List<Canvas> windows;

    public int selectedWindow = 0;

    public void SetFrontWindow(int _windowNum)
    {
        
        if (_windowNum < 0 || _windowNum > windows.Count - 1)
        {

            Debug.LogError("Invalid Window Num");
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

    }

}
