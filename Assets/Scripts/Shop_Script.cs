using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Shop_Script : MonoBehaviour {

    public Text DM_display;

    void Start() {
        DM_display.text = PlayerPrefs.GetInt("DM").ToString();
    }
    public void Return() {
        SceneManager.LoadScene(1);
    }

    public void onBuy20DM() {
        print("Trying to buy 20DM");
        PlayerPrefs.SetInt("DM", PlayerPrefs.GetInt("DM") + 20);
        PlayerPrefs.Save();
        DM_display.text = PlayerPrefs.GetInt("DM").ToString();
    }
    public void onBuy50DM()
    {
        print("Trying to buy 50DM");
        PlayerPrefs.SetInt("DM", PlayerPrefs.GetInt("DM") + 50);
        PlayerPrefs.Save();
        DM_display.text = PlayerPrefs.GetInt("DM").ToString();
    }
    public void onBuy100DM()
    {
        print("Trying to buy 100DM");
        PlayerPrefs.SetInt("DM", PlayerPrefs.GetInt("DM") + 100);
        PlayerPrefs.Save();
        DM_display.text = PlayerPrefs.GetInt("DM").ToString();
    }
    public void onBuyNoAds() {
        print("Trying to buy No Ads");
        int funds = PlayerPrefs.GetInt("DM");
        if (funds < 20)
        {
            print("rejected");
        }
        else {
            PlayerPrefs.SetInt("DM", funds - 20);
            PlayerPrefs.Save();
            DM_display.text = PlayerPrefs.GetInt("DM").ToString();
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

}
