using UnityEngine;
using TMPro;

public class CountdownText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private float currentTime;
    private bool isCounting;

    void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    public void StartCountdown(float time)
    {
        currentTime = time;
        isCounting = true;
    }

    public void StopCountdown()
    {
        isCounting = false;
        textMesh.text = "";
    }

    void Update()
    {
        if (isCounting && currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            textMesh.text = $"{currentTime:F1}";
        }
        else if (isCounting && currentTime <= 0f)
        {
            // ī��Ʈ�ٿ� �Ϸ� ��
            textMesh.text = "";
            isCounting = false;
        }
    }
}
