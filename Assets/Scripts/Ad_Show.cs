using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using System;
public class Ad_Show : MonoBehaviour
{
    InterstitialAd interstitial;
    void Start() {
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene().name == "Studio")
        {
            print("Loading an Ad!");
            string adUnitId = "ca-app-pub-7014742458832581/9595418153";

            AdRequest request = new AdRequest.Builder().Build();
            interstitial = new InterstitialAd(adUnitId);
            interstitial.LoadAd(request);
            interstitial.OnAdClosed += onCloseB;

        }

    }
    void OnLevelWasLoaded(int level)
        {
        print("fff");
        print(SceneManager.GetActiveScene().name);
        DontDestroyOnLoad(transform.gameObject);
        if (SceneManager.GetActiveScene().name == "Ad") {
            print("ell");
            StartCoroutine(WaitOneSecond());
            
        }   
    }

    
    void onCloseB(object sender, EventArgs args)
    {
        interstitial.Destroy();
        interstitial.OnAdClosed -= onCloseB;
        string adUnitId = "ca-app-pub-7014742458832581/9595418153";
        AdRequest request = new AdRequest.Builder().Build();
        interstitial = new InterstitialAd(adUnitId);
        interstitial.LoadAd(request);
        interstitial.OnAdClosed += onCloseB;
        SceneManager.LoadScene(1);
    }
    IEnumerator WaitOneSecond()
    {
        yield return new WaitForSeconds(1);
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else {
            interstitial.Destroy();
            interstitial.OnAdClosed -= onCloseB;
            SceneManager.LoadScene(1);
        }
    }

}
