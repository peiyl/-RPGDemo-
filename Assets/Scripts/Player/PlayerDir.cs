using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class PlayerDir : MonoBehaviour {
    public GameObject effectClickPrerab;
    private Ray ray;
    private RaycastHit hit;
    private NavMeshAgent myNavMeshAgent;
    private Animator myAnimator;
    void Start () {
        myNavMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        myAnimator = gameObject.GetComponent<Animator>();
	}
	void Update () {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        PlayerMoveByNav();
        IdleOrWalk();
	}
    /// <summary>
    /// 通过导航系统控制角色移动
    /// </summary>
    private void PlayerMoveByNav()
    {
        //EventSystem.current.IsPointerOverGameObject()
        //检测鼠标是否点击在ui上
        //需要引用UnityEngaged.EventSystem
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit) && hit.collider.tag == Tags.ground)
            {
                //实例化点击的效果
                ShowClickEffect(hit.point + new Vector3(0, 0.1f, 0));
                myNavMeshAgent.SetDestination(hit.point);
            }
        }
    }
    /// <summary>
    /// 实例化点击的效果
    /// </summary>
    /// <param name="hitPoint">需要实例化效果的位置</param>
    private void ShowClickEffect(Vector3 hitPoint)
    {
        Instantiate(effectClickPrerab, hitPoint, Quaternion.identity);
    }
    /// <summary>
    /// 根据角色与目标点的距离切换动画
    /// </summary>
    private void IdleOrWalk()
    {
        if(Mathf.Abs(myNavMeshAgent.remainingDistance)<=0.1f)
        {
            myAnimator.SetBool("walk", false);
        }
        else
        {
            myAnimator.SetBool("walk", true);
        }
    }
}
