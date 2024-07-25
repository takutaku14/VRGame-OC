using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Screenの内容を変化させるためのスクリプト
public class boxScreen : MonoBehaviour
{

    private TextMeshProUGUI tmpText;

    // Start is called before the first frame update
    void Start()
    {
        // GameObjectからTextMeshProコンポーネントを取得
        tmpText = gameObject.GetComponent<TextMeshProUGUI>();
        if (tmpText != null)
        {
            tmpText.text = "*  *  *  *";
            //Debug.Log("TextMeshProUGUIコンポーネントが正常に取得されました。");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
