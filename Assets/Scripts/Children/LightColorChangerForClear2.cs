using UnityEngine;

public class LightColorChangerForClear2 : MonoBehaviour
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
        // 3�b���Ƃ�isClear2��؂�ւ���
        timer += Time.deltaTime;
        if (timer >= changeInterval)
        {
            GlobalVariables.IsClear2 = !GlobalVariables.IsClear2;
            timer = 0f;
        }

        // isClear2�̒l�ɉ����ă|�C���g���C�g�̐F��ύX
        if (GlobalVariables.IsClear2)
        {
            pointLight.color = new Color(0.31f, 0.78f, 0.47f); // �G�������h�O���[����RGB�l
        }
        else
        {
            pointLight.color = Color.red; // �f�t�H���g�̐F�i�ԁj
        }
    }
}
