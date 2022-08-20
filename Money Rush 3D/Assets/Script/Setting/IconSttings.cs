using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconSttings : MonoBehaviour
{
    [Header("UI References ;")]
    [SerializeField] private Button SettingsBtn;

    [Header("Settings UI")]
    [SerializeField] private SettingsUI SettingsUI;

    private void Start()
    {
        //Add Listener
        SettingsBtn.onClick.AddListener(() => SettingsUI.Open());
    }

    private void OnDestroy()
    {
        //Remove Listener
        SettingsBtn.onClick.RemoveAllListeners();
    }
}
