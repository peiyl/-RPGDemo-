using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
/// <summary>
/// UI面板进出场景
/// </summary>
public class PanelMove : MonoBehaviour {
    public RectTransform pointEnd;
    public RectTransform pointStart;
    private Image image;
	void Start () {
        image = gameObject.GetComponent<Image>();
	}
    public void Come()
    {
        image.rectTransform.DOMove(pointEnd.position, 2.0f);
    }
    public void Go()
    {
        image.rectTransform.DOMove(pointStart.position, 2.0f);
    }
}
