using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLV : MonoBehaviour {
    public void NextLevel(int lv)
    {
        SceneManager.LoadScene(lv);
       
        Time.timeScale = 1;
    }
}
