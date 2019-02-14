using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品类型枚举
/// </summary>
public enum ObjectType
{
    /// <summary>
    /// 药品（1000）
    /// </summary>
    Drug,
    /// <summary>
    /// 装备（2000）
    /// </summary>
    Equip,
    /// <summary>
    /// 材料（3000）
    /// </summary>
    Mat
}
/// <summary>
/// 穿戴类型枚举
/// </summary>
public enum DressType
{
    /// <summary>
    /// 头盔
    /// </summary>
    Headgear,
    /// <summary>
    /// 盔甲
    /// </summary>
    Armor,
    /// <summary>
    /// 左手
    /// </summary>
    LeftHand,
    /// <summary>
    /// 右手
    /// </summary>
    RightHand,
    /// <summary>
    /// 鞋子
    /// </summary>
    Shoe,
    /// <summary>
    /// 饰品
    /// </summary>
    Accessory
}
/// <summary>
/// 适用类型枚举
/// </summary>
public enum ApplicationType
{
    /// <summary>
    /// 剑士
    /// </summary>
    Swordman,
    /// <summary>
    /// 魔法师
    /// </summary>
    Magician,
    /// <summary>
    /// 通用
    /// </summary>
    Common
}
public class ObjectInfo
{
    private int id;
    private string name;
    private string iconName;//这个名称是存储在图集中的名称
    private ObjectType type;
    private int hp;
    private int mp;
    private int priceSell;//出售价
    private int priceBuy;//购买价
    
    private int attack;
    private int def;
    private int speed;
    private DressType dressType;
    private ApplicationType applicationType;
    /// <summary>
    /// 物品id
    /// </summary>
    public int Id
    {
        get { return id; }
    }
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name
    {
        get { return name; }
    }
    /// <summary>
    /// 物品图片名称
    /// </summary>
    public string IconName
    {
        get { return iconName; }
    }
    /// <summary>
    /// 类型
    /// </summary>
    public ObjectType Type
    {
        get { return type; }
    }
    /// <summary>
    /// 加血量值
    /// </summary>
    public int Hp
    {
        get { return hp; }
    }
    /// <summary>
    /// 加魔法值
    /// </summary>
    public int Mp
    {
        get { return mp; }
    }
    /// <summary>
    /// 出售价
    /// </summary>
    public int PriceSell
    {
        get { return priceSell; }
    }
    /// <summary>
    /// 购买价格
    /// </summary>
    public int PriceBuy
    {
        get { return priceBuy; }
    }
    /// <summary>
    /// 加伤害值
    /// </summary>
    public int Attack
    {
        get { return attack; }
    }
    /// <summary>
    /// 加防御值
    /// </summary>
    public int Def
    {
        get { return def; }
    }
    /// <summary>
    /// 加速度值
    /// </summary>
    public int Speed
    {
        get { return speed; }
    }
    /// <summary>
    /// 穿戴类型
    /// </summary>
    public DressType DressType
    {
        get { return dressType; }
    }
    /// <summary>
    /// 适用类型
    /// </summary>
    public ApplicationType ApplicationType
    {
        get { return applicationType; }
    }
    public ObjectInfo() { }
    /// <summary>
    /// 构造函数：药品
    /// </summary>
    /// <param name="id">物品ID</param>
    /// <param name="name">物品名称</param>
    /// <param name="iconName">图片文件名</param>
    /// <param name="type">物品类型</param>
    /// <param name="hp">增加hp值</param>
    /// <param name="mp">增加mp值</param>
    /// <param name="sell">出售价</param>
    /// <param name="buy">购买价</param>
    public ObjectInfo(int id, string name, string iconName, ObjectType type, int hp, int mp, int sell, int buy)
    {
        this.id = id;
        this.name = name;
        this.iconName = iconName;
        this.type = type;
        this.hp = hp;
        this.mp = mp;
        this.priceSell = sell;
        this.priceBuy = buy;
    }
    /// <summary>
    /// 构造函数：装备
    /// </summary>
    /// <param name="id">物品ID</param>
    /// <param name="name">物品名称</param>
    /// <param name="iconName">图片文件名</param>
    /// <param name="type">物品类型</param>
    /// <param name="attack">加伤害值</param>
    /// <param name="def">加防御值</param>
    /// <param name="speed">加速度值</param>
    /// <param name="dressType">穿戴类型</param>
    /// <param name="applicationType">适用类型</param>
    /// <param name="sell">出售价</param>
    /// <param name="buy">购买价</param>
    public ObjectInfo (int id,string name,string iconName,ObjectType type,int attack,int def,int speed,DressType dressType,ApplicationType applicationType,int sell,int buy)
    {
        this.id = id;
        this.name = name;
        this.iconName = iconName;
        this.type = type;
        this.attack = attack;
        this.def = def;
        this.speed = speed;
        this.dressType = dressType;
        this.applicationType = applicationType;
        this.priceSell = sell;
        this.priceBuy = buy;
    }
}

