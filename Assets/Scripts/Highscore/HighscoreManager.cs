using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public static HighscoreManager Instance;

    private string KeyToSave = "KeyHighscore";

    [Header("references")]
    public TextMeshProUGUI uiTextHighscore;

    private void Awake()
    {
        Instance = this;
    }

    public void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHighscore.text = PlayerPrefs.GetString(KeyToSave, "sem highscore");
    }

    public void SavePlayerWin (Player p)
    {
        if (p.playerName == "") return;
        PlayerPrefs.SetString(KeyToSave, p.playerName);
        UpdateText();
    }
}
