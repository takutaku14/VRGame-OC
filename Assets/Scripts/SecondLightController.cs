using UnityEngine;

public class SecondLightController : MonoBehaviour
{
    private Light pointLight;
    private float timer = 0f;

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
        UpdateLightColor();
    }

    void Update()
    {
        // タイマーの更新
        timer += Time.deltaTime;

        // 2秒ごとにisSecondを切り替える
        if (timer >= 2f)
        {
            GlobalVariables.isSecond = !GlobalVariables.isSecond;
            UpdateLightColor();
            timer = 0f;
        }
    }

    void UpdateLightColor()
    {
        // isSecondの値に応じてライトの色を変更
        if (GlobalVariables.isSecond)
        {
            pointLight.color = Color.green; // エメラルドグリーン
        }
        else
        {
            pointLight.color = Color.red; // 赤色
        }
    }
}
