using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryIcon : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    private int id;
    //有冲突
    public bool isShowInfo = false;
    public bool isDress = false;
    
    private void Update()
    {
        if(isShowInfo)
        {
            Inventory.instance.ShowDes(id);
            
            isShowInfo = false;
            Invoke("Close", 3.0f);
        }
        if(isDress)
            if (Input.GetMouseButtonDown(1))
                RightMouseButtonDown(id);
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        isShowInfo = true;
        isDress = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        isDress = false;
    }
    public void Close()
    {
        Inventory.instance.CloseDes();
    }
    /// <summary>
    /// 右键单击使用物品
    /// </summary>
    /// <param name="id">本Item的ID</param>
    private void RightMouseButtonDown(int id)
    {
        //考虑到药物也可以被使用，所以把判断写在这个脚本。
        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoById(id);
        if (info.Type == ObjectType.Equip)
        {
            if(EquipmentPanel.Instance.Dress(id))
            {
                transform.parent.GetComponent<InventoryItem>().MinuNumber();
            }
        }
    }
    /// <summary>
    /// 初始化icon信息
    /// </summary>
    /// <param name="iconName">图片文件名</param>
    /// <param name="id">物品id</param>
    public void SetIocnName(string iconName,int id)
    {
        this.id = id;
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon/" + iconName);
    }

    
}
