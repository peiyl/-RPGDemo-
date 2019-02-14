using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 功能菜单的按钮唤出面板的统一脚本
/// </summary>

public class FunctionButtonEvent : MonoBehaviour {
    public PanelMove panelMove;
    private bool panlFlag;
    void Start()
    {
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
