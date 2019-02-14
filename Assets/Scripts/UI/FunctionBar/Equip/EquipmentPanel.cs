using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 装备面板管理脚本
/// </summary>
public class EquipmentPanel : MonoBehaviour {
    public static EquipmentPanel Instance;
    //所有装备的格子
    /// <summary>
    /// 头盔
    /// </summary>
    public GameObject HeadgearItem;
    /// <summary>
    /// 盔甲
    /// </summary>
    public GameObject ArmorItem;
    /// <summary>
    /// 左手
    /// </summary>
    public GameObject LeftHandItem;
    /// <summary>
    /// 右手
    /// </summary>
    public GameObject RightHandItem;
    /// <summary>
    /// 鞋子
    /// </summary>
    public GameObject ShoeItem;
    /// <summary>
    /// 饰品
    /// </summary>
    public GameObject AccessoryItem;
    /// <summary>
    /// 物品图片显示UI
    /// </summary>
    public GameObject EquipmentIcon;

    //数据
    public int addAttack;
    public int addDef;
    public int addSpeed;

    private void Awake()
    {
        Instance = this;
    }

    /// <summary>
    /// 穿戴装备
    /// </summary>
    /// <param name="id">穿戴的装备</param>
    /// <returns>穿上与否</returns>
    public bool Dress(int id)
    {
        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoById(id);
        if (PlayerStatus.Instance.heroType == HeroType.Magician)
            if (info.ApplicationType == ApplicationType.Swordman)
                return false;
        if (PlayerStatus.Instance.heroType == HeroType.Swordman)
            if (info.ApplicationType == ApplicationType.Magician)
                return false;
        GameObject parent = null;
        switch(info.DressType)
        {
            case DressType.Headgear:
                parent = HeadgearItem;
                break;
            case DressType.Armor:
                parent = ArmorItem;
                break;
            case DressType.LeftHand:
                parent = LeftHandItem;
                break;
            case DressType.RightHand:
                parent = RightHandItem;
                break;
            case DressType.Shoe:
                parent = ShoeItem;
                break;
            case DressType.Accessory:
                parent = AccessoryItem;
                break;
        }
        //获取对应格子的子物体上的脚本，如果为空说明没有子物体
        EquipmentIcon icon = parent.GetComponentInChildren<EquipmentIcon>();
        if(icon != null)
        {
            Inventory.instance.GetID(icon.id);
            icon.UpdateShow(info);
        }
        else
        {
            GameObject go = Instantiate(EquipmentIcon, parent.GetComponent<RectTransform>());
            go.GetComponent<EquipmentIcon>().UpdateShow(info);
        }
        UpdateProperty();
        Debug.Log("数值变化：" + addAttack + "+" + addDef + "+" + addSpeed);
        return true;
    }
    /// <summary>
    /// 卸下装备
    /// </summary>
    /// <param name="id">所卸下的装备ID</param>
    /// <param name="go">装备的图片</param>
    public void TakeOff(int id,GameObject go)
    {
        Inventory.instance.GetID(id);
        //立即销毁
        DestroyImmediate(go);
        UpdateProperty();
        Debug.Log("数值变化：" + addAttack + "+" + addDef + "+" + addSpeed);
    }
    /// <summary>
    /// 更新属性加成
    /// </summary>
    private void UpdateProperty()
    {
        this.addAttack = 0;
        this.addDef = 0;
        this.addSpeed = 0;
        Property(HeadgearItem.GetComponentInChildren<EquipmentIcon>());
        Property(ArmorItem.GetComponentInChildren<EquipmentIcon>());
        Property(LeftHandItem.GetComponentInChildren<EquipmentIcon>());
        Property(RightHandItem.GetComponentInChildren<EquipmentIcon>());
        Property(ShoeItem.GetComponentInChildren<EquipmentIcon>());
        Property(AccessoryItem.GetComponentInChildren<EquipmentIcon>());
    }
    /// <summary>
    /// 属性加成计算
    /// </summary>
    /// <param name="icon">子物体脚本</param>
    private void Property(EquipmentIcon icon)
    {
        if (icon != null)
        {
            ObjectInfo info = ObjectsInfo.instance.GetObjectInfoById(icon.id);
            this.addAttack += info.Attack;
            this.addDef += info.Def;
            this.addSpeed += info.Speed;
        }
    }
}
