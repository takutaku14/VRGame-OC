using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    // �����������ɌĂ΂��֐�
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit"); // ���O��\������
    }
}
