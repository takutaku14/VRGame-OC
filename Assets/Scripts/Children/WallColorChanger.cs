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
            // �I�u�W�F�N�g�̐F�����ɕύX
            objRenderer.material.color = Color.black;
        }
    }
}
