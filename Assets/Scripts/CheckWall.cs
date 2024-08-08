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
            // GameStatus��clear�̏ꍇ
            if (GlobalVariables.isClear)
            {
                GameManager.Instance.GameClear(other.gameObject);
            }

            tp.Teleport(other.gameObject);  // gameObject��tp��Ɉړ�������B
            Debug.Log("Current Game Status: " + (GlobalVariables.isClear ? "Clear" : "Not Clear"));
        }
    }
}
