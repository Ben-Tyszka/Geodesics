using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class More_Scene : MonoBehaviour {

    public void back() {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene(1);
        }
    }
}
