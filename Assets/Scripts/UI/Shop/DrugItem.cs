using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 出售药品列表的单元格
/// </summary>
public class DrugItem : MonoBehaviour {
    //持有所有需要动态设置的ui
    public Image DrugIcon;
    public Text NameText;
    public Text XGText;
    public Text PriceSText;
    //持有按钮
    public Button BuyButton;
    /// <summary>
    /// 初始化单元格数据
    /// </summary>
    /// <param name="drugIconName">物品图片文件名</param>
    /// <param name="drugName">物品名称</param>
    /// <param name="xg">物品效果</param>
    /// <param name="price">物品单价</param>
    public void Show(string drugIconName, string drugName, int hP,int mP, int price,int id)
    {
        DrugIcon.sprite = Resources.Load<Sprite>("Icon/" + drugIconName);
        NameText.text = drugName;
        //这里的效果有两个不同数值，第一个想到的解决方法如下，
        //但是太长了，原本的ui排版显示不下，要么改字体大小也很丑，
        //反正本来练习就是看开心，想想策划也不可能给我搞这种事- -
        //XGText.text = "HP+" + hP + ";MP+" + mP;
        //我的解决方法,这是在数值规律的基础上的：
        if (hP != 0)
            XGText.text = "HP+" + hP;
        else
            XGText.text = "MP+" + mP;
        PriceSText.text = price.ToString();
        BuyButton.onClick.AddListener(() =>
        {
            GameObject.Find("ShopDrugPanel").GetComponent<ShopDrugPanel>().DrugBuyPanel.SetActive(true);
            GameObject.Find("ShopDrugPanel").GetComponent<ShopDrugPanel>().drugBuyPanel.Show(drugIconName, drugName, price, id);
        });
    }
}
