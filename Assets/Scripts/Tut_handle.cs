using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Tut_handle : MonoBehaviour {
    public int level_num;
    public void move_on_to_level() {
        if (level_num == 1)
        {
            PlayerPrefs.SetInt("tut_done", 6);
            PlayerPrefs.Save();
            SceneManager.LoadScene(level_num);
        }
        else {
            SceneManager.LoadScene(level_num);
        }
        
    }
   
}
