using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; // Input System ���

public class Lazer_Ray_Right : MonoBehaviour
{
    public InputActionProperty rightTriggerAction; // Input Action Property for ������ Ʈ���� �׼�
    GameObject right_hand; // ������ ��Ŀ ������Ʈ�� ������ ����
    LineRenderer myLR; // LineRenderer ������Ʈ�� ������ ����
    Ray ray; // ���� ��ü ����, ������ ��Ŀ�� ��ġ�� ������ �������� ����
    RaycastHit hit; // RaycastHit ��ü ����, ���̰� ���� ������Ʈ ������ ����

    void Start()
    {
        // "RightHand" �̸��� ������Ʈ�� ã�� right_hand ������ ����
        right_hand = GameObject.Find("Right Controller");

        // ���� ������Ʈ�� ��ġ�� ȸ�� ������ right_hand ������Ʈ�� ����
        transform.position = right_hand.transform.position;
        transform.eulerAngles = right_hand.transform.eulerAngles;

        // ���� ������Ʈ�� right_hand�� �ڽ����� �����Ͽ� �̵� �� ȸ���� ���󰡵��� ��
        transform.parent = right_hand.transform;

        // LineRenderer ������Ʈ�� ������ myLR ������ ����
        myLR = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // ������ ��Ŀ�� ��ġ�� ������ ������(origin)���� ����
        ray.origin = right_hand.transform.position;

        // ������ ��Ŀ�� ���� ������ ������ �������� ����
        ray.direction = right_hand.transform.forward;

        // LineRenderer�� ù ��° ���� ���� ���������� ����
        myLR.SetPosition(0, ray.origin);

        // LineRenderer�� �� ��° ���� ���� ���������� 100 ���� ������ �������� ����
        myLR.SetPosition(1, ray.origin + ray.direction * 100.0f);

        // ����ĳ��Ʈ�� ����Ͽ� �浹�� �߻��ϴ��� �˻� (100 ���� ���� ��)
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            // �浹�� ������Ʈ�� "BUTTON" �±׸� ������ ���� ���
            if (hit.collider.gameObject.CompareTag("Button"))
            {
                // LineRenderer�� ������ û�ϻ����� �����Ͽ� ��ư�� ������� ǥ��
                myLR.startColor = Color.cyan;
                myLR.endColor = Color.cyan;

                // LineRenderer�� �� ���� �浹 �������� �����Ͽ� �������� ��ư�� ��� ��ġ�� �پ��� ����
                myLR.SetPosition(1, hit.point);

                // ������ Ʈ���Ű� ���ȴ��� Ȯ��
                if (rightTriggerAction.action.WasPressedThisFrame())
                {
                    // ��ư�� onClick �޼��� ȣ��
                    hit.collider.gameObject.GetComponent<Button>().onClick.Invoke();
                }
            }
        }
        else
        {
            // ��ư�� ���� �ʾ��� ��, LineRenderer�� ������ ������� ����
            myLR.startColor = Color.white;
            myLR.endColor = Color.white;
        }
    }
}
