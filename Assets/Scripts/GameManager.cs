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
        //TODO ����������
        status = GameStatus.first;

    }

    //����N���A�������ɌĂяo���B
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

        //TODO �N���A����
    }

    public void GameOver() {
        status = GameStatus.gameOver;

        //TODO �Q�[���I�[�o�[�������q
    }
}
