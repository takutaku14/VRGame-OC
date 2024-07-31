
using UnityEngine;
using System.Collections;

public class SmoothMoveOnTrigger : MonoBehaviour
{
    public float moveDistance = 100f; // 移動距離
    public float moveDuration = 0.1f; // 移動にかかる時間
    public float waitTime = 10f;      // 元の位置に戻るまでの待ち時間
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
        Debug.Log("ドアを開けます");
        isMoving = true;
        Vector3 endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + moveDistance);
        float elapsedTime = 0f;

        // 前進移動
        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, endPosition, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = endPosition;

        // 待機
        yield return new WaitForSeconds(waitTime);

        // 復帰移動
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
