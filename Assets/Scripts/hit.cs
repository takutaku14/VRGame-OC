using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // 当たった時に呼ばれる関数
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit"); // ログを表示する
    }
}
