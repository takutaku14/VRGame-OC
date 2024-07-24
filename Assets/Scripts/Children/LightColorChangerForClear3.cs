using UnityEngine;

public class LightColorChangerForClear3 : MonoBehaviour
{
    private Light pointLight;
    private float timer = 0f;
    private float changeInterval = 3f; // 3秒ごとに切り替える

    void Start()
    {
        pointLight = GetComponent<Light>();
        if (pointLight == null)
        {
            Debug.LogError("Light component not found on this GameObject.");
        }
        else
        {
            pointLight.color = Color.red; // デフォルトの色を赤に設定
        }
    }

    void Update()
    {
        // 3秒ごとにisClear3を切り替える
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            GlobalVariables.IsClear3 = !GlobalVariables.IsClear3;
            timer = 0f;
        }

        // isClear3の値に応じてポイントライトの色を変更
        if (GlobalVariables.IsClear3)
        {
            pointLight.color = new Color(0.31f, 0.78f, 0.47f); // エメラルドグリーンのRGB値
        }
        else
        {
            pointLight.color = Color.red; // デフォルトの色（赤）
        }
    }
}
