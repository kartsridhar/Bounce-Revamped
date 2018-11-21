using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class MainMenu : MonoBehaviour {

    public void playGame(){
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
    }

    public void tutorial() {
        SceneManager.LoadScene("Tutorial", LoadSceneMode.Single);
    }

    public void quitGame() {
        //Debug.Log("quit");
        Application.Quit();
    }
}
