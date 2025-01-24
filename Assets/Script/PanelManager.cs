using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject panel; // �г��� �����մϴ�.

    // ��ư�� ������ �г��� Ȱ��ȭ ���¸� ��ȯ
    public void TogglePanel()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf); // ���� Ȱ��ȭ ������ �ݴ�� ����
        }
    }

    // ��ư�� ������ �� �г��� ���̰� ����
    public void ShowPanel()
    {
        if (panel != null)
        {
            panel.SetActive(true); // �г� Ȱ��ȭ
        }
    }

    // ��ư�� ������ �� �г��� ����� ����
    public void HidePanel()
    {
        if (panel != null)
        {
            panel.SetActive(false); // �г� ��Ȱ��ȭ
        }
    }
}
