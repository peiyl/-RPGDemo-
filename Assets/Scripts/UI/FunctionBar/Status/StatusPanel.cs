using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 角色信息管理系统面板
/// </summary>
public class StatusPanel : MonoBehaviour {
    //显示的文本
    public Text AttackNumText;
    public Text DefNumText;
    public Text SpeedNumText;
    //加点数的按钮
    public GameObject AttackAddGO;
    public GameObject DefAddGO;
    public GameObject SpeedAddGO;
    //剩余点数
    public Text pointRemainText;
    //总结内容
    public Text ZJText;
    /// <summary>
    /// 更新status面板上的数据
    /// </summary>
    public void UpdateShow()
    {
        AttackNumText.text = PlayerStatus.Instance.attack + "+" + PlayerStatus.Instance.attackPlus;
        DefNumText.text = PlayerStatus.Instance.def + "+" + PlayerStatus.Instance.defPlus;
        SpeedNumText.text = PlayerStatus.Instance.speed + "+" + PlayerStatus.Instance.speedPlus;

        pointRemainText.text = "剩余点数：" + PlayerStatus.Instance.pointRemain;

        ZJText.text = " 伤害： " + (PlayerStatus.Instance.attack + PlayerStatus.Instance.attackPlus)
            + " 防御： " + (PlayerStatus.Instance.def + PlayerStatus.Instance.defPlus)
            + " 速度： " + (PlayerStatus.Instance.speed + PlayerStatus.Instance.speedPlus);

        if (PlayerStatus.Instance.pointRemain >0)
        {
            AttackAddGO.SetActive(true);
            DefAddGO.SetActive(true);
            SpeedAddGO.SetActive(true);
        }
        else
        {
            AttackAddGO.SetActive(false);
            DefAddGO.SetActive(false);
            SpeedAddGO.SetActive(false);
        }
    }
}
