using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // �O���[�o���ϐ��̐錾
    public static bool isFirst = false;
    public static bool isSecond = false;
    public static bool isThird = false;

    void Start()
    {
        // ��������f�o�b�O�p�̃R�[�h���������Ƃ��ł��܂�
        Debug.Log("isFirst: " + isFirst);
        Debug.Log("isSecond: " + isSecond);
        Debug.Log("isThird: " + isThird);
    }
}
