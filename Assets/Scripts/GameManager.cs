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

    // ���𐔂𖾎�����|�C���g���C�g
    [SerializeField]
    private PointLightController plc1;
    [SerializeField]
    private SecondLightController plc2;
    [SerializeField]
    private ThirdLightController plc3;

    public static GameManager Instance;

    private GameStatus status;
    public GameStatus STATUS {
        get { return status; }
    }

    [SerializeField]
    private Menu menu;
    public Menu MENU {
        get { return menu; }
    }
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            menu.GetComponent<Canvas>().enabled = false;
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
    public void SolveQuestion(int num) {
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
        ShowMenu();
        menu.SwitchMenu(1);
    }

    public void GameOver() {
        status = GameStatus.gameOver;

        //TODO �Q�[���I�[�o�[����
        ShowMenu();
        menu.SwitchMenu(2);
    }

    public void ShowMenu() {
        Canvas canvas = menu.GetComponent<Canvas>();
        if (canvas.enabled == true) {
            canvas.enabled = false;
            Debug.Log("���j���[��\��");
        } else {
            canvas.enabled = true;
            Debug.Log("���j���[�\��");
        }
    }

    public void LightUp(int num) {
        switch (num) {
            case 1:
                plc1.UpdateLightColor();
                break;
            case 2:
                plc2.UpdateLightColor();
                break;
            case 3:
                plc3.UpdateLightColor();
                break;
            default:
                break;
        }
    }
}
