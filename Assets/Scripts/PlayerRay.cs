using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRay : MonoBehaviour {
    [SerializeField] Camera fpsCam;             // �J����
    [SerializeField] float distance = 6f;    // ���o�\�ȋ���

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        // Ray�̓J�����̈ʒu����Ƃ΂�
        var rayStartPosition = fpsCam.transform.position;
        // Ray�̓J�����������Ă�����ɂƂ΂�
        var rayDirection = fpsCam.transform.forward.normalized;

        // Hit�����I�u�W�F�N�g�i�[�p
        RaycastHit raycastHit;

        // Ray���΂��iout raycastHit ��Hit�����I�u�W�F�N�g���擾����j
        var isHit = Physics.Raycast(rayStartPosition, rayDirection, out raycastHit, distance);

        // Debug.DrawRay (Vector3 start(ray���J�n����ʒu), Vector3 dir(ray�̕����ƒ���), Color color(���C���̐F));
        Debug.DrawRay(rayStartPosition, rayDirection * distance, Color.red);

        // �Ȃɂ������o������
        if (isHit) {
            if (raycastHit.collider.gameObject.CompareTag("Event")) {
                // Log��Hit�����I�u�W�F�N�g�����o��
                Debug.Log("HitObject : " + raycastHit.collider.gameObject.name);
            }
        }
    }
}