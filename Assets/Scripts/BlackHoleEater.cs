using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BlackHoleEater : MonoBehaviour
{
    public GameObject prefab_meteor;
    public bool type_ = true;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name.Contains("Meteor"))
        {
            //Instantiate(prefab_meteor, new Vector3(Random.Range(1, 99), Random.Range(1, 99), 0), other.transform.rotation);
            //Destroy(other.gameObject);
            other.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
            other.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
            other.transform.position = new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), 0);
        }
        else if (other.name.Contains("Player"))
        {
            
            if (type_)
            {
                this.name = "BH_1";
                other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                //TODO: Optimize
                other.GetComponent<SpriteRenderer>().color = new Color(other.GetComponent<SpriteRenderer>().color.r, other.GetComponent<SpriteRenderer>().color.b, other.GetComponent<SpriteRenderer>().color.g, 0.0f);
                PlayerPrefs.SetInt("Entropy", other.GetComponent<Orbit_Adder>().Entropy);
                PlayerPrefs.Save();
                GameObject.Find("Canvas").GetComponentsInChildren<Animation>(true)[0].gameObject.SetActive(true);
            }

            else if(!type_){
                //SceneManager.LoadScene(1);
            }
            

        }


    }

    public void MakeChange() {
        print("In-direct cont");
        int choice = 4;//Random.Range(0, 5);
        if (choice == 0)
        {


            StartCoroutine(change_level(8));

        }
        else {
            StartCoroutine(change_level(1));
        }
        
    }


    IEnumerator change_level(int scene_to_use) {
        float fadeTime = GameObject.Find("GameManager").GetComponent<FadeScript>().StartFade(1);
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(scene_to_use);
        
    }
}