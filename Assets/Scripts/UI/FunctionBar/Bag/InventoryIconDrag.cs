using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// 物品的拖拽控制脚本
/// </summary>
public class InventoryIconDrag : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler {
    private RectTransform mRectTransform;
    private CanvasGroup mCanvasGroup;
    void Start () {
        mRectTransform = GetComponent<RectTransform>();
        mCanvasGroup = GetComponent<CanvasGroup>();
	}
    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        mCanvasGroup.blocksRaycasts = false;//取消自身的射线检测
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        //通过拖拽事件改变图片位置
        Vector3 pos;
        RectTransformUtility.ScreenPointToWorldPointInRectangle(mRectTransform, eventData.position, eventData.enterEventCamera, out pos);
        mRectTransform.position = pos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        //拖拽事件处理。
        //发射射线并得到射线击中的物体
        GameObject go = eventData.pointerCurrentRaycast.gameObject;
        Debug.Log(go);
        if (go != null)
        {
            //1、目的地是空格子。
            if (go.tag==Tags.inventoryItem)
            {
                //判断是否是原来的格子
                if (go == transform.parent.gameObject)
                {
                    //其实可以直接写，但是这样舒服- -
                    SetIconPos(transform, go);
                    Debug.Log("物品信息不需要发生变化");
                }
                else
                {
                    //先获取两个item上面的脚本，然后进行数据交换，清空旧的父物体
                    Debug.Log("交换item信息到item：" + go);
                    InventoryItem oldParent = transform.parent.GetComponent<InventoryItem>();
                    InventoryItem newParent = go.GetComponent<InventoryItem>();
                    SetIconPos(transform, go);
                    newParent.SetId(oldParent.id, oldParent.num);
                    oldParent.ClearInfo();
                }
                
            }
            else if(go.tag == Tags.inventoryIcon)
            {
                Debug.Log("目的地有物体");
                //2、目的地有物体
                //先获取两个item上的脚本，然后交换位置，交换信息
                InventoryItem oldParent = transform.parent.GetComponent<InventoryItem>();
                InventoryItem newParent = go.transform.parent.gameObject.GetComponent<InventoryItem>();
                SetIconPos(transform,newParent.gameObject);
                SetIconPos(go.transform, oldParent.gameObject);
                int id = oldParent.id;
                int num = oldParent.num;
                oldParent.SetId(newParent.id, newParent.num);
                newParent.SetId(id, num);
            }
            else
            {
                //3、目的地不是格子
                SetIconPos(transform, transform.parent.gameObject);
                Debug.Log("目的地没有格子，回到原来位置");
            }
        }
        else
        {
            //4、拖拽到物品栏之外、可以作为删除操作，不知道后面有没有
            //先进行归位处理
            SetIconPos(transform, transform.parent.gameObject);
            Debug.Log("目的地没有格子，回到原来位置");
        }
        mCanvasGroup.blocksRaycasts = true;//自身接受射线检测
    }
    /// <summary>
    /// 设置icon【物体】位置
    /// </summary>
    /// <param name="icon">要设置的物品</param>
    /// <param name="go">目标父物体</param>
    private void SetIconPos( Transform icon,GameObject go)
    {
        //将icon置于目标之下
        icon.SetParent(go.transform);
        //但是位置可能会错位，所以要设置下位置，这里锚点都是一致的
        icon.position = go.transform.position;
    }
}
