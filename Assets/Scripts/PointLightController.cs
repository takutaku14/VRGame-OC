using UnityEngine;

public class PointLightController : MonoBehaviour
{
    private Light pointLight;
    private bool isRed = true;

    void Start()
    {
        // ポイントライトコンポーネントの取得
        pointLight = GetComponent<Light>();
        if (pointLight == null)
        {
            Debug.LogError("Light コンポーネントが見つかりませんでした。ポイントライトオブジェクトにアタッチしてください。");
            return;
        }

        // 初期色の設定
        pointLight.color = Color.red; // 初期色を赤に設定
    }

    void Update()
    {
        // Fキーが押されたら色を切り替え、グローバル変数を更新する
        if (Input.GetKeyDown(KeyCode.F))
        {
            isRed = !isRed;
            UpdateLightColor();
        }
    }

    void UpdateLightColor()
    {
        // isRedの値に応じてライトの色を変更
        if (isRed)
        {
            pointLight.color = Color.red; // 赤色
            GlobalVariables.isFirst = false; // 赤色に変更した場合はisFirstをfalseにする
        }
        else
        {
            pointLight.color = new Color(0.31f, 0.78f, 0.47f); // エメラルドグリーン
            GlobalVariables.isFirst = true; // エメラルドグリーンに変更した場合はisFirstをtrueにする
        }
    }
}