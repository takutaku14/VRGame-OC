using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalbuttonactionlistener : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] string buttonNumber;

    private static string currentDisplay = "";
    public static string nowNumbers = "";

    // �C���^�[�o���ݒ�
    [SerializeField] private float collisionCooldown = 0.5f; // 1�b�̃C���^�[�o��
    [SerializeField] private float clearDelay = 0.1f; // ���������̒x��
    private float lastCollisionTime = 0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float currentTime = Time.time;

            if (currentTime - lastCollisionTime >= collisionCooldown)
            {
                if (currentDisplay.Length < 4)
                {
                    nowNumbers += buttonNumber;
                    currentDisplay += "*";
                    displayText.text = currentDisplay;

                    // 4���������͂��ꂽ�ꍇ�A���������̃R���[�`�����J�n
                    if (currentDisplay.Length == 4)
                    {
                        StartCoroutine(ClearTextAfterDelay());
                    }
                }

                lastCollisionTime = currentTime;
            }
        }
    }
    private IEnumerator ClearTextAfterDelay()
    {
        // �w�肵���x�����ԑ҂�
        yield return new WaitForSeconds(clearDelay);

        // ��������������
        nowNumbers = "";
        currentDisplay = "";
        displayText.text = currentDisplay;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
