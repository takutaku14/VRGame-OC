using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finalScreen : MonoBehaviour
{
    //�����̐��l����͂���ϐ�
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
        }
    }
}
