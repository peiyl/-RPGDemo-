using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 确认购买面板
/// 当按下buy按钮调出
/// </summary>
public class DrugBuyPanel : MonoBehaviour {
    //要更新的UI
    /// <summary>
    /// 商品图片UI
    /// </summary>
    public Image DrugBuyIcon;
    /// <summary>
    /// 商品名称UI
    /// </summary>
    public Text DrugBuyNameText;
    /// <summary>
    /// 购买数量UI
    /// </summary>
    public Text NumText;
    /// <summary>
    /// 购买数量*单价 = 总价UI
    /// </summary>
    public Text ZJText;

    //持有按钮
    /// <summary>
    /// 增加购买数量
    /// </summary>
    public Button AddButton;
    /// <summary>
    /// 减少购买数量
    /// </summary>
    public Button SubButton;
    /// <summary>
    /// 确认购买按钮
    /// </summary>
    public Button YBuyButton;

    //用于存储的数据。
    /// <summary>
    /// 物品单价
    /// </summary>
    private int price;
    /// <summary>
    /// 购买数量
    /// </summary>
    private int num;
    /// <summary>
    /// 商品id
    /// </summary>
    private int id;
    /// <summary>
    ///显示要购买的商品的信息
    /// </summary>
    /// <param name="drugIconName">商品图片文件名</param>
    /// <param name="drugName">商品名称</param>
    /// <param name="price">商品单价</param>
    /// <param name="id">商品ID</param>
    public void Show(string drugIconName, string drugName, int price,int id)
    {
        //初始化显示信息
        this.num = 1;
        this.price = price;
        this.id = id;
        DrugBuyIcon.sprite = Resources.Load<Sprite>("Icon/" + drugIconName);
        DrugBuyNameText.text = drugName;
        NumText.text = num.ToString();
        ZJText.text = (num * price).ToString();
    }
    private void Start()
    {
        //突然想起来lambda表达式
        //把两个加减按钮的逻辑写上
        AddButton.onClick.AddListener(() => { num++; NumText.text = num.ToString(); ZJText.text = (num * price).ToString(); });
        SubButton.onClick.AddListener(() => { num--; if (num <= 0) num = 1; NumText.text = num.ToString(); ZJText.text = (num * price).ToString(); });
        //确认购买按钮的逻辑
        //判断是否可以购买
        //调用背包增加相应物品及数量
        YBuyButton.onClick.AddListener(() =>
        {
            GameObject.Find("ShopDrugPanel").GetComponent<ShopDrugPanel>().Buy(id, price, num);
        });
    }
}
