using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Check : MonoBehaviour {
    public int index;
    public GameObject obj;
	void Start () {
        if (PlayerPrefs.GetInt("Character"+index)==1)
        {
            obj.SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
