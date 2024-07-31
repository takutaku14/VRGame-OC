using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour {
    [SerializeField]
    private MenuPart[] parts;

    private int shownNum;

    public void Awake() {
        foreach (MenuPart part in parts) {
            part.gameObject.SetActive(false);
        }
        parts[0].gameObject.SetActive(true);
        shownNum = 0;
    }
    public void SwitchMenu(int num) {
        // 0: default
        // 1: clear
        // 2: gameOver
        // 3: admin

        parts[shownNum].gameObject.SetActive(false);
        parts[num].gameObject.SetActive(true);
    }
}
