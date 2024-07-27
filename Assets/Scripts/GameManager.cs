using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public enum GameStatus {
        first, 
        second,
        third,
        clear,
        gameOver,
    }

    public static GameManager Instance;

    private GameStatus status;
    public GameStatus STATUS {
        get { return status; }
    }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        } else {
            Destroy(this.gameObject);
        }
    }

    public void InitGame() {
        //TODO 初期化処理
        status = GameStatus.first;

    }

    //謎をクリアした時に呼び出す。
    public void SolveQuestion() {
        switch (status) {
            case GameStatus.first:
                status = GameStatus.second;
                break;
            case GameStatus.second:
                status = GameStatus.third;
                break;
        }
    }

    public void GameClear() {
        status = GameStatus.clear;

        //TODO クリア処理
    }

    public void GameOver() {
        status = GameStatus.gameOver;

        //TODO ゲームオーバー処理既述
    }
}
