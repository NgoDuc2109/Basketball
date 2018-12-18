using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LevelLoader : MonoBehaviour {
    public GameObject loadingScene;
    public Slider slider;
    public Text text;

    public AudioSource audio;
    public AudioClip beep;

    public void LoadLevel(int sceneIndex)
    {
        loadingScene.SetActive(true);
        audio.clip = beep;
        audio.Play();
        StartCoroutine(LoadAsyn(sceneIndex));
      
    }

    IEnumerator LoadAsyn(int sceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        
        while (operation.isDone ==false)
        {
            float progress = Mathf.Clamp01(operation.progress/0.9f);
            slider.value = progress;
            text.text = ((int)(progress * 100f)) + "%";
            yield return null;
        }
    }
}
