using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Test_Script : MonoBehaviour
{
    public GameObject settingsPanel; // ���� �г� , �����ʼ�
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
            settingsPanel.SetActive(!settingsPanel.activeSelf); //�г� Ȱ��ȭ
    }

}
