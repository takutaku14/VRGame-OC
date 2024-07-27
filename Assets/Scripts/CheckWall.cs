using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //GameStatus‚ªclear‚Ìê‡
            if(GameManager.Instance.STATUS == GameManager.GameStatus.clear) {
                GameManager.Instance.GameClear();
            }

            Debug.Log(GameManager.Instance.STATUS);
        }
    }
}
