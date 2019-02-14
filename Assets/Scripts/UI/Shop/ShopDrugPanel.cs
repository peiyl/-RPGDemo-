using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 用于药品商店面板
/// 管理整个面板
/// </summary>
public class ShopDrugPanel : MonoBehaviour {

    //持有预制体
    private GameObject DrugItem;
    //持有列表管理位置
    public RectTransform DrugGrid;
    /// <summary>
    /// 一个物品对象
    /// </summary>
    private ObjectInfo info = null;
    /// <summary>
    /// 确认购买面板（购物车）
    /// </summary>
    public GameObject DrugBuyPanel;
    /// <summary>
    /// 购物车上的脚本
    /// </summary>
    public DrugBuyPanel drugBuyPanel;
    /// <summary>
    /// 消息提示UI
    /// </summary>
    public GameObject Tips;
    /// <summary>
    /// 消息文本
    /// </summary>
    public Text TipsText;
    /// <summary>
    /// 关闭按钮
    /// </summary>
    public Button ClosetBtn;

    /// <summary>
    /// 生成商品列表
    /// </summary>
    private void CreateAllCommodity()
    {
        for (int i = 0; i < 3; i++)
        {
            info = ObjectsInfo.instance.GetObjectInfoById(1001 + i);
            DrugItem go = Instantiate(DrugItem, DrugGrid).GetComponent<DrugItem>();
            go.Show(info.IconName, info.Name, info.Hp, info.Mp, info.PriceSell,info.Id);
            //这里本来应该是分别添加监听事件的，但是运行之后是点击按钮执行的是最后一次循环的结果。可能是我的理解有些问题。
            //go.BuyButton.onClick.AddListener(() =>
            //{
            //    DrugBuyPanel.SetActive(true);
            //    Debug.Log("我要买" + info.Name);
            //    drugBuyPanel.Show(info.IconName, info.Name, info.PriceSell, info.Id);
            //});
        }

    }
    void Start () {
        DrugItem = Resources.Load<GameObject>("Prefabs/DrugItem");
        drugBuyPanel = DrugBuyPanel.GetComponent<DrugBuyPanel>();
        DrugBuyPanel.SetActive(false);
        //给消息提示UI添加按钮事件，点击后隐藏
        Tips.GetComponent<Button>().onClick.AddListener(()=>Tips.SetActive(false));
        //当点击关闭按钮时面板移出场景
        ClosetBtn.onClick.AddListener(gameObject.GetComponent<PanelMove>().Go);
        Tips.SetActive(false);
        CreateAllCommodity();
    }
    /// <summary>
    /// 确认购买方法
    /// </summary>
    /// <param name="price">商品单价</param>
    /// <param name="num">购买数量</param>
    /// <param name="id">商品ID</param>
    public void Buy(int id,int price,int num)
    {
        if(PlayerStatus.Instance.CanBuy(price*num))
        {
            //可以购买
            Inventory.instance.GetID(id,num);
            UpdateTips("购买成功！");
        }
        else
        {
            //不能购买
            UpdateTips("您的余额不足！");
        }
    }
    /// <summary>
    /// 更新提示文本
    /// </summary>
    /// <param name="s"></param>
    private void UpdateTips(string s)
    {
        Tips.SetActive(true);
        TipsText.text = s;
        DrugBuyPanel.SetActive(false);
    }
    /// <summary>
    /// 更新面板
    /// </summary>
    public void UpdateShow()
    {
        //干脆把列表生成也写这里，退出的时候全删掉，打开再生成，是不是比较省内存。
        DrugBuyPanel.SetActive(false);
        Tips.SetActive(false);
    }
}
