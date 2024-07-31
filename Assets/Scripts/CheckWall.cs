using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    [SerializeField]
    private TelePoint tp;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //GameStatusがclearの場合
            if(GameManager.Instance.STATUS == GameManager.GameStatus.clear) {
                GameManager.Instance.GameClear();
            }

            tp.TeleportRoom(other.gameObject);  //gameObjectをtp先に移動させる。
            Debug.Log(GameManager.Instance.STATUS);
        }
    }
}
