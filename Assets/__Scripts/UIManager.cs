using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class UIManager : MonoBehaviour
{
    public XRDirectInteractor leftDirectInteractor;
    public XRDirectInteractor rightDirectInteractor;
    public GameObject settingsPanel; // 설정 패널 , 설정필수
    Image myButton;
    void Start()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
        myButton = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SettingsPanel()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf); //패널 활성화
        Debug.Log("변했음");
    }

}
