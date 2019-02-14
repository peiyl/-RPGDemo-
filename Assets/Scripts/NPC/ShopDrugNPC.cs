using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 药品商店NPC脚本
/// 功能：召唤商店面板
/// </summary>
public class ShopDrugNPC : NPC {
    /// <summary>
    /// 面板移动脚本
    /// </summary>
    public PanelMove ShopDrugPanelPM;
    /// <summary>
    /// 面板控制脚本
    /// </summary>
    public ShopDrugPanel shopDrugScript;
    /// <summary>
    /// 当鼠标在这个游戏物体之上时
    /// </summary>
    public void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //统一管理声音会更好
            GetComponent<AudioSource>().Play();
            //弹出药品购买列表
            ShopDrugPanelPM.Come();
            shopDrugScript.UpdateShow();
        }
    }
}
