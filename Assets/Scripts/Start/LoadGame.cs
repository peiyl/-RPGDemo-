using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadGame : MonoBehaviour {
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(LoadGameDown);
	}
	private void LoadGameDown()
    {
        Debug.Log("load game down.");
    }
}
