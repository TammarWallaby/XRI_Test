using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RayVisualController : MonoBehaviour
{
    private XRRayInteractor rayInteractor;
    private XRInteractorLineVisual lineVisual;
    private bool wasLineEnabled = true;

    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
        lineVisual = GetComponent<XRInteractorLineVisual>();

        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.AddListener(OnSelectEntered);
            rayInteractor.selectExited.AddListener(OnSelectExited);
        }
    }

    void OnDestroy()
    {
        if (rayInteractor != null)
        {
            rayInteractor.selectEntered.RemoveListener(OnSelectEntered);
            rayInteractor.selectExited.RemoveListener(OnSelectExited);
        }
    }

    void Update()
    {
        // �� �����Ӹ��� ������ ���̵��� ����
        if (lineVisual != null && !lineVisual.enabled && wasLineEnabled)
        {
            lineVisual.enabled = true;
        }
    }

    private void OnSelectEntered(SelectEnterEventArgs args)
    {
        if (lineVisual != null)
        {
            wasLineEnabled = lineVisual.enabled;
            lineVisual.enabled = true;

            // ���� �ÿ��� ������ �ִ� ���� ����
            lineVisual.lineLength = 10f; // ���ϴ� ���̷� ���� ����
        }
    }

    private void OnSelectExited(SelectExitEventArgs args)
    {
        if (lineVisual != null)
        {
            lineVisual.enabled = wasLineEnabled;
        }
    }
}
