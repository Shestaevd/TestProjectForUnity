using Assets.Scripts.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    public Image[] Hearts = new Image[5];
    int currentHeart = 0;
    void Start()
    {
        Hearts[0] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart1"));
        Hearts[1] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart2"));
        Hearts[2] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart3"));
        Hearts[3] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart4"));
        Hearts[4] = (Utils.Unity.GetChildComponentByName<Image>(gameObject, "heart5"));
    }

    public void HighlightCurrentHp()
    {
        Hearts[currentHeart].color = Color.red;
    }

    public void UnhighlightCurrentHp()
    {
        Hearts[currentHeart].color = Color.white;
    }

    public bool IsOver()
    {
        return currentHeart == 5;
    }

    public void RemoveCurrentHp()
    {
        Hearts[currentHeart].enabled = false;
        currentHeart++;
    }
}
