using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FPSController : MonoBehaviour {
    float x, z;
    public float speed = 50f;

    public GameObject cam;
    Quaternion cameraRot, characterRot;
    float Xsensityvity = 1.5f, Ysensityvity = 1.5f;

    bool cursorLock = true;

    Rigidbody rb;
    bool dashing = false;
    //bool onGround = true;

    //変数の宣言(角度の制限用)
    float minX = -90f, maxX = 90f;

    // Start is called before the first frame update
    void Start() {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //https://qiita.com/egiheiIsono/items/b9646f6e0aa34917f92f, https://qiita.com/A_25mc/items/d586478276089ba3ef42
        /*
        マウスのXYは座標を取得するが
        RotationのXYは軸を指定する
        */

        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;

        //Debug.Log(Input.GetAxis("Mouse X"));

        cameraRot *= Quaternion.Euler(-yRot, 0, 0);  //y軸の回転処理
        characterRot *= Quaternion.Euler(0, xRot, 0);  //x軸の回転処理 -> character(親オブジェクト)が回転しているため、camera(子オブジェクト)も一緒に回転する。 

        //Updateの中で作成した関数を呼ぶ
        cameraRot = ClampRotation(cameraRot);

        cam.transform.localRotation = cameraRot;
        transform.localRotation = characterRot;

        UpdateCursorLock();

        if (Input.GetKeyDown(KeyCode.LeftShift)) {
            ChangeDash();
        }
    }

    private void ChangeDash() {
        if (dashing) {
            dashing = false;
        } else {
            dashing = true;
        }
    }

    private void FixedUpdate() {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;  //A, D
        z = Input.GetAxisRaw("Vertical") * speed;  //W, S

        Debug.Log(x+", "+z);

        if (dashing) {
            rb.velocity = transform.forward * z * 2 + transform.right * x * 2;
        } else {
            rb.velocity = rb.transform.forward * z + rb.transform.right * x;
        }

    }


    public void UpdateCursorLock()  //画面内のカーソルを中心に固定
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            cursorLock = false;
        } else if (Input.GetMouseButton(0)) {
            cursorLock = true;
        }


        if (cursorLock) {
            Cursor.lockState = CursorLockMode.Locked;
        } else if (!cursorLock) {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    //角度制限関数の作成
    public Quaternion ClampRotation(Quaternion q) {
        //q = x,y,z,w (x,y,zはベクトル（量と向き）：wはスカラー（座標とは無関係の量）)

        q.x /= q.w;
        q.y /= q.w;
        q.z /= q.w;
        q.w = 1f;

        float angleX = Mathf.Atan(q.x) * Mathf.Rad2Deg * 2f;

        angleX = Mathf.Clamp(angleX, minX, maxX);

        q.x = Mathf.Tan(angleX * Mathf.Deg2Rad * 0.5f);

        return q;
    }
}