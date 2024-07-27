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

    public float GetX() { return x; }
    public float GetZ() { return z; }
}
