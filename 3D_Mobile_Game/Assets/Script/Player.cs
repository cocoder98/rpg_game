using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 1f;
    private bool isMove;
    private Vector3 targetPosition;

    void Start()
    {
        Debug.Log("Test");
    }

    //터치할 때 마우스가 여러번 눌리게 되는 현상 발생
    //터치할 때 터치가 눌렸을 때 한번만 눌리게끔 검사하여 움직이게 해야함 -> 최적화
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            /*터치 방식에서의 Object의 Postion을 움직이는 방식으로는 
            위에서 아래를 광선으로 쏘는 방식으로
            진행하여 Object의 Postion을 움직임*/
            RaycastHit hit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                Debug.Log("Hit object: " + hit.transform.name + " at position: " + hit.point);  //Collider가 있는 오브젝트의 이름과 위치를 출력
                targetPosition = hit.point;
                isMove = true;
            }
        }
        Move();
    }

    private void Move()
    {
        if(isMove)
        {
            bool isArrived = Vector3.Distance(targetPosition, transform.position) <= 0.1f;
            if(isArrived)
            {
                isMove = false;
                return;
            }
            else
            {
                Vector3 direction = (targetPosition - transform.position).normalized;
                transform.position += direction * movespeed * Time.deltaTime;
            }
        }
        
    }
}
