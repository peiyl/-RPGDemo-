using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSource : MonoBehaviour {
    //public AudioClip clip;
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(GetComponent<AudioSource>().Play);
	}
}
