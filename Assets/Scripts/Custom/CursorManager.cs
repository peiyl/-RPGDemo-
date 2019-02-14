using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 鼠标图标管理
/// </summary>
public class CursorManager : MonoBehaviour {

    public static CursorManager Instance;

    public Texture2D cursor_normal;
    public Texture2D cursor_npc_talk;
    public Texture2D cursor_attack;
    public Texture2D cursor_lockTarget;
    public Texture2D cursor_pick;

    private Vector2 hotspot = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;
    private void Start()
    {
        Instance = this;
    }
    public void SetNormal()
    {
        Cursor.SetCursor(cursor_normal,hotspot,mode);
    }
    public void SetNpcTalk()
    {
        Cursor.SetCursor(cursor_npc_talk,hotspot,mode);
    }
}
