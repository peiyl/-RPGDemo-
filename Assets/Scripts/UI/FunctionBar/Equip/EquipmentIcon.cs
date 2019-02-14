using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/// <summary>
/// 装备面板右键事件
/// </summary>
public class EquipmentIcon : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public int id;
    private bool isHandler = false;
    
    private void Update()
    {
        if(isHandler)
            if(Input.GetMouseButtonDown(1))
            {
                EquipmentPanel.Instance.TakeOff(id, gameObject);
            }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHandler = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHandler = false;
    }
    public void UpdateShow(ObjectInfo info)
    {
        this.id = info.Id;
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Icon/" + info.IconName);
    }

}
