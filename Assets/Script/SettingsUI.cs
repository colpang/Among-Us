using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    [SerializeField]
    private Button MouseControlButton;
    [SerializeField]
    private Button KeyboardMouseControlButton;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// ������Ʈ Ȱ��ȭ �� ControlType�� ���� ��ư ������ �����Ѵ�.
    /// </summary>
    private void OnEnable()
    {
        ControlButtonColorSwitch();
    }

    /// <summary>
    /// controlType�� �����Ű�� ��ư ������ �����ϴ� �޼ҵ�.
    /// ��ư Ŭ�� �̺�Ʈ�� �߻��ϸ� PlayerSettings.controlType�� �ʱ�ȭ�Ѵ�.
    /// ���� ControlButtonColorSwitch �޼ҵ带 �����Ѵ�.
    /// </summary>
    /// <param name="controlType">
    /// ���콺:0
    /// Ű����+���콺:1
    /// </param>
    public void SetControlMode(int controlType)
    {
        PlayerSettings.controlType = (EControlType)controlType;
        ControlButtonColorSwitch();
       
    }
    
    /// <summary>
    /// ControlType�� ���� ���� ��ư�� �÷��� �����ϴ� �޼ҵ�
    /// ���� ������ �ش��ϴ� ��ư�� �ʷ�, �ش����� �ʴ� ��ư�� ���
    /// </summary>
    void ControlButtonColorSwitch()
    {
        switch (PlayerSettings.controlType)
        {
            case EControlType.Mouse:
                MouseControlButton.image.color = Color.green;
                KeyboardMouseControlButton.image.color = Color.white;
                break;
            case EControlType.KeboardMouse:
                MouseControlButton.image.color = Color.white;
                KeyboardMouseControlButton.image.color = Color.green;
                break;
        }
    }


    /// <summary>
    /// Button Ŭ�� �̺�Ʈ�� ����ϴ� �޼ҵ�
    /// CloseAfterDlay �ڷ�ƾ �Լ��� �����Ų��.
    /// </summary>
    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    /// <summary>
    /// SettingsUI�� 0.5�� ������ �� ��Ȱ��ȭ�ǵ��� �ϴ� �ڷ�ƾ �Լ�
    /// animator�� close Ʈ���Ÿ� ������ �� ������ �Ŀ� Settings UI�� ��Ȱ��ȭ ��Ų��.
    /// ���� animator�� Ʈ���Ÿ� �ʱ�ȭ��Ų��.
    /// </summary>
    /// <returns>WaitForSeconds : 0.5�� ���� �� �ڵ带 ����</returns>
    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
