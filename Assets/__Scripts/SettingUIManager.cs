using UnityEngine;
using UnityEngine.InputSystem;

public class SettingsUIManager : MonoBehaviour
{
    public GameObject settingsUIPrefab; // UI Prefab ����
    private GameObject spawnedUI; // ������ UI�� ����
    public Transform cameraTransform; // �÷��̾� ī�޶� Transform

    public InputActionProperty openSettingsAction; // A ��ư Input Action

    private void Update()
    {
        // A ��ư�� ���ȴ��� Ȯ��
        if (openSettingsAction.action.WasPressedThisFrame())
        {
            ToggleSettingsUI();
        }
    }

    private void ToggleSettingsUI()
    {
        if (spawnedUI == null)
        {
            // UI�� ������ ����
            spawnedUI = Instantiate(settingsUIPrefab);
            PositionUIInFrontOfCamera();
        }
        else
        {
            // UI�� �̹� �����ϸ� Ȱ��/��Ȱ�� ��ȯ
            spawnedUI.SetActive(!spawnedUI.activeSelf);
            if (spawnedUI.activeSelf)
            {
                PositionUIInFrontOfCamera();
            }
        }
    }

    private void PositionUIInFrontOfCamera()
    {
        // UI�� ī�޶� �տ� ��ġ
        if (spawnedUI != null)
        {
            float distance = 2.0f; // UI�� ī�޶� ������ �Ÿ�
            spawnedUI.transform.position = cameraTransform.position + cameraTransform.forward * distance;
            spawnedUI.transform.rotation = Quaternion.LookRotation(cameraTransform.forward);
        }
    }
}
