using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePoint : MonoBehaviour {
    private float x, z;
    // Start is called before the first frame update
    void Start() {
        x = transform.position.x;
        z = transform.position.z;
    }

    public void Teleport(GameObject player) {
        CharacterController cc = player.GetComponent<CharacterController>();

        if (cc != null) {
            cc.enabled = false;
            float y = player.transform.position.y;
            player.transform.position = new Vector3(x, y, z);
            cc.enabled = true;
        }
    }

    // public float GetX() { return x; }
    // public float GetZ() { return z; }
}
