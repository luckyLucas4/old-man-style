using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Den här filen tar hand om poängsystemet

public class Player_Score : MonoBehaviour {

    private float timeLeft = 120;
    public int playerScore;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    public Player_Move_Prot moveScript;


    private void Start()
    {
        DataManagement.datamangement.LoadData();        //Det här laddar highscoren
    }

    void Update () {            //Den här koden visar upp tiden samt poängen, det tar även och slänger tillbaks spelaren i startmenyn ifall man får slut på tid

        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left:" + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score:" + playerScore);
        if (timeLeft < 0.1f)
        {

            SceneManager.LoadScene("CharacterSelect");

        }

    }
    void OnTriggerEnter2D (Collider2D trig)     //Den här koden ser till att nivån slutar samt att man får poäng när man plockar upp pengar
    {
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            DataManagement.datamangement.SaveData();
            SceneManager.LoadScene("EndScreen");
        }
        if (trig.gameObject.tag == "Coin")
        {
            playerScore += 50;
            Destroy(trig.gameObject);
        }
    }
    void CountScore ()      //Den här koden räknar poängen i slutet av matchen samt ser ifall det är ett nytt high score
    {
        //playerScore = playerScore + (int)(timeLeft * 10);
        VictoryScreen.score = playerScore + (int)(timeLeft * 10);
        if (DataManagement.datamangement.highScore < VictoryScreen.score)
        {
            DataManagement.datamangement.highScore = playerScore + (int)(timeLeft * 10);
        }
        DataManagement.datamangement.SaveData ();
    }
}
