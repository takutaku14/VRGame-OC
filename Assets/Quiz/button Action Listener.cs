using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonActionListener : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI displayText;
    [SerializeField] string buttonNumber;

    public static string currentDisplay = "";

    // インターバル設定
    [SerializeField] private float collisionCooldown = 0.5f; // 1秒のインターバル
    [SerializeField] private float clearDelay = 0.1f; // 文字消去の遅延
    private float lastCollisionTime = 0f;

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            float currentTime = Time.time;

            if (currentTime - lastCollisionTime >= collisionCooldown) {
                if (currentDisplay.Length < 4) {
                    currentDisplay += buttonNumber;
                    displayText.text = currentDisplay;

                    // 4文字が入力された場合、文字消去のコルーチンを開始
                    if (currentDisplay.Length == 4) {
                        StartCoroutine(ClearTextAfterDelay());
                    }
                }

                lastCollisionTime = currentTime;
            }
        }
    }

    public void InputNumber() {
        float currentTime = Time.time;

        if (currentTime - lastCollisionTime >= collisionCooldown) {
            if (currentDisplay.Length < 4) {
                currentDisplay += buttonNumber;
                displayText.text = currentDisplay;

                // 4文字が入力された場合、文字消去のコルーチンを開始
                if (currentDisplay.Length == 4) {
                    StartCoroutine(ClearTextAfterDelay());
                }
            }

            lastCollisionTime = currentTime;
            Debug.Log("数字を入力中");
            Debug.Log("display: " + displayText.text);
            Debug.Log("current: " + currentDisplay);
        }
    }

    private IEnumerator ClearTextAfterDelay() {
        // 指定した遅延時間待つ
        yield return new WaitForSeconds(clearDelay);

        // 文字を消去する
        currentDisplay = "";
        displayText.text = currentDisplay;
    }

    void Start() {

    }

    void Update() {

    }
}

