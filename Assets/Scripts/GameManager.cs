using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static Player p;

    public static int score = 0;
    public static Vector3 pos;
    public static bool isClear = false;
    void Start()
    {
        if(p==null) {
            Debug.Log("error");
        }else {
            pos = p.transform.position;
        }
    }

    // Update is called once per frame
    void Awake()
    {
        Instance = this;
        initGame();
    }

    public void solveQuest() {
        score++;
        if(score >= 2) {
            clearGame();
        }
    } 

    public void initGame() {
        score = 0;
        p.transform.position = pos;  //初期位置に瞬間移動
    }

    public void clearGame() {
        //クリア処理
        Debug.Log("GameClear");
    }

    public void gameOver() {
        //ゲームオーバー処理
        Debug.Log("GameOver");
    }
}
