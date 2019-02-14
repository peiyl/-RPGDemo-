using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 功能面板武器系统按钮事件
/// </summary>
public class Equip : MonoBehaviour {
    public PanelMove panelMove;
    private bool panlFlag;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(()=> {if (panlFlag){panelMove.Go();panlFlag = false;}else{panelMove.Come();panlFlag = true;}});
        panlFlag = false;
    }
}
