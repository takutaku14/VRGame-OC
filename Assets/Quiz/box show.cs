using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxexchange : MonoBehaviour
{
    //[SerializeField] bool secondQuestion;
    //[SerializeField] bool thirdQuestion;
    [SerializeField] GameObject second_obj;
    [SerializeField] GameObject third_obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GlobalVariables.isFirst)
        {
            if (!GlobalVariables.isInRoomA)
            {
                this.second_obj.SetActive(true);
                
            }
        }
        if (GlobalVariables.isSecond)
        {
            if (!GlobalVariables.isInRoomA)
            {
                this.third_obj.SetActive(true);
            }
        }
    }
}
