using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxTopPart : MonoBehaviour
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
        if(firstQuestion == true)
        {
            if(GlobalVariables.isFirst == true)
            {
                Destroy(gameObject);
            }
        }

        if(secondQuestion == true)
        {
            if(GlobalVariables.isSecond == true)
            {
                Destroy(gameObject);
            }
        }

    }
}
