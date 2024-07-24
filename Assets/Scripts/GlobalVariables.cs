using UnityEngine;

public class GlobalVariables : MonoBehaviour
{
    // グローバル変数の宣言
    public static bool isFirst = false;
    public static bool isSecond = false;
    public static bool isThird = false;

    void Start()
    {
        // 初期化やデバッグ用のコードを書くことができます
        Debug.Log("isFirst: " + isFirst);
        Debug.Log("isSecond: " + isSecond);
        Debug.Log("isThird: " + isThird);
    }
}
