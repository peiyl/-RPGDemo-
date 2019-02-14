using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class FollowPlayer : MonoBehaviour {
    private Transform player;
    private Vector3 offsetPosition;//相机与玩家的位置偏移
    private Vector3 targetPosition;
    private bool isRotating = false;

    public float distance = 0;
    public float scrollSpeed = 10;
    public float rotateSpeed = 1;
	void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        transform.LookAt(player.position);
        offsetPosition = transform.position - player.position;
	}
	void Update () {
        targetPosition = offsetPosition + player.position;
        transform.position = Vector3.Lerp(transform.position,targetPosition, Time.deltaTime * 5);
        
        RotateView();
        ScrollView();
    }
    /// <summary>
    /// 拉近拉远视野
    /// </summary>
    private void ScrollView()
    {
        //magnitude返回向量的长度
        distance = offsetPosition.magnitude;
        distance -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        //将数值控制在2-18
        distance = Mathf.Clamp(distance, 2, 18);
        offsetPosition = offsetPosition.normalized * distance;
    }
    /// <summary>
    /// 控制镜头旋转
    /// </summary>
    private void RotateView()
    {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            isRotating = true;
        }
        if (Input.GetMouseButtonUp(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            isRotating = false;
        }
        if(isRotating)
        {
            transform.RotateAround(player.position,player.up, rotateSpeed * Input.GetAxis("Mouse X"));

            Vector3 originalPos = transform.position;
            Quaternion originalRotation = transform.rotation;

            transform.RotateAround(player.position, transform.right, -rotateSpeed * Input.GetAxis("Mouse Y"));

            float x = transform.eulerAngles.x;
            //当超出范围则旋转无效。
            if (x<10 ||x>80)
            {
                transform.position = originalPos;
                transform.rotation = originalRotation;
            }


            offsetPosition = transform.position - player.position;
        }
        
    }
}
