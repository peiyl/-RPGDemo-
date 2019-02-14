using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 物品信息类
/// </summary>
public class ObjectsInfo : MonoBehaviour
{
    public static ObjectsInfo instance;
    public TextAsset objectsInfoListText;
    private Dictionary<int, ObjectInfo> objectInfoDict = new Dictionary<int, ObjectInfo>();
    private void Awake()
    {
        instance = this;
        ReadInfo();
    }
    /// <summary>
    /// 通过id获取字典中物品的信息
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public ObjectInfo GetObjectInfoById(int id)
    {
        ObjectInfo info = null;
        objectInfoDict.TryGetValue(id, out info);
        return info;
    }
    /// <summary>
    /// 读取配置文件信息，根据内容生成对象，保存到字典
    /// </summary>
    void ReadInfo()
    {
        string text = objectsInfoListText.text;
        string[] strArray = text.Split('\n');
        ObjectInfo info = null;
        ObjectType type = ObjectType.Drug;
        DressType dressType = DressType.Accessory;
        ApplicationType applicationType = ApplicationType.Common;
        foreach (string str in strArray)
        {
            string[] proArray = str.Split(',');
            switch(proArray[3])
            {
                case "Drug":
                    type = ObjectType.Drug;
                    break;
                case "Equip":
                    type = ObjectType.Equip;
                    break;
                case "Mat":
                    type = ObjectType.Mat;
                    break;
            }
            if (type == ObjectType.Drug)
            {
                info = new ObjectInfo(int.Parse(proArray[0]), proArray[1], proArray[2], type, int.Parse(proArray[4]), int.Parse(proArray[5]), int.Parse(proArray[6]), int.Parse(proArray[7]));
                //objectInfoDict.Add(int.Parse(proArray[0]), info);
            }
            else if(type == ObjectType.Equip)
            {
                string strDressType = proArray[7];
                string strApplicationType = proArray[8];
                switch(strDressType)
                {
                    case "Headgear":
                        dressType = DressType.Headgear;
                        break;
                    case "Armor":
                        dressType = DressType.Armor;
                        break;
                    case "LeftHand":
                        dressType = DressType.LeftHand;
                        break;
                    case "RightHand":
                        dressType = DressType.RightHand;
                        break;
                    case "Shoe":
                        dressType = DressType.Shoe;
                        break;
                    case "Accessory":
                        dressType = DressType.Accessory;
                        break;
                }
                switch(strApplicationType)
                {
                    case "Swordman":
                        applicationType = ApplicationType.Swordman;
                        break;
                    case "Magician":
                        applicationType = ApplicationType.Magician;
                        break;
                    case "Common":
                        applicationType = ApplicationType.Common;
                        break;
                }
                info = new ObjectInfo(int.Parse(proArray[0]), proArray[1], proArray[2], type, int.Parse(proArray[4]), int.Parse(proArray[5]), int.Parse(proArray[6]),dressType,applicationType,int.Parse(proArray[9]),int.Parse(proArray[10]));
            }
            objectInfoDict.Add(int.Parse(proArray[0]), info);
        }
    }
}

