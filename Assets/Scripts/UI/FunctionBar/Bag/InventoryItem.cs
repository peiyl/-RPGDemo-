using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 物品栏网格内的信息管理
/// </summary>
public class InventoryItem : MonoBehaviour
{
    public int id = 0;//当前网格存储的物品对应id
    public int num = 0;//当前网格物品个数
    public ObjectInfo info = null;
    private Text iconNumberText;
	void Start ()
    {
        iconNumberText = transform.Find("Number").GetComponent<Text>();
	}
    /// <summary>
    /// 在物品栏添加物品并显示数量
    /// </summary>
    /// <param name="id">物品ID</param>
    /// <param name="num"></param>
    public void SetId(int id,int num =1)
    {
        //image
        info = ObjectsInfo.instance.GetObjectInfoById(id);
        InventoryIcon icon = GetComponentInChildren<InventoryIcon>();
        icon.SetIocnName(info.IconName,info.Id);
        //text
        this.num = num;
        this.id = id;
        iconNumberText.gameObject.SetActive(true);
        NumberUpdate();
    }
    /// <summary>
    /// 增加物品个书计数
    /// </summary>
    /// <param name="num"></param>
    public void PlusNumber(int num =1)
    {
        this.num += num;
        NumberUpdate();
    }
    /// <summary>
    /// 减少物品个数计数
    /// </summary>
    /// <param name="num"></param>
    /// <returns>是否减去成功</returns>
    public bool MinuNumber(int num = 1)
    {
        if(this.num>=num)
        {
            this.num -= num;
            if (this.num == 0)
            {
                ClearInfo();
                Destroy(this.GetComponentInChildren<InventoryIcon>().gameObject);
            }
            else
                NumberUpdate();
            return true;
        }
        return false;
    }
    /// <summary>
    /// 更新物品个数UI
    /// </summary>
    public void NumberUpdate()
    {
        iconNumberText.text = num.ToString();
    }
    /// <summary>
    /// 当物体进行拖动时，当前网格信息清空
    /// </summary>
    public void ClearInfo()
    {
        info = null;
        iconNumberText.gameObject.SetActive(false);
        id = 0;
        num = 0;
    }
}
