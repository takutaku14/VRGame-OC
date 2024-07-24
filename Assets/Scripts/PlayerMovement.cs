using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // �ړ����x
    public float rotationSpeed = 100f;  // ��]���x

    void Update()
    {
        // �ړ����͂��擾
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // ��]���͂��擾
        float rotationHorizontal = 0f;
        float rotationVertical = 0f;

        if (Input.GetKey(KeyCode.J))
        {
            rotationHorizontal = -1f;  // ����]
        }
        if (Input.GetKey(KeyCode.L))
        {
            rotationHorizontal = 1f;  // �E��]
        }
        if (Input.GetKey(KeyCode.I))
        {
            rotationVertical = -1f;  // ���]
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotationVertical = 1f;  // ����]
        }

        // �ړ��x�N�g�����쐬
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

        // ��]�x�N�g�����쐬
        Vector3 rotation = new Vector3(rotationVertical, rotationHorizontal, 0.0f) * rotationSpeed * Time.deltaTime;

        // Transform���g���Ĉړ�
        transform.Translate(movement, Space.World);

        // Transform���g���ĉ�]
        transform.Rotate(rotation, Space.Self);
    }
}
