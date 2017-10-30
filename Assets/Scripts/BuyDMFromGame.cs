using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class BuyDMFromGame : MonoBehaviour {
    public Button btn_moveOn;
    public Text DM_display;
    void OnEnable() {
        DM_display.text = PlayerPrefs.GetInt("DM").ToString();
        btn_moveOn.onClick.AddListener(() => GameObject.Find("BH_1").GetComponent<BlackHoleEater>().MakeChange());    
    }



    public void OnSetupPurchase() {
        print("Buying life");
        if (PlayerPrefs.GetInt("DM") >= 3)
        {
            //Can make purchase
            PlayerPrefs.SetInt("DM", PlayerPrefs.GetInt("DM") - 3);
            PlayerPrefs.Save();
            DM_display.text = PlayerPrefs.GetInt("DM").ToString();
            print("Successfull!");
            GameObject player = GameObject.Find("Player_Start");
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
            SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
            sr.color = new Color(sr.color.r, sr.color.b, sr.color.g, 1.0f);
            player.transform.position = Vector3.zero;
            player.GetComponent<SpaceShip_Move>().canMove = true;
            gameObject.SetActive(false);

        }
        else {
            Debug.LogError("Not enought funds");
            //Might load in $0.99 revive >:)

        }
    }
}
