using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        Debug.Log("すり抜けた");
        if (other.CompareTag("player")) {
            GameManager.Instance.solveQuest();
        }
    }
}
