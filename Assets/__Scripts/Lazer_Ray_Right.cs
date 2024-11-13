using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; // Input System 사용

public class Lazer_Ray_Right : MonoBehaviour
{
    public InputActionProperty rightTriggerAction; // Input Action Property for 오른손 트리거 액션
    GameObject right_hand; // 오른손 앵커 오브젝트를 저장할 변수
    LineRenderer myLR; // LineRenderer 컴포넌트를 저장할 변수
    Ray ray; // 레이 객체 선언, 오른손 앵커의 위치와 방향을 기준으로 생성
    RaycastHit hit; // RaycastHit 객체 선언, 레이가 맞은 오브젝트 정보를 저장

    void Start()
    {
        // "RightHand" 이름의 오브젝트를 찾아 right_hand 변수에 저장
        right_hand = GameObject.Find("Right Controller");

        // 현재 오브젝트의 위치와 회전 각도를 right_hand 오브젝트에 맞춤
        transform.position = right_hand.transform.position;
        transform.eulerAngles = right_hand.transform.eulerAngles;

        // 현재 오브젝트를 right_hand의 자식으로 설정하여 이동 및 회전을 따라가도록 함
        transform.parent = right_hand.transform;

        // LineRenderer 컴포넌트를 가져와 myLR 변수에 저장
        myLR = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // 오른손 앵커의 위치를 레이의 시작점(origin)으로 설정
        ray.origin = right_hand.transform.position;

        // 오른손 앵커의 앞쪽 방향을 레이의 방향으로 설정
        ray.direction = right_hand.transform.forward;

        // LineRenderer의 첫 번째 점을 레이 시작점으로 설정
        myLR.SetPosition(0, ray.origin);

        // LineRenderer의 두 번째 점을 레이 시작점에서 100 유닛 떨어진 지점으로 설정
        myLR.SetPosition(1, ray.origin + ray.direction * 100.0f);

        // 레이캐스트를 사용하여 충돌이 발생하는지 검사 (100 유닛 범위 내)
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            // 충돌한 오브젝트가 "BUTTON" 태그를 가지고 있을 경우
            if (hit.collider.gameObject.CompareTag("Button"))
            {
                // LineRenderer의 색상을 청록색으로 변경하여 버튼에 닿았음을 표시
                myLR.startColor = Color.cyan;
                myLR.endColor = Color.cyan;

                // LineRenderer의 끝 점을 충돌 지점으로 설정하여 레이저가 버튼에 닿는 위치로 줄어들게 설정
                myLR.SetPosition(1, hit.point);

                // 오른손 트리거가 눌렸는지 확인
                if (rightTriggerAction.action.WasPressedThisFrame())
                {
                    // 버튼의 onClick 메서드 호출
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
        else
        {
            // 버튼에 닿지 않았을 때, LineRenderer의 색상을 흰색으로 설정
            myLR.startColor = Color.white;
            myLR.endColor = Color.white;
        }
    }
}
