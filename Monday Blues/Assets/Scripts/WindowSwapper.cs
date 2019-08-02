using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowSwapper : MonoBehaviour
{

    bool toggle = true;

    public Canvas Window1CanvasRef;
    public Canvas Window2CanvasRef;

    // Start is called before the first frame update
    void Start()
    {
        Window1CanvasRef.sortingOrder = 0;
        Window2CanvasRef.sortingOrder = -1;
        toggle = true;
    }

    // Update is called once per frame
   public void Swap()
    {
        if (toggle == true)
        {

            Window1CanvasRef.sortingOrder = -1;
            Window2CanvasRef.sortingOrder = 0;
            toggle = false;

        }
        else
        {

            Window1CanvasRef.sortingOrder = 0;
            Window2CanvasRef.sortingOrder = -1;
            toggle = true;

        }
    }
}
