using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class UIManager : MonoBehaviour
{
    private GameObject canvas;
    public GameObject mainCamera; // 카메라 이름을 mainCamera로 변경

    // Start is called before the first frame update
    void Start()
    {
        canvas = GameObject.Find("Canvas");
        mainCamera = GameObject.Find("XR Origin (XR Rig)"); // 사용 중인 XR Origin 또는 카메라 이름에 맞게 변경

        canvas.transform.position = mainCamera.transform.position + Vector3.forward * 5;
        canvas.transform.eulerAngles = mainCamera.transform.eulerAngles;
        canvas.transform.parent = mainCamera.transform;
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Gamepad.current != null && Gamepad.current.buttonSouth.wasPressedThisFrame) // 'A' 버튼
        {
            canvas.SetActive(!canvas.activeSelf); // 캔버스 토글
        }
    }
}
