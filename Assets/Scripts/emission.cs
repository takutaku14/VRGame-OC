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
            // �}�e���A���̃C���X�^���X���쐬
            material = renderer.material;
            // �G�~�b�V������L���ɂ���
            material.EnableKeyword("_EMISSION");
            UpdateEmission();
        }
        else
        {
            Debug.LogError("Renderer��������܂���B�I�u�W�F�N�g��Renderer�R���|�[�l���g���A�^�b�`����Ă��邱�Ƃ��m�F���Ă��������B");
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
