using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour {

    public void Back() {
        SceneManager.LoadScene(1);
    }
    public void ResetGame() {
        //PlayerPrefs.SetInt("tut_done", 0);
        PlayerPrefs.SetInt("Entropy", 0);
        PlayerPrefs.SetInt("hs", 0);
        PlayerPrefs.Save();
    }
    public void ViewTutorial() {

        SceneManager.LoadScene(4);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }
}
