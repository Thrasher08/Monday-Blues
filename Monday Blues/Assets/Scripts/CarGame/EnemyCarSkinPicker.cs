using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCarSkinPicker : MonoBehaviour
{

    public List<Sprite> carSprites;

    public Image carImage;

    void Awake()
    {
        if (carSprites.Count == 0)
        {
            return;
        }

        int index = Random.Range(0, carSprites.Count);
        carImage.sprite = carSprites[index];
    }

}
