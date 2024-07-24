using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    private Renderer objRenderer;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        if (GlobalVariables.IsClear)
        {
            // オブジェクトの色を黒に変更
            objRenderer.material.color = Color.black;
        }
    }
}
