using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // �v���C�x�[�g�ϐ�
    private static bool _isFirst = false;
    private static bool _isSecond = false;
    private static bool _isThird = false;
    private static bool _isClear = false;

    // ���ʂ̃��\�b�h
    private static void SetValue(ref bool field, bool value, string fieldName)
    {
        if (field != value)
        {
            field = value;
            Debug.Log(fieldName + ": " + field);
            PrintTrueCount(); // �ύX���������Ƃ���true�̐����o��
        }
    }

    // �v���p�e�B���g�p���ĕϐ��̕ύX���Ď�
    public static bool isFirst
    {
        get { return _isFirst; }
        set { SetValue(ref _isFirst, value, nameof(isFirst)); }
    }

    public static bool isSecond
    {
        get { return _isSecond; }
        set { SetValue(ref _isSecond, value, nameof(isSecond)); }
    }

    public static bool isThird
    {
        get { return _isThird; }
        set { SetValue(ref _isThird, value, nameof(isThird)); }
    }

    public static bool isClear
    {
        get { return _isClear; }
        private set
        {
            if (_isClear != value)
            {
                _isClear = value;
                Debug.Log("isClear: " + _isClear);
            }
        }
    }

    // true�̐����J�E���g���ăR���\�[���ɏo�͂��郁�\�b�h
    public static void PrintTrueCount()
    {
        int trueCount = 0;

        if (_isFirst) trueCount++;
        if (_isSecond) trueCount++;
        if (_isThird) trueCount++;

        Debug.Log("���݉�������̐�: " + trueCount);

        // true�̐���3�ȏ�Ȃ�Q�[���N���A
        if (trueCount >= 3)
        {
            isClear = true;
            Debug.Log("�Q�[���N���A");
        }
        else
        {
            isClear = false;
        }
    }

    void Start()
    {
        // ��������f�o�b�O�p�̃R�[�h���������Ƃ��ł��܂�
        Debug.Log("isFirst: " + isFirst);
        Debug.Log("isSecond: " + isSecond);
        Debug.Log("isThird: " + isThird);
        PrintTrueCount(); // ������Ԃ�true�̐����o��
    }
}
