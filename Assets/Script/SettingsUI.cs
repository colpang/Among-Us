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
    /// 오브젝트 활성화 후 ControlType에 따라 버튼 색상을 변경한다.
    /// </summary>
    private void OnEnable()
    {
        ControlButtonColorSwitch();
    }

    /// <summary>
    /// controlType을 변경시키고 버튼 색상을 변경하는 메소드.
    /// 버튼 클릭 이벤트가 발생하면 PlayerSettings.controlType을 초기화한다.
    /// 이후 ControlButtonColorSwitch 메소드를 실행한다.
    /// </summary>
    /// <param name="controlType">
    /// 마우스:0
    /// 키보드+마우스:1
    /// </param>
    public void SetControlMode(int controlType)
    {
        PlayerSettings.controlType = (EControlType)controlType;
        ControlButtonColorSwitch();
       
    }
    
    /// <summary>
    /// ControlType의 값에 따라 버튼의 컬러를 변경하는 메소드
    /// 현재 설정에 해당하는 버튼은 초록, 해당하지 않는 버튼은 흰색
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
    /// Button 클릭 이벤트로 사용하는 메소드
    /// CloseAfterDlay 코루틴 함수를 실행시킨다.
    /// </summary>
    public void Close()
    {
        StartCoroutine(CloseAfterDelay());
    }

    /// <summary>
    /// SettingsUI가 0.5초 딜레이 후 비활성화되도록 하는 코루틴 함수
    /// animator에 close 트리거를 전달한 후 딜레이 후에 Settings UI를 비활성화 시킨다.
    /// 이후 animator의 트리거를 초기화시킨다.
    /// </summary>
    /// <returns>WaitForSeconds : 0.5초 지연 후 코드를 실행</returns>
    private IEnumerator CloseAfterDelay()
    {
        animator.SetTrigger("close");
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
        animator.ResetTrigger("close");
    }
}
