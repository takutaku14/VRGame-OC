using UnityEngine;

public class LightColorChangerForClear3 : MonoBehaviour
{
    private Light pointLight;
    private float timer = 0f;
    private float changeInterval = 3f; // 3�b���Ƃɐ؂�ւ���

    void Start()
    {
        pointLight = GetComponent<Light>();
        if (pointLight == null)
        {
            Debug.LogError("Light component not found on this GameObject.");
        }
        else
        {
            pointLight.color = Color.red; // �f�t�H���g�̐F��Ԃɐݒ�
        }
    }

    void Update()
    {
        // 3�b���Ƃ�isClear3��؂�ւ���
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            GlobalVariables.IsClear3 = !GlobalVariables.IsClear3;
            timer = 0f;
        }

        // isClear3�̒l�ɉ����ă|�C���g���C�g�̐F��ύX
        if (GlobalVariables.IsClear3)
        {
            pointLight.color = new Color(0.31f, 0.78f, 0.47f); // �G�������h�O���[����RGB�l
        }
        else
        {
            pointLight.color = Color.red; // �f�t�H���g�̐F�i�ԁj
        }
    }
}
