using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {
    public float speed = 10;
    private float endZ = -20;
	void Start () {
		
	}
	void Update () {
        if (transform.position.z<endZ)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
	}
}
