using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // プライベート変数
    private static bool _isFirst = false;
    private static bool _isSecond = false;
    private static bool _isThird = false;
    private static bool _isClear = false;

    // 共通のメソッド
    private static void SetValue(ref bool field, bool value, string fieldName)
    {
        if (field != value)
        {
            field = value;
            Debug.Log(fieldName + ": " + field);
            PrintTrueCount(); // 変更があったときにtrueの数を出力
        }
    }

    // プロパティを使用して変数の変更を監視
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

    // trueの数をカウントしてコンソールに出力するメソッド
    public static void PrintTrueCount()
    {
        int trueCount = 0;

        if (_isFirst) trueCount++;
        if (_isSecond) trueCount++;
        if (_isThird) trueCount++;

        Debug.Log("現在解いた謎の数: " + trueCount);

        // trueの数が3以上ならゲームクリア
        if (trueCount >= 3)
        {
            isClear = true;
            Debug.Log("ゲームクリア");
        }
        else
        {
            isClear = false;
        }
    }

    void Start()
    {
        // 初期化やデバッグ用のコードを書くことができます
        Debug.Log("isFirst: " + isFirst);
        Debug.Log("isSecond: " + isSecond);
        Debug.Log("isThird: " + isThird);
        PrintTrueCount(); // 初期状態のtrueの数を出力
    }
}
