using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Title : MonoBehaviour {
    private Image myImage;
    void Start()
    {
        myImage = gameObject.GetComponent<Image>();
        myImage.DOFade(1, 2).SetDelay(2);
    }
}
