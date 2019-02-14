//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
///// <summary>
///// 当鼠标悬停时显示物品信息的类
///// </summary>
//public class InventoryIconShowInfo : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler {
//    private int id;
//    private EquipmentPanel equipmentPanel;
//    private void Start()
//    {
//        equipmentPanel = GameObject.Find("EquipmentPanel").GetComponent<EquipmentPanel>();
//    }
//    public void OnPointerEnter(PointerEventData eventData)
//    {
//        Inventory.instance.ShowDes(id);
//        if (Input.GetMouseButtonDown(1))
//            RightMouseButtonDown(id);
//    }

//    public void OnPointerExit(PointerEventData eventData)
//    {
//        //当鼠标离开的时候，关闭物体信息提示
//        Inventory.instance.inventoryDes.SetActive(false);
//    }
//    public void OnPointerDown(PointerEventData eventData)
//    {
//        //当鼠标按下时，关闭物体信息提示。
//        Inventory.instance.inventoryDes.SetActive(false);
//    }
//    /// <summary>
//    /// 右键单击使用物品
//    /// </summary>
//    /// <param name="id">本Item的ID</param>
//    private void RightMouseButtonDown(int id)
//    {
//        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoById(id);
//        if (info.Type == ObjectType.Equip)
//        {
//            if (equipmentPanel.Dress(id))
//            {

//            }

//        }
//    }
//}
