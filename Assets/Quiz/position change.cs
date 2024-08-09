using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionchange : MonoBehaviour
{
    [SerializeField] bool second_question;
    //[SerializeField] GameObject obj;
    [SerializeField] float x;
    [SerializeField] float y;
    [SerializeField] float z;


    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //2問目なら
        if(second_question)
        {
            if (GlobalVariables.isFirst)
            {
                if (!GlobalVariables.isInRoomA)
                {
                    //if (this != null)
                    //{
                        transform.position = new Vector3(x, y, z);
                    //}
                    //else
                    //{
                        //Debug.LogWarning("GameObject 'obj' is not assigned.");
                    //}
                }
            }
        }
        //3問目なら
        if(!second_question)
        {
            if (GlobalVariables.isSecond)
            {
                if (!GlobalVariables.isInRoomA)
                {
                    //if (this != null)
                    //{
                        transform.position = new Vector3(x, y, z);
                    //}
                    //else
                    //{
                        //Debug.LogWarning("GameObject 'obj' is not assigned.");
                    //}
                }
            }
        }
    }
}
