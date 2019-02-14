using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// tag标签管理类
/// </summary>
public class Tags : MonoBehaviour {
    //const表明这是一个公有的不可变的变量
    //使用const可以减少出错。
    public const string ground = "Ground";
    public const string player = "Player";
    public const string inventoryItem = "InventoryItem";
    public const string inventoryIcon = "InventoryIcon";
}
