using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterCreation : MonoBehaviour {
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    //所有可供选择的角色个数
    private int length;
    //输入的角色名称
    private string playerName;
    //UI
    private Button buttonNext;
    private Button buttonPrev;
    private Button buttonOK;
    private InputField inputName;
	void Start () {
        //获取输入信息
        buttonOK = GameObject.Find("Canvas/OK").GetComponent<Button>();
        inputName = GameObject.Find("Canvas/InputName").GetComponent<InputField>();
        inputName.onEndEdit.AddListener(OnEndEditPlayerName);
        buttonOK.onClick.AddListener(OnOKButtonClick);
        //设置上下选择按钮
        buttonNext = GameObject.Find("Canvas/Next").GetComponent<Button>();
        buttonPrev = GameObject.Find("Canvas/Prev").GetComponent<Button>();
        buttonNext.onClick.AddListener(OnNextButtonClick);
        buttonPrev.onClick.AddListener(OnPrevButtonClick);
        //获取角色形象
        length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for (int i = 0; i < length; i++)
        {
            characterGameObjects[i] = GameObject.Instantiate(characterPrefabs[i], transform.position, transform.rotation) as GameObject;
        }
        UpdateCharacterShow();
	}
    /// <summary>
    /// 更新所有角色的显示
    /// </summary>
    void UpdateCharacterShow()
    {
        
        for (int i = 0; i < length; i++)
        {
            if (i == selectedIndex)
            {
                characterGameObjects[selectedIndex].SetActive(true);
            }
            else
                characterGameObjects[i].SetActive(false);
        }
    }
    void OnNextButtonClick()
    {
        selectedIndex++;
        selectedIndex %= length;
        UpdateCharacterShow();
    }
    void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex ==-1)
        {
            selectedIndex = length - 1;
        }
        UpdateCharacterShow();
    }
    void OnOKButtonClick()
    {
        //存储选择的角色
        PlayerPrefs.SetInt("SelectedChaaracterIndex", selectedIndex);
        PlayerPrefs.SetString("name", playerName);
        Debug.Log("输入的名字是："+playerName);
        //加载下一个场景
    }
    /// <summary>
    /// 存储玩家输入的名字
    /// </summary>
    void OnEndEditPlayerName(string value)
    {
        playerName = value;
    }
}
