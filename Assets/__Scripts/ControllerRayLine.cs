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
    // Ray 충돌 체크할 레이어 설정
    public LayerMask raycastLayer = -1; // 기본값으로 모든 레이어


    // Ray hit 결과를 저장
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

        // Ray 생성 및 충돌 체크
        Ray ray = new Ray(lineStartPoint, direction);
        bool didHit = Physics.Raycast(ray, out hitInfo, lineLength, raycastLayer);

        // LineRenderer 업데이트
        cLR.SetPosition(0, lineStartPoint);

        if (didHit&&hitInfo.collider.tag=="Tool")
        {
            // Ray가 물체에 부딪혔을 경우, 부딪힌 지점까지만 선 그리기
            cLR.SetPosition(1, hitInfo.point);
            SetLineColor(Color.red);
            
        }
        else
        {
            // Ray가 물체에 부딪히지 않았을 경우, 원래 길이대로 선 그리기
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
        // 여기에 if(hitInfo.collider.tag=="Tool"){if(hitInfo.gameObject.name=="Scalpel"){모델변경}} 이런거 넣으면 되나?
    }

}
