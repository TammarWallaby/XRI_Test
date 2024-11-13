using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UIManager : MonoBehaviour
{
    private GameObject canvas;
    public GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        mainCamera = GameObject.Find("XR Origin (XR Rig)"); // ��� ���� XR Origin �Ǵ� ī�޶� �̸��� �°� ����

        canvas.transform.position = mainCamera.transform.position + Vector3.forward * 5;
        canvas.transform.eulerAngles = mainCamera.transform.eulerAngles;

        // �θ� ���� ��, SetParent�� ����Ͽ� ���� ��ǥ�踦 ����
        canvas.transform.SetParent(mainCamera.transform, false);

        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) // 'A' ��ư
        {
            canvas.SetActive(!canvas.activeSelf); // ĵ���� ���
        }
    }
}
