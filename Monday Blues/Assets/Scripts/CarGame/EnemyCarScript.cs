using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCarScript : MonoBehaviour
{

    public float speed;
    public RectTransform rect;

    private void Update()
    {

        rect.localPosition = rect.localPosition + new Vector3(Time.deltaTime * -speed, 0, 0);

    }

}
