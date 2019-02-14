using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAudio : MonoBehaviour {
    private AudioSource buttonAudioSource;
	// Use this for initialization
	void Start () {
        buttonAudioSource = GameObject.Find("ButtonAudioSetting").GetComponent<AudioSource>();
        gameObject.GetComponent<Button>().onClick.AddListener(buttonAudioSource.Play);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
