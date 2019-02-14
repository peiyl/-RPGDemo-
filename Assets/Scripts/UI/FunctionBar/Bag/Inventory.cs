using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 物品栏管理脚本
/// </summary>
public class Inventory : MonoBehaviour {
    public static Inventory instance;
    private GameObject prefab_Item;
    private RectTransform m_RectTransform;
    private List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    //金币显示
    //public int coinCount = 1000;
    private Text coinNumText;
    public GameObject iconImage;
    //物品信息提示框
    public GameObject inventoryDes;
    public Text desText;
    private RectTransform desRectTransform;
    private void Awake()
    {
        instance = this;
    }
    void Start () {
        prefab_Item = Resources.Load<GameObject>("Prefabs/Inventory_Item");
        m_RectTransform = GameObject.Find("InventoryGrid").GetComponent<RectTransform>();
        coinNumText = GameObject.Find("CoinNum").GetComponent<Text>();
        desRectTransform = inventoryDes.GetComponent<RectTransform>();
        inventoryDes.SetActive(false);
        CreateAllItem();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            GetID(Random.Range(2001, 2023));
        }
    }
    /// <summary>
    /// 拾取到物品，并添加到物品栏中
    /// </summary>
    /// <param name="id">物品id</param>
    public void GetID(int id,int num = 1)
    {
        //所有物品中是否存在该物品/如果不存在则查找空的方格。
        InventoryItem item = null;
        foreach (InventoryItem temp in inventoryItemList)
        {
            //查找有无相同物品
            if (temp.id ==id)
            {
                item = temp;
                break;
            }
        }
        //有相同的物品
        if (item != null)
        {
            item.PlusNumber(num);
        }//没有相同的物品则查找空格子
        else
        {
            foreach (InventoryItem temp in inventoryItemList)
            {
                //如果找到空格子，赋值并退出循环。
                if (temp.id ==0)
                {
                    item = temp;
                    break;
                }
            }
            if (item != null)
            {
                GameObject go = Instantiate(iconImage, item.gameObject.GetComponent<Transform>());
                //go.GetComponent<Transform>().SetAsLastSibling();
                item.SetId(id,num);
            }
        }
    }
    /// <summary>
    /// 显示物品信息
    /// </summary>
    /// <param name="id">物品id</param>
    public void ShowDes(int id)
    {
        //设置显示
        inventoryDes.SetActive(true);
        //显示的位置
        desRectTransform.position = Input.mousePosition;
        ObjectInfo info = ObjectsInfo.instance.GetObjectInfoById(id);
        //更新text内容
        switch(info.Type)
        {
                case ObjectType.Drug:
                    desText.text = GetDrugString(info);
                    break;
                case ObjectType.Equip:
                    desText.text = GetEquipString(info);
                    break;
        }
    }
    public void CloseDes()
    {
        inventoryDes.SetActive(false);
    }
    /// <summary>
    /// 生成格子
    /// </summary>
    private void CreateAllItem()
    {
        for (int i = 0; i < 20; i++)
        {
            GameObject go = Instantiate(prefab_Item, m_RectTransform);
            go.AddComponent<InventoryItem>();
            inventoryItemList.Add(go.GetComponent< InventoryItem>());
        }
    }
    /// <summary>
    /// 生成药品信息
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    private string GetDrugString(ObjectInfo info)
    {
        string str = "";
        str += "    名称:" + info.Name + "\n";
        str += "     +HP:" + info.Hp + "\n";
        str += "     +MP:" + info.Mp + "\n";
        str += "  出售价:" + info.PriceSell + "\n";
        str += "  购买价:" + info.PriceBuy + "\n";
        return str;
    }
    /// <summary>
    /// 生成装备信息
    /// </summary>
    /// <param name="info"></param>
    /// <returns></returns>
    private string GetEquipString(ObjectInfo info)
    {
        string str = "";
        str += "    名称:" + info.Name + "\n";
        switch (info.DressType)
        {
            case DressType.Headgear:
                str += "穿戴类型:头盔\n";
                break;
            case DressType.Armor:
                str += "穿戴类型:盔甲\n";
                break;
            case DressType.LeftHand:
                str += "穿戴类型:左手\n";
                break;
            case DressType.RightHand:
                str += "穿戴类型:右手\n";
                break;
            case DressType.Shoe:
                str += "穿戴类型:鞋子\n";
                break;
            case DressType.Accessory:
                str += "穿戴类型:饰品\n";
                break;
        }
        switch(info.ApplicationType)
        {
            case ApplicationType.Swordman:
                str += "适用类型:剑士\n";
                break;
            case ApplicationType.Magician:
                str += "适用类型:魔法师\n";
                break;
            case ApplicationType.Common:
                str += "适用类型:通用\n";
                break;
        }
        if(info.Attack!=0)
            str += " +伤害值:" + info.Attack + "\n";
        if(info.Def !=0)
            str += " +防御值:" + info.Def + "\n";
        if(info.Speed!=0)
            str += " +速度值:" + info.Speed + "\n";
        str += "  出售价:" + info.PriceSell+ "\n";
        str += "  购买价:" + info.PriceBuy + "\n";
        return str;
    }
}
