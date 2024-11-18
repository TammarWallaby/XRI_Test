using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XR.Haptics;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerRayLine : MonoBehaviour
{
    [Header("Tools")]
    public Transform periostealElevator;
    public Transform scalpel;
    public Transform syringe;
    public Transform torqueRatchet;

    [Header("Ray Settings")]
    public Transform cTR;
    public float lineLength = 5f;
    // Ray �浹 üũ�� ���̾� ����
    public LayerMask raycastLayer = -1; // �⺻������ ��� ���̾�


    // Ray hit ����� ����
    RaycastHit hitInfo;
    LineRenderer cLR;
    XRController controller;
    public Transform originalModel;

    [SerializeField] private InputActionAsset m_ActionAsset;
    [SerializeField] private InputActionReference m_SelectRef;


    private void Awake()
    {
        cLR = GetComponent<LineRenderer>();
        controller=GetComponent<XRController>();
    }

    private void Start()
    {
        cLR.positionCount = 2;

        m_ActionAsset.Enable();
        m_SelectRef.action.performed += SelectTool;
    }

    private void Update()
    {
        Vector3 lineStartPoint = cTR.position;
        Vector3 direction = cTR.forward;

        // Ray ���� �� �浹 üũ
        Ray ray = new Ray(lineStartPoint, direction);
        bool didHit = Physics.Raycast(ray, out hitInfo, lineLength, raycastLayer);

        // LineRenderer ������Ʈ
        cLR.SetPosition(0, lineStartPoint);

        if (didHit&&hitInfo.collider.tag=="Tool")
        {
            // Ray�� ��ü�� �ε����� ���, �ε��� ���������� �� �׸���
            cLR.SetPosition(1, hitInfo.point);
            SetLineColor(Color.red);
            
        }
        else
        {
            // Ray�� ��ü�� �ε����� �ʾ��� ���, ���� ���̴�� �� �׸���
            Vector3 lineEndPoint = lineStartPoint + direction * lineLength;
            cLR.SetPosition(1, lineEndPoint);
            SetLineColor(Color.white);
        }
    }

    private void SetLineColor(Color color)
    {
        cLR.startColor = color;
        cLR.endColor = color;
    }

    private void SelectTool(InputAction.CallbackContext obj)
    {
        Debug.Log("SelectTool!");
        // ���⿡ if(hitInfo.collider.tag=="Tool"){if(hitInfo.gameObject.name=="Scalpel"){�𵨺���}} �̷��� ������ �ǳ�?
    }

}
