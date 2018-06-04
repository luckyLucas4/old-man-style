using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Den här filen tar hand om vinstskärmen

public class VictoryScreen : MonoBehaviour {

    public GameObject TotalScoreUI;
    public GameObject highScoreUI;
    public static int score;  //  A new Static variable to hold our score.

    //Det här får texten att visa upp rätt poäng
    void Start ()
    {

        TotalScoreUI.gameObject.GetComponent<Text>().text = ("Total Score: " + score);
        highScoreUI.gameObject.GetComponent<Text>().text = ("High Score:" + DataManagement.datamangement.highScore);

    }

    public void LoadScene()
    {
        SceneManager.LoadScene("CharacterSelect");      //Den här koden får knappen i slutet att starta om spelet samt sätta poängen till 0 igen
        score = 0;

    }
}
