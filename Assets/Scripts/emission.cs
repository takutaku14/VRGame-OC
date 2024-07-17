using UnityEngine;

public class GlowEffect : MonoBehaviour
{
    public Color glowColor = Color.green;
    public float emissionIntensity = 1.0f;

    private Material material;

    void Start()
    {
        Renderer renderer = GetComponent<Renderer>();
        if (renderer != null)
        {
            // マテリアルのインスタンスを作成
            material = renderer.material;
            // エミッションを有効にする
            material.EnableKeyword("_EMISSION");
            UpdateEmission();
        }
        else
        {
            Debug.LogError("Rendererが見つかりません。オブジェクトにRendererコンポーネントがアタッチされていることを確認してください。");
        }
    }

    void Update()
    {
        if (material != null)
        {
            UpdateEmission();
        }
    }

    void UpdateEmission()
    {
        Color finalColor = glowColor * Mathf.LinearToGammaSpace(emissionIntensity);
        material.SetColor("_EmissionColor", finalColor);
    }
}
