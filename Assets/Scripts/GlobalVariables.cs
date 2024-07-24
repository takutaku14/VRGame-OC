using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    private static bool _isClear1 = false;
    private static bool _isClear2 = false;
    private static bool _isClear3 = false;

    public static bool IsClear1
    {
        get
        {
            Debug.Log("IsClear1 accessed: " + _isClear1);
            return _isClear1;
        }
        set
        {
            _isClear1 = value;
            Debug.Log("IsClear1 set to: " + _isClear1);
        }
    }

    public static bool IsClear2
    {
        get
        {
            Debug.Log("IsClear2 accessed: " + _isClear2);
            return _isClear2;
        }
        set
        {
            _isClear2 = value;
            Debug.Log("IsClear2 set to: " + _isClear2);
        }
    }

    public static bool IsClear3
    {
        get
        {
            Debug.Log("IsClear3 accessed: " + _isClear3);
            return _isClear3;
        }
        set
        {
            _isClear3 = value;
            Debug.Log("IsClear3 set to: " + _isClear3);
        }
    }

    void Start()
    {
        // 初期化などを行う場合はここに記述します
    }

    void Update()
    {
        // 必要に応じてグローバル変数を更新する場合はここに記述します
    }
}
