using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class finalbuttonactionlistener : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] string buttonNumber;

    private static string currentDisplay = "";
    public static string nowNumbers = "";

    // インターバル設定
    [SerializeField] private float collisionCooldown = 0.5f; // 1秒のインターバル
    [SerializeField] private float clearDelay = 0.1f; // 文字消去の遅延
    private float lastCollisionTime = 0f;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float currentTime = Time.time;

            if (currentTime - lastCollisionTime >= collisionCooldown)
            {
                if (currentDisplay.Length < 4)
                {
                    nowNumbers += buttonNumber;
                    currentDisplay += "*";
                    displayText.text = currentDisplay;

                    // 4文字が入力された場合、文字消去のコルーチンを開始
                    if (currentDisplay.Length == 4)
                    {
                        StartCoroutine(ClearTextAfterDelay());
                    }
                }

                lastCollisionTime = currentTime;
            }
        }
    }
    private IEnumerator ClearTextAfterDelay()
    {
        // 指定した遅延時間待つ
        yield return new WaitForSeconds(clearDelay);

        // 文字を消去する
        nowNumbers = "";
        currentDisplay = "";
        displayText.text = currentDisplay;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
