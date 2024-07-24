using UnityEngine;

public class LightColorChanger : MonoBehaviour
{
    private Light pointLight;
    private float timer = 0f;
    private float changeInterval = 1f; // 3�b���Ƃɐ؂�ւ���

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
        // 3�b���Ƃ�isClear1��؂�ւ���
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            GlobalVariables.IsClear1 = !GlobalVariables.IsClear1;
            timer = 0f;
        }

        // isClear1�̒l�ɉ����ă|�C���g���C�g�̐F��ύX
        if (GlobalVariables.IsClear1)
        {
            pointLight.color = new Color(0.31f, 0.78f, 0.47f); // �G�������h�O���[����RGB�l
        }
        else
        {
            pointLight.color = Color.red; // �f�t�H���g�̐F�i�ԁj
        }
    }
}
