using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel; // 패널을 참조합니다.

    // 버튼을 누르면 패널의 활성화 상태를 전환
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf); // 현재 활성화 상태의 반대로 설정
        }
    }

    // 버튼을 눌렀을 때 패널을 보이게 설정
    public void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true); // 패널 활성화
        }
    }

    // 버튼을 눌렀을 때 패널을 숨기게 설정
    public void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // 패널 비활성화
        }
    }
}
