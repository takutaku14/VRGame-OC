using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxerase : MonoBehaviour
{
    [SerializeField] bool firstQuestion;
    [SerializeField] bool secondQuestion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (firstQuestion)
        {
            if (GlobalVariables.isFirst)
            {
                if (!GlobalVariables.isInRoomA)
                {
                    buttonActionListener.currentDisplay = "";
                    Destroy(this.gameObject);
                }
            }
        }
        if (secondQuestion)
        {
            if (GlobalVariables.isSecond)
            {
                if (!GlobalVariables.isInRoomA)
                {
                    buttonActionListener.currentDisplay = "";
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
