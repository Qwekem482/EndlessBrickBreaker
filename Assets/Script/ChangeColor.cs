using System;
using System.Linq;
using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    private string[] color;
    private bool updateController = false;

    [SerializeField] private Transform blockGroup;
    [SerializeField] private SpriteRenderer ball;
    [SerializeField] private SpriteRenderer border;
    [SerializeField] private SpriteRenderer basket;
    [SerializeField] private GameObject gameCamera;

    void Update()
    {
        if(updateController)
        {
            System.Random random = new System.Random();
            color = color.OrderBy(x => random.Next()).ToArray();

            basket.color = CustomColor.GetColorFromHex(color[0]);
            ball.color = CustomColor.GetColorFromHex(color[1]);
            border.color = CustomColor.GetColorFromHex(color[2]);
            gameCamera.GetComponent<Camera>().backgroundColor = CustomColor.GetColorFromHex(color[3]);

            for(int i = 0; i < blockGroup.childCount; i++)
            {
                blockGroup.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = CustomColor.GetColorFromHex(color[0]);
            }

            updateController = false;
        }
    }

    public void SetWarmEmbrace()
    {
        color = CustomColor.WARM_EMBRACE;
        updateController = true;
    }

    public void SetDeepBlue()
    {
        color = CustomColor.DEEP_BLUE;
        updateController = true;
    }

    public void SetWallGreen()
    {
        color = CustomColor.WALL_GREEN;
        updateController = true;
    }

    public void SetFlowerEye()
    {
        color = CustomColor.FLOWER_EYE;
        updateController = true;
    }

    public void SetRainbowDonut()
    {
        color = CustomColor.RAINBOW_DONUT;
        updateController = true;
    }

    public void SetTheRoyal()
    {
        color = CustomColor.THE_ROYAL;
        updateController = true;
    }
}
