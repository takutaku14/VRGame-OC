using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float rotationSpeed = 90f; // 1秒間に90度回転
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
        // 回転が完了していない場合は、回転処理を行う
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

        // 上下方向の回転の処理
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

        // 上下方向の回転がない場合のみ左右方向の回転を許可
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

        // 上下方向の回転をリセット
        if (Input.GetKey(KeyCode.N))
        {
            targetRotation = Quaternion.Euler(0, transform.eulerAngles.y, transform.eulerAngles.z);
            isVerticalRotation = false;
            isRotating = true;
        }

        // 上下左右の回転をリセット
        if (Input.GetKey(KeyCode.M))
        {
            targetRotation = Quaternion.identity;
            isVerticalRotation = false;
            isRotating = true;
        }

        // 入力の取得（↑↓←→キー）
        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            vertical = 1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vertical = -1f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontal = -1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontal = 1f;
        }

        // 移動の計算
        Vector3 movement = new Vector3(horizontal, 0, vertical) * moveSpeed * Time.deltaTime;

        // カメラの水平回転を考慮して移動方向を計算する
        Quaternion horizontalRotation = Quaternion.Euler(0, transform.eulerAngles.y, 0);
        movement = horizontalRotation * movement;

        // 接触方向に基づいて移動を制限
        if ((contactLeft && horizontal < 0) || (contactRight && horizontal > 0))
        {
            movement.x = 0;
        }

        if ((contactForward && vertical > 0) || (contactBackward && vertical < 0))
        {
            movement.z = 0;
        }

        // カメラの位置を更新
        transform.position += movement;
    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Vector3 contactNormal = contact.normal;

            // カメラの回転を考慮して接触方向を更新
            contactNormal = transform.InverseTransformDirection(contactNormal);

            if (Vector3.Dot(contactNormal, Vector3.left) > 0.5f)
            {
                contactLeft = true;
                Debug.Log("接触: 左");
            }
            if (Vector3.Dot(contactNormal, Vector3.right) > 0.5f)
            {
                contactRight = true;
                Debug.Log("接触: 右");
            }
            if (Vector3.Dot(contactNormal, Vector3.forward) > 0.5f)
            {
                contactForward = true;
                Debug.Log("接触: 前");
            }
            if (Vector3.Dot(contactNormal, Vector3.back) > 0.5f)
            {
                contactBackward = true;
                Debug.Log("接触: 後ろ");
            }
        }
    }

    void OnCollisionExit(Collision collision)
    {
        contactLeft = false;
        contactRight = false;
        contactForward = false;
        contactBackward = false;
        Debug.Log("接触解除");
    }
}