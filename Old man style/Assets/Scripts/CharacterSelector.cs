using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Den här filen tar hand om karaktärval och självaste starten av spelet

public class CharacterSelector : MonoBehaviour {

    public GameObject[] players;

    public void ChooseCharacter(int characterIndex)         //Det här bestämmer vilken spelare man valt
    {
        PlayerPrefs.SetInt("SelectedCharacter", characterIndex);
        print("The Player index that is selected is " + characterIndex);
    }

    public void LoadScene()             //Det här ser till att man startar som rätt spelare
    {
        if (PlayerPrefs.GetInt("SelectedCharacter") == 0)
        {
            SceneManager.LoadScene("LevelOne");
        }
        if (PlayerPrefs.GetInt("SelectedCharacter") == 1)
        {
            SceneManager.LoadScene("LevelTwo");
        }
    }

}
