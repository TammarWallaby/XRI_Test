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
        // 매 프레임마다 라인이 보이도록 강제
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

            // 선택 시에도 라인의 최대 길이 유지
            lineVisual.lineLength = 10f; // 원하는 길이로 조정 가능
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
