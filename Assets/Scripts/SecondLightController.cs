using UnityEngine;

public class SecondLightController : MonoBehaviour
{
    private Light pointLight;
    private float timer = 0f;

    void Start()
    {
        // �|�C���g���C�g�R���|�[�l���g�̎擾
        pointLight = GetComponent<Light>();
        if (pointLight == null)
        {
            Debug.LogError("Light �R���|�[�l���g��������܂���ł����B�|�C���g���C�g�I�u�W�F�N�g�ɃA�^�b�`���Ă��������B");
            return;
        }

        // �����F�̐ݒ�
        UpdateLightColor();
    }

    void Update()
    {
        // �^�C�}�[�̍X�V
        timer += Time.deltaTime;

        // 2�b���Ƃ�isSecond��؂�ւ���
        if (timer >= 2f)
        {
            GlobalVariables.isSecond = !GlobalVariables.isSecond;
            UpdateLightColor();
            timer = 0f;
        }
    }

    void UpdateLightColor()
    {
        // isSecond�̒l�ɉ����ă��C�g�̐F��ύX
        if (GlobalVariables.isSecond)
        {
            pointLight.color = Color.green; // �G�������h�O���[��
        }
        else
        {
            pointLight.color = Color.red; // �ԐF
        }
    }
}
