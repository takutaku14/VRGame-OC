using UnityEngine;

public class ThirdLightController : MonoBehaviour
{
    private Light pointLight;
    private bool isRed = true;

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
        pointLight.color = Color.red; // �����F��Ԃɐݒ�
    }

    void Update()
    {
        // T�L�[�������ꂽ��F��؂�ւ��A�O���[�o���ϐ����X�V����
        if (Input.GetKeyDown(KeyCode.T))
        {
            isRed = !isRed;
            UpdateLightColor();
        }
    }

    void UpdateLightColor()
    {
        // isRed�̒l�ɉ����ă��C�g�̐F��ύX
        if (isRed)
        {
            pointLight.color = Color.red; // �ԐF
            GlobalVariables.isThird = false; // �ԐF�ɕύX�����ꍇ��isThird��false�ɂ���
        }
        else
        {
            pointLight.color = new Color(0.31f, 0.78f, 0.47f); // �G�������h�O���[��
            GlobalVariables.isThird = true; // �G�������h�O���[���ɕύX�����ꍇ��isThird��true�ɂ���
        }
    }
}
