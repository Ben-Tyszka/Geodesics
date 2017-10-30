using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class Launch_Splash : MonoBehaviour {

	void Start () {
        StartCoroutine(LaunchGame());
	}

    IEnumerator LaunchGame()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(1);
    }
}
