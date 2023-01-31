using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auxiliary
{
    public static bool IsEmptyPosition(float radius, string layer, Vector2 position)
    {
        Collider2D collision = Physics2D.OverlapCircle(position, radius, LayerMask.GetMask(layer));

        if(collision == false)
        {
            return false;
        }

        return true;
    }

    public static string GetTimeString(float timeInSec)
    {
        int minute = (int) timeInSec / 60;
        int second = (int) timeInSec % 60;
        return minute.ToString("00") + ":" + second.ToString("00");
    }


}
