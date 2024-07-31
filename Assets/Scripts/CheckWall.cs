using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWall : MonoBehaviour
{
    [SerializeField]
    private TelePoint tp;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // GameStatusがclearの場合
            if (GlobalVariables.isClear)
            {
                GameManager.Instance.GameClear();
            }

            tp.TeleportRoom(other.gameObject);  // gameObjectをtp先に移動させる。
            Debug.Log("Current Game Status: " + (GlobalVariables.isClear ? "Clear" : "Not Clear"));
        }
    }
}
