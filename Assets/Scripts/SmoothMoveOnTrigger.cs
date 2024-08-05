
using UnityEngine;
using System.Collections;

public class SmoothMoveOnTrigger : MonoBehaviour
{
    public float moveDistance = 100f; // �ړ�����
    public float moveDuration = 0.1f; // �ړ��ɂ����鎞��
    public float waitTime = 10f;      // ���̈ʒu�ɖ߂�܂ł̑҂�����
    private bool isMoving = false;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isMoving)
        {
            StartCoroutine(SmoothMove());
        }
    }

    private IEnumerator SmoothMove()
    {
        Debug.Log("�h�A���J���܂�");
        isMoving = true;
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
        float elapsedTime = 0f;

        // �O�i�ړ�
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;

        // �ҋ@
        yield return new WaitForSeconds(waitTime);

        // ���A�ړ�
        elapsedTime = 0f;
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(endPosition, startPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        isMoving = false;
    }
}
