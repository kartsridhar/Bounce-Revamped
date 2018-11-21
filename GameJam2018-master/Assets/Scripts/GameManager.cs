using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    bool gameHasEnded = false;
    public float delay;
    public player player;
    public Text winText;
    public int level;

    private void Start()
    {
       // level = 1;
       // DontDestroyOnLoad(this);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) SceneManager.LoadScene("Menu");
        if (Input.GetKeyDown(KeyCode.R)) restart();
    }

    public void levelWin()
    {
        player.completeLevelUI.SetActive(true);
        player.enabled = false;
        Destroy(player.GetComponent<Rigidbody>());
        //open new level
        level += 1;
        Invoke("loadNextLevel", delay);

    }

    public void loadNextLevel(){
        SceneManager.LoadScene("Level" + level.ToString(), LoadSceneMode.Single);
    }

    public void gameWin() {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            player.completeLevelUI.SetActive(true);
            winText.text = "You have won!";
            player.enabled = false;
            Destroy(player.GetComponent<Rigidbody>());
            Invoke("backToMenu", delay);
        }

    }

    public void gameLost()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            restart();
        }
    }

    void restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void backToMenu() {
        SceneManager.LoadScene("Menu");
    }
}
