using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudController : MonoBehaviour
{
    private TMP_Text text;
    private void Awake()
    {
        text = GetComponentInChildren<TMP_Text>();

        GameEvents.OnHudText.AddListener(txt =>
        {
            text.text = txt;
        });
    }
}
