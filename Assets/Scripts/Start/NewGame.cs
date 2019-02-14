using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewGame : MonoBehaviour
{
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(NewGameDown);
    }
    private void NewGameDown()
    {
        Debug.Log("new game down.");
    }
}
