using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    [SerializeField]
    private TelePoint tp;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //GameStatus��clear�̏ꍇ
            if(GameManager.Instance.STATUS == GameManager.GameStatus.clear) {
                GameManager.Instance.GameClear();
            }

            tp.TeleportRoom(other.gameObject);  //gameObject��tp��Ɉړ�������B
            Debug.Log(GameManager.Instance.STATUS);
        }
    }
}
