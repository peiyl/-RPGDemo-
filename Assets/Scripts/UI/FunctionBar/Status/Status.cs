using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 角色信息系统面板动画
/// 功能面板角色信息按钮事件
/// </summary>
public class Status : MonoBehaviour {
    private PanelMove panelMove;
    private StatusPanel statusPanel;
    private bool panlFlag;
    void Start()
    {
        panelMove = GameObject.Find("StatusPanel").GetComponent<PanelMove>();
        statusPanel = GameObject.Find("StatusPanel").GetComponent<StatusPanel>();
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
            statusPanel.UpdateShow();
            panlFlag = true;
        }
    }
}
