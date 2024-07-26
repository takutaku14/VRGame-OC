using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class buttonActionListener : MonoBehaviour
{
    //数値を変化させたいTextオブジェクトを入れる（boxScreenのtextオブジェクト入れてください）
    [SerializeField] private TextMeshProUGUI displayText;

    //数値の設定(ボタンの数値)
    [SerializeField] string buttonNumber;

    //現在の表示内容(staticだから共有されてる…？)←不安
    private static string currentDisplay = "";

    //物体同士がぶつかったときに呼ばれる。
    void OnCollisionEnter(Collision collision)
    {
        //プレイヤータグのついたものに衝突した際になるように設定。
        if (collision.gameObject.CompareTag("Player"))
        {
            if (currentDisplay.Length < 4)
            {
                currentDisplay += buttonNumber;
                displayText.text = currentDisplay;
            }
        }
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
