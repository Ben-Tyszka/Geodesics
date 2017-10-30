using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TriggerGame : MonoBehaviour {

    public InputField name;
    public Text high_score;
    public GameObject button;
    void Start() {
        print(PlayerPrefs.GetString("nickname"));
        if (PlayerPrefs.GetString("nickname") != null) {
            name.text = PlayerPrefs.GetString("nickname");
        }
        print(PlayerPrefs.GetInt("Entropy") + "\nHS: " + PlayerPrefs.GetInt("hs"));
        if (PlayerPrefs.GetInt("Entropy") > PlayerPrefs.GetInt("hs"))
        {
            high_score.text = "New Highscore: " + PlayerPrefs.GetInt("Entropy");
            PlayerPrefs.SetInt("hs", PlayerPrefs.GetInt("Entropy"));
            PlayerPrefs.Save();
            print("New highscore");
        }
        else if (PlayerPrefs.GetInt("Entropy") <= PlayerPrefs.GetInt("hs")) {
            if (PlayerPrefs.GetInt("hs") == 0 && PlayerPrefs.GetInt("Entropy") == 0) {
                high_score.text = "";
            }
            else
            {
                high_score.text = "Highscore: " + PlayerPrefs.GetInt("hs");
            }
            
            print("No new highscore");
        }

    }



    public void OnGameClick() {
        startGame();
    }
    void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            startGame();
        }
    }

    void startGame() {
        StartCoroutine(change_level());
        
        
    }
    public void PrivacyScene() {
        SceneManager.LoadScene(3);
    }

    public void Settings() {
        SceneManager.LoadScene(7);
    }
    public void Store() {

        SceneManager.LoadScene(9);
    }
    IEnumerator change_level()
    {
        float fadeTime = button.GetComponent<FadeScript>().StartFade(1);
        yield return new WaitForSeconds(fadeTime);
        if (PlayerPrefs.GetInt("tut_done") == 5)
        {
            SceneManager.LoadScene(2);
        }
        else {
            SceneManager.LoadScene(4);
        }

    }
}
