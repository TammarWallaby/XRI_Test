using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
public class Lazer : MonoBehaviour
{
    public XRController rightHandController; // XRController
    public LineRenderer myLR;
    private Ray ray;
    private RaycastHit hit;
    private bool isCross = false;

    void Start()
    {
        rightHandController = GetComponent<XRController>();
        myLR = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (rightHandController != null)
        {
            ray.origin = rightHandController.transform.position;
            ray.direction = rightHandController.transform.forward;

            myLR.SetPosition(0, ray.origin);
            myLR.SetPosition(1, ray.origin + ray.direction * 100);

            // 레이캐스트 충돌 감지
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Button"))
                {
                    if (!isCross)
                    {
                        isCross = true;
                    }
                    myLR.startColor = Color.cyan;

                    // XR Interaction Toolkit의 트리거 버튼을 감지
                    bool isPressed = false;
                    if (rightHandController.inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isPressed) && isPressed)
                    {
                        Button buttonEvent = hit.collider.gameObject.GetComponent<Button>();
                        buttonEvent.onClick.Invoke();
                    }
                }
            }
            else
            {
                if (isCross)
                {
                    isCross = false;
                    Debug.Log("암튼색변함");
                }
                myLR.startColor = new Color(1.0f, 0.52f, 0.0f);
                Debug.Log("색변함");
            }
        }
    }
}
