using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Orbit_Adder : MonoBehaviour {
    int i = 0;
    public int Entropy = 19;
    public bool can_add_more_orbits = true;
    Text entropy_display;
    public Text max_orbits_display;
    public Text level_up_display;

    public Sprite level1_sprite, level2_sprite, level3_sprite, level4_sprite;

    void Start() {
        
        for (int ben = 0; ben < FindObjectsOfType<Text>().Length; ben++) {
           // print("cyrcle");
            if (FindObjectsOfType<Text>()[ben].name == "En")
            {
                //print("found obj");
                entropy_display = FindObjectsOfType<Text>()[ben];
                //break;
            }
            else if (FindObjectsOfType<Text>()[ben].name == "lu") {
                //print("found lvlup");
                FindObjectsOfType<Text>()[ben].enabled = false;
                FindObjectsOfType<Text>()[ben].color = new Color(255, 255, 255, 255);
                level_up_display = FindObjectsOfType<Text>()[ben];
            }
        }

    }

    public void IncreaseEntropy() {
        Entropy++;
        entropy_display.text = "Entropy: " + Entropy.ToString();
        //max_orbits_display.text = "Max Orbits: " + (Entropy + 1);

        if (Entropy == 5) {
            level_up_display.enabled = true;
            level_up_display.canvasRenderer.SetAlpha(1f);
            level_up_display.CrossFadeAlpha(0.01f, 1f, false);
            GetComponent<SpriteRenderer>().sprite = level1_sprite;
            //GetComponentsInChildren<SpriteRenderer>()[1].color = new Color(1f, 111f / 255f, 122f/255f, 1);
            
            for (int counter_i = 0; counter_i < GameObject.FindGameObjectsWithTag("Meteor_Attached").Length; counter_i++) {
                GameObject.FindGameObjectsWithTag("Meteor_Attached")[counter_i].GetComponent<OrbitNow>().SETEJECT();
            }
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            GetComponentsInChildren<Transform>()[1].localScale = new Vector3(1.7f, 1.7f, 1.7f);
            GetComponent<CircleCollider2D>().radius = 9.93f;
            GetComponentsInChildren<CircleCollider2D>()[1].radius = 4.3f;
            Camera.main.orthographicSize = 5.25f;
        }
        if (Entropy == 20)
        {
            //Large gass giant
            level_up_display.enabled = true;
            level_up_display.canvasRenderer.SetAlpha(1f);
            level_up_display.CrossFadeAlpha(0.01f, 1f, false);
            GetComponent<SpriteRenderer>().sprite = level2_sprite;
            for (int counter_i = 0; counter_i < GameObject.FindGameObjectsWithTag("Meteor_Attached").Length; counter_i++)
            {
                GameObject.FindGameObjectsWithTag("Meteor_Attached")[counter_i].GetComponent<OrbitNow>().SETEJECT();
            }
            transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            GetComponentsInChildren<Transform>()[1].localScale = new Vector3(2f, 2f, 2f);
            GetComponent<CircleCollider2D>().radius = 10.7f;
            GetComponentsInChildren<CircleCollider2D>()[1].radius = 3.5f;
            Camera.main.orthographicSize = 6f;
        }
        else if (Entropy == 55)
        {
            level_up_display.enabled = true;
            level_up_display.canvasRenderer.SetAlpha(1f);
            level_up_display.CrossFadeAlpha(0.01f, 1f, false);
            GetComponent<SpriteRenderer>().sprite = level3_sprite;
            for (int counter_i = 0; counter_i < GameObject.FindGameObjectsWithTag("Meteor_Attached").Length; counter_i++)
            {
                GameObject.FindGameObjectsWithTag("Meteor_Attached")[counter_i].GetComponent<OrbitNow>().SETEJECT();
            }
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
            GetComponentsInChildren<Transform>()[1].localScale = new Vector3(2.3f, 2.3f, 2.3f);
            GetComponent<CircleCollider2D>().radius = 10.26f;
            GetComponentsInChildren<CircleCollider2D>()[1].radius = 3.85f;
            Camera.main.orthographicSize = 6.5f;
        }
        else if (Entropy == 100) {
            level_up_display.enabled = true;
            level_up_display.canvasRenderer.SetAlpha(1f);
            level_up_display.CrossFadeAlpha(0.01f, 1f, false);
            GetComponent<SpriteRenderer>().sprite = level4_sprite;
            for (int counter_i = 0; counter_i < GameObject.FindGameObjectsWithTag("Meteor_Attached").Length; counter_i++)
            {
                GameObject.FindGameObjectsWithTag("Meteor_Attached")[counter_i].GetComponent<OrbitNow>().SETEJECT();
            }
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
            GetComponentsInChildren<Transform>()[1].localScale = new Vector3(2.6f, 2.6f, 2.6f);
            GetComponent<CircleCollider2D>().radius = 13f;
            GetComponentsInChildren<CircleCollider2D>()[1].radius = 3.7f;
            Camera.main.orthographicSize = 9.25f;
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (i == 0) {
            i++;
            return;
           
        }
        if (other.name.Contains("Meteor"))
        {
            
            if ((transform.childCount - 5) == Entropy + 1)
            {
                can_add_more_orbits = false;
                print("Maxed out! You must increase entropy!");
            }
            else if ((transform.childCount - 5) != Entropy + 1)
            {
                can_add_more_orbits = true;
                print("can add more orbits, max is: " + (Entropy + 1));
            }
            if (can_add_more_orbits)
            {
                other.GetComponent<OrbitNow>().point = this.gameObject;
                other.SendMessage("setup");
            }

        }
    }
}
