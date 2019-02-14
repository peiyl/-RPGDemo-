using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 角色信息类
/// </summary>
public enum HeroType
{
    Swordman,
    Magician
}
public class PlayerStatus : MonoBehaviour {

    public static PlayerStatus Instance;

    public HeroType heroType;

    public int grade = 1;
    public int hp = 100;
    public int mp = 100;
    public int coin = 200;//金币

    public int attack = 20;
    public int attackPlus = 0;
    public int def = 20;
    public int defPlus = 0;
    public int speed = 20;
    public int speedPlus = 0;

    public int pointRemain = 0;//剩余点数
    private void Start()
    {
        Instance = this;
    }

    /// <summary>
    /// 增加玩家持有金币
    /// </summary>
    /// <param name="count">金币数量</param>
    public void GetCoint(int count)
    {
        coin += count;
    }
    /// <summary>
    /// 玩家购买判断,如果可以买就减去金额。
    /// </summary>
    /// <param name="count"></param>
    public bool CanBuy(int count)
    {
        if (coin>=count )
        {
            coin -= count;
            return true;
        }
        return false;
    }
    /// <summary>
    /// 玩家获取数值点数
    /// </summary>
    /// <param name="count">数值点数</param>
    public void AddPointN( int count)
    {
        pointRemain += count;
    }
    /// <summary>
    /// 玩家消耗点数判断
    /// </summary>
    /// <param name="count">要消耗的点数</param>
    /// <returns></returns>
    public bool CanSubPointN(int count = 1)
    {
        if (pointRemain >=count)
        {
            pointRemain -= count;
            return true;
        }
        return false;
    }
}
