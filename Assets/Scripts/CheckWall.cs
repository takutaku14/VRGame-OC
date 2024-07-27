using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    [SerializeField]
    private TelePoint tp;

    public void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            //GameStatusÇ™clearÇÃèÍçá
            if(GameManager.Instance.STATUS == GameManager.GameStatus.clear) {
                GameManager.Instance.GameClear();
            }

            TeleportRoom(other.gameObject);
            Debug.Log(GameManager.Instance.STATUS);
        }
    }

    public void TeleportRoom(GameObject player) {
        CharacterController cc = player.GetComponent<CharacterController>();

        cc.enabled = false;
        float x = tp.GetX();
        float y = player.transform.position.y;
        float z = tp.GetZ();
        player.transform.position = new Vector3(x, y, z);
        cc.enabled = true;
    }
}
