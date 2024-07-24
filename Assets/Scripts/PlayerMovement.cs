using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;  // 移動速度
    public float rotationSpeed = 100f;  // 回転速度

    void Update()
    {
        // 移動入力を取得
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // 回転入力を取得
        float rotationHorizontal = 0f;
        float rotationVertical = 0f;

        if (Input.GetKey(KeyCode.J))
        {
            rotationHorizontal = -1f;  // 左回転
        }
        if (Input.GetKey(KeyCode.L))
        {
            rotationHorizontal = 1f;  // 右回転
        }
        if (Input.GetKey(KeyCode.I))
        {
            rotationVertical = -1f;  // 上回転
        }
        if (Input.GetKey(KeyCode.K))
        {
            rotationVertical = 1f;  // 下回転
        }

        // 移動ベクトルを作成
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical) * moveSpeed * Time.deltaTime;

        // 回転ベクトルを作成
        Vector3 rotation = new Vector3(rotationVertical, rotationHorizontal, 0.0f) * rotationSpeed * Time.deltaTime;

        // Transformを使って移動
        transform.Translate(movement, Space.World);

        // Transformを使って回転
        transform.Rotate(rotation, Space.Self);
    }
}
