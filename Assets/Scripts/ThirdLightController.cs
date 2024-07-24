using UnityEngine;

public class ThirdLightController : MonoBehaviour
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

        // 2秒ごとにisThirdを切り替える
        if (timer >= 3f)
        {
            GlobalVariables.isThird = !GlobalVariables.isThird;
            UpdateLightColor();
            timer = 0f;
        }
    }

    void UpdateLightColor()
    {
        // isThirdの値に応じてライトの色を変更
        if (GlobalVariables.isThird)
        {
            pointLight.color = Color.green; // エメラルドグリーン
        }
        else
        {
            pointLight.color = Color.red; // 赤色
        }
    }
}
