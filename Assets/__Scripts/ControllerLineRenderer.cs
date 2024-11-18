using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerLineRenderer : MonoBehaviour
{
    LineRenderer lineRenderer;
    public Transform controllerTransform;

    public float lineLength;

    

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Start()
    {
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }

    private void Update()
    {
        if (lineRenderer.enabled)
        {
            DrawLine(controllerTransform, lineRenderer);
        }
    }

    void DrawLine(Transform controller, LineRenderer lineRenderer)
    {
        Vector3 startPoint = controller.position;
        Vector3 endPoint = startPoint + controller.forward * lineLength;

        lineRenderer.SetPosition(0, startPoint);
        lineRenderer.SetPosition(1, endPoint);
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        // ������Ʈ�� ���õǾ��� �� LineRenderer�� �մϴ�.
        if (lineRenderer != null)
        {
            lineRenderer.enabled = true;
        }
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        // ������Ʈ ������ �����Ǿ��� �� LineRenderer�� ���ϴ�.
        if (lineRenderer != null)
        {
            lineRenderer.enabled = false;
        }
    }
}
