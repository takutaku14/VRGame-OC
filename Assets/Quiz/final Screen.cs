using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScreen : MonoBehaviour
{
    //答えの数値を入力する変数
    [SerializeField] string answerNumber;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(finalbuttonactionlistener.nowNumbers == answerNumber)
        {
            GlobalVariables.isThird = true;
            GameManager.Instance.LightUp(3);
            GlobalVariables.PrintTrueCount();  //gameClear
        }
    }
}
