using UnityEngine;
using UnityEngine.UI;
using System;

public static class ButtonExtension
{
    public static void AddEventListener<T> (this Button button, T param, Action<T> onClick)
    {
        button.onClick.AddListener (delegate ()
        {
            onClick (param);
        });
    }
}
