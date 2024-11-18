using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsUIManager : MonoBehaviour
{
    public GameObject settingsUIPrefab; // UI Prefab 연결
    private GameObject spawnedUI; // 생성된 UI를 저장
    public Transform cameraTransform; // 플레이어 카메라 Transform

    public InputActionProperty openSettingsAction; // A 버튼 Input Action

    private void Update()
    {
        // A 버튼이 눌렸는지 확인
        if (openSettingsAction.action.WasPressedThisFrame())
        {
            ToggleSettingsUI();
        }
    }

    private void ToggleSettingsUI()
    {
        if (spawnedUI == null)
        {
            // UI가 없으면 생성
            spawnedUI = Instantiate(settingsUIPrefab);
            PositionUIInFrontOfCamera();
        }
        else
        {
            // UI가 이미 존재하면 활성/비활성 전환
            spawnedUI.SetActive(!spawnedUI.activeSelf);
            if (spawnedUI.activeSelf)
            {
                PositionUIInFrontOfCamera();
            }
        }
    }

    private void PositionUIInFrontOfCamera()
    {
        // UI를 카메라 앞에 배치
        if (spawnedUI != null)
        {
            float distance = 2.0f; // UI와 카메라 사이의 거리
            spawnedUI.transform.position = cameraTransform.position + cameraTransform.forward * distance;
            spawnedUI.transform.rotation = Quaternion.LookRotation(cameraTransform.forward);
        }
    }
}
