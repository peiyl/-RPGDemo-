using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 只是用来管理NPC鼠标事件
/// </summary>
public class NPC : MonoBehaviour {
    private void OnMouseEnter()
    {
        CursorManager.Instance.SetNpcTalk();
    }
    private void OnMouseExit()
    {
        CursorManager.Instance.SetNormal();
    }
}
