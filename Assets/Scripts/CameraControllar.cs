using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 90f; // 1�b�Ԃ�90�x��]
    private bool isVerticalRotation = false;

    private bool contactLeft = false;
    private bool contactRight = false;
    private bool contactForward = false;
    private bool contactBackward = false;

    private Quaternion targetRotation;
    private bool isRotating = false;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void Update()
    {
        // ���͂̎擾
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // ��]���������Ă��Ȃ��ꍇ�́A��]�������s��
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
            return;
        }

        // �㉺�����̉�]�̏���
        if (Input.GetKeyDown(KeyCode.I))
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles.x - 90, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = true;
            isRotating = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            targetRotation = Quaternion.Euler(transform.eulerAngles.x + 90, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = true;
            isRotating = true;
        }

        // �㉺�����̉�]���Ȃ��ꍇ�̂ݍ��E�����̉�]������
        if (!isVerticalRotation)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y - 90, transform.eulerAngles.z);
                isRotating = true;
            }

            if (Input.GetKeyDown(KeyCode.L))
            {
                targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 90, transform.eulerAngles.z);
                isRotating = true;
            }
        }

        // �㉺�����̉�]�����Z�b�g
        if (Input.GetKey(KeyCode.N))
        {
            targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = false;
            isRotating = true;
        }

        // �㉺���E�̉�]�����Z�b�g
        if (Input.GetKey(KeyCode.M))
        {
            targetRotation = Quaternion.identity;
            isVerticalRotation = false;
            isRotating = true;
        }

        // �ړ��̌v�Z
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        // �J�����̐�����]���l�����Ĉړ��������v�Z����
        Quaternion horizontalRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        movement = horizontalRotation * movement;

        // �ڐG�����Ɋ�Â��Ĉړ��𐧌�
        if ((contactLeft && horizontal < 0) || (contactRight && horizontal > 0))
        {
            movement.x = 0;
        }

        if ((contactForward && vertical > 0) || (contactBackward && vertical < 0))
        {
            movement.z = 0;
        }

        // �J�����̈ʒu���X�V
        transform.position += movement;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 contactNormal = contact.normal;

            // �J�����̉�]���l�����ĐڐG�������X�V
            contactNormal = transform.InverseTransformDirection(contactNormal);

            if (Vector3.Dot(contactNormal, Vector3.left) > 0.5f)
            {
                contactLeft = true;
                Debug.Log("�ڐG: ��");
            }
            if (Vector3.Dot(contactNormal, Vector3.right) > 0.5f)
            {
                contactRight = true;
                Debug.Log("�ڐG: �E");
            }
            if (Vector3.Dot(contactNormal, Vector3.forward) > 0.5f)
            {
                contactForward = true;
                Debug.Log("�ڐG: �O");
            }
            if (Vector3.Dot(contactNormal, Vector3.back) > 0.5f)
            {
                contactBackward = true;
                Debug.Log("�ڐG: ���");
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        contactLeft = false;
        contactRight = false;
        contactForward = false;
        contactBackward = false;
        Debug.Log("�ڐG����");
    }
}
