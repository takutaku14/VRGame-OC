using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Screenの内容を変化させるためのスクリプト
public class boxScreen : MonoBehaviour
{
    
    //答えの数値を入力する変数
    [SerializeField] string answerNumber;

    [SerializeField] bool firstQuestion;
    [SerializeField] bool secondQuestion;


    private TextMeshProUGUI tmpText;

    // Start is called before the first frame update
    void Start()
    {
        // GameObjectからTextMeshProコンポーネントを取得
        tmpText = gameObject.GetComponent<TextMeshProUGUI>();
        if (tmpText != null)
        {
            //初期の表示内容を書いても良い
            tmpText.text = "";
            //Debug.Log("TextMeshProUGUIコンポーネントが正常に取得されました。");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (tmpText != null)
        {
            // 表示されているテキストがanswerNumberと一致するかをチェック
            if (tmpText.text == answerNumber)
            {
                if(firstQuestion == true)
                {
                    // 一致した場合の処理
                    //Debug.Log("表示されているテキストがanswerNumberと一致しました。");
                    GlobalVariables.isFirst = true;
                }
                if(secondQuestion == true)
                {
                    GlobalVariables.isSecond = true;
                }
            }
        }
    }
}
