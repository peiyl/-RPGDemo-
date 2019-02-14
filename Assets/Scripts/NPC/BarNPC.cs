using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarNPC : NPC {
    private PanelMove panelMove;
    private GameObject buttonAccept;
    private GameObject buttonCancel;
    private GameObject buttonOK;
    private Text textDes;
    private bool isInTask;//任务标志位
    public int killCount = 0;//任务进度数值
    private void Start()
    {
        panelMove = GameObject.Find("Canvas/Quest").GetComponent<PanelMove>();
        //设置关闭按钮
        GameObject.Find("Canvas/Quest/ButtonCloset").GetComponent<Button>().onClick.AddListener(HideQuest);
        
        textDes = GameObject.Find("Canvas/Quest/TextDes").GetComponent<Text>();
        buttonAccept = GameObject.Find("Canvas/Quest/ButtonAccept");
        buttonCancel = GameObject.Find("Canvas/Quest/ButtonCancel");
        buttonOK = GameObject.Find("Canvas/Quest/ButtonOK");
        buttonCancel.GetComponent<Button>().onClick.AddListener(HideQuest);
        buttonAccept.GetComponent<Button>().onClick.AddListener(OnAcceptButoonDown);
        buttonOK.GetComponent<Button>().onClick.AddListener(OnOKButtonDown);
    }
    /// <summary>
    /// 当鼠标位于这个collider之上的时候，会在每一帧调用这个方法
    /// </summary>
    private void OnMouseOver()
    {
        //当我们点击了老爷爷
        if (Input.GetMouseButtonDown(0))
        {
            //统一管理声音会更好
            GetComponent<AudioSource>().Play();
            ShowQuest();
            if (isInTask) ShowTaskProgress();
            else ShowTaskDes();
            
        }
    }
    //可以直接用，但是懒得改了
    void ShowQuest()
    {
        panelMove.Come();
    }
    void HideQuest()
    {
        panelMove.Go();
    }
    /// <summary>
    /// 显示任务提示
    /// </summary>
    void ShowTaskDes()
    {
        textDes.text = "任务：\n杀死10只小野狼\n\n奖励：\n1000金币";
        buttonOK.SetActive(false);
        buttonAccept.SetActive(true);
        buttonCancel.SetActive(true);
    }
    /// <summary>
    /// 显示任务进度
    /// </summary>
    void ShowTaskProgress()
    {
        textDes.text = "任务：\n你已经杀死了" + killCount + "\\10只狼\n\n奖励：\n1000金币";
        buttonOK.SetActive(true);
        buttonAccept.SetActive(false);
        buttonCancel.SetActive(false);
    }
    //其他按钮事件
    private void OnAcceptButoonDown()
    {
        ShowTaskProgress();
        isInTask = true;
    }
    private void OnOKButtonDown()
    {
        if (killCount>=10)
        {
            PlayerStatus.Instance.GetCoint(1000);
            killCount = 0;
            isInTask = false;
            HideQuest();
        }
        else
        {
            HideQuest();
        }
    }
}
