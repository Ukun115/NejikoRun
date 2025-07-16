using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    public Text highScoreLabel;

    public void Start()
    {
        //ハイスコアを表示
        highScoreLabel.text = "HighScore : " + PlayerPrefs.GetInt("HighScore") + "m";
    }

    public void OnStartButtonClicked()
    {
        Application.LoadLevel("Main");
    }
}
