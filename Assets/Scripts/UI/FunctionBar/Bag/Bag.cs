using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 背包面板动画
/// 功能面板bag按钮事件
/// </summary>
public class Bag : MonoBehaviour {
    private PanelMove panelMove;
    private bool panlFlag;
    void Start()
    {
        panelMove = GameObject.Find("Inventory").GetComponent<PanelMove>();
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonDown);
        panlFlag = false;
    }
    void ButtonDown()
    {
        if (panlFlag)
        {
            panelMove.Go();
            panlFlag = false;
        }
        else
        {
            panelMove.Come();
            panlFlag = true;
        }
    }
}
