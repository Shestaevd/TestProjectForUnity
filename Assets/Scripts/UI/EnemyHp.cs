using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHp : MonoBehaviour
{
    public Image[] Hearts = new Image[5];
    int currentHeart = 0;
    void Start()
    {
        Hearts[0] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart1"));
        Hearts[1] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart2"));
        Hearts[2] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart3"));
    }
    public bool IsOver()
    {
        return currentHeart == 3;
    }
    public void RemoveCurrentHp()
    {
        if (currentHeart < 3)
        {
            Hearts[currentHeart].enabled = false;
            currentHeart++;
        }
    }
}