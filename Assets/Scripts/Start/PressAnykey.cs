using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class PressAnykey : MonoBehaviour {
    private Image myImage;
    private bool anykeyDown = false;
    private GameObject myContainer;//需要获取开始\读取游戏按钮
	void Start () {
        myImage = gameObject.GetComponent<Image>();
        myContainer = GameObject.Find("Canvas/start/container");
        myImage.DOFade(1, 1).SetDelay(2).SetLoops(-1, LoopType.Yoyo);
    }
    private void Update()
    {
        if(!anykeyDown)
        {
            if(Input.anyKey)
            {
                ShowButton();
                anykeyDown = true;
            }
        }
    }
    /// <summary>
    /// 显示开始游戏和读取游戏按钮
    /// </summary>
    private void ShowButton()
    {
        myContainer.SetActive(true);
        gameObject.SetActive(false);
    }
}
