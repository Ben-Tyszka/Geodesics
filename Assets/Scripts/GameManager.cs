using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject prefab_meteor;
    public GameObject prefab_sm_bh, prefab_m_bh, prefab_lg_bh;
    public GameObject[] bh_points;
    TextMesh text_mesh_nickname;
    int prer = 0;
	void Start () {
        for(int i = 0; i < 250; i++)
        {
            Instantiate(prefab_meteor, new Vector3(Random.Range(-100, 100), Random.Range(-100, 100), 0), transform.rotation);
        }

        print("Users name: " + PlayerPrefs.GetString("nickname"));
        //text_mesh_nickname.text = PlayerPrefs.GetString("nickname");
        int choice_config = Random.Range(1, 4);
        if (choice_config == 1) {
            //All small
            Instantiate(prefab_sm_bh, bh_points[0].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[1].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[2].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[3].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[4].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[5].transform.position, bh_points[0].transform.rotation);
        }
        if (choice_config == 2)
        {
            //2 sm 2 lg 2 m
            Instantiate(prefab_sm_bh, bh_points[0].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_lg_bh, bh_points[1].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[2].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[3].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[4].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_lg_bh, bh_points[5].transform.position, bh_points[0].transform.rotation);
        }
        if (choice_config == 3)
        {
            //1 sm 2 lg 3 m
            Instantiate(prefab_m_bh, bh_points[0].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[1].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[2].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_sm_bh, bh_points[3].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_lg_bh, bh_points[4].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_lg_bh, bh_points[5].transform.position, bh_points[0].transform.rotation);
        }
        if (choice_config == 4)
        {
            //0 sm 3 lg 3 m
            Instantiate(prefab_lg_bh, bh_points[0].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[1].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_lg_bh, bh_points[2].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[3].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_lg_bh, bh_points[4].transform.position, bh_points[0].transform.rotation);
            Instantiate(prefab_m_bh, bh_points[5].transform.position, bh_points[0].transform.rotation);
        }

    }
    void FixedUpdate() {
        if (FindObjectOfType<TextMesh>() != null && prer == 0) {
            text_mesh_nickname = FindObjectOfType<TextMesh>();
            text_mesh_nickname.text = PlayerPrefs.GetString("nickname");
            prer++;
        }
        if (text_mesh_nickname != null)
        {
            if (text_mesh_nickname.color.a > 0.01f) {
                text_mesh_nickname.color = new Color(text_mesh_nickname.color.r, text_mesh_nickname.color.g, text_mesh_nickname.color.b, text_mesh_nickname.color.a - 0.005f);
            }
            
        }
    }
    
}
