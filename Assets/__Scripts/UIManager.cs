using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UIManager : MonoBehaviour
{
    private GameObject canvas;
    public GameObject mainCamera;
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        mainCamera = GameObject.Find("XR Origin (XR Rig)"); // 사용 중인 XR Origin 또는 카메라 이름에 맞게 변경

        canvas.transform.position = mainCamera.transform.position + Vector3.forward * 5;
        canvas.transform.eulerAngles = mainCamera.transform.eulerAngles;

        // 부모 설정 시, SetParent를 사용하여 로컬 좌표계를 유지
        canvas.transform.SetParent(mainCamera.transform, false);

        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame)
        {
            canvas.SetActive(!canvas.activeSelf);
        }
    }
}
