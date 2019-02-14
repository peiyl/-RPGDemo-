using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 写一个统一处理信息面板加点按钮的脚本
/// </summary>
public class StatusAddBtn : MonoBehaviour {
    public enum StatusAddType
    {
        attack,
        def,
        speed,
    }public StatusAddType sType;
    private StatusPanel statusPanel;
	void Start () {
        statusPanel = GameObject.Find("StatusPanel").GetComponent<StatusPanel>();
        GetComponent<Button>().onClick.AddListener(ButtonDown);
	}
    void ButtonDown()
    {
        if(PlayerStatus.Instance.CanSubPointN())
        {
            switch (sType)
            {
                case StatusAddType.attack:
                    AttackAdd();
                    break;
                case StatusAddType.def:
                    DefAdd();
                    break;
                case StatusAddType.speed:
                    SpeedAdd();
                    break;
            }
            statusPanel.UpdateShow();
        }
    }
    void AttackAdd()
    {
        PlayerStatus.Instance.attackPlus++;
    }
    void DefAdd()
    {
        PlayerStatus.Instance.defPlus++;
    }
    void SpeedAdd()
    {
        PlayerStatus.Instance.speedPlus++;
    }
}
