using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public enum GameStatus {
        first,
        second,
        third,
        clear,
        gameOver,
    }

    private GameStatus status;
    public GameStatus STATUS {
        get { return status; }
    }

    // ���𐔂𖾎�����|�C���g���C�g
    [SerializeField]
    private PointLightController plc1;
    [SerializeField]
    private SecondLightController plc2;
    [SerializeField]
    private ThirdLightController plc3;

    // �N���A�[�X�e�[�W
    [SerializeField]
    private TelePoint cleartp;

    [SerializeField]
    private Menu menu;
    public Menu MENU {
        get { return menu; }
    }

    private float second;
    private int minute;
    private float totalTime = 0;
    private float q1Time = 0;
    private float q2Time = 0;
    private float q3Time = 0;
    private void Awake() {
        if (Instance == null) {
            Instance = this;
            //menu.GetComponent<Canvas>().enabled = false;
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

    public void GameClear(GameObject g) {
        //TODO �N���A����
        totalTime = Time.time;
        menu.showClearMenu(totalTime, q1Time, q2Time, q3Time);
        cleartp.Teleport(g);
    }

    //public void GameOver() {
    //    status = GameStatus.gameOver;

    //    //TODO �Q�[���I�[�o�[����
    //    ShowMenu();
    //    //menu.SwitchMenu(2);
    //}

    //public void ShowMenu() {
    //    Canvas canvas = menu.GetComponent<Canvas>();
    //    if (canvas.enabled == true) {
    //        canvas.enabled = false;
    //        Debug.Log("���j���[��\��");
    //    } else {
    //        canvas.enabled = true;
    //        Debug.Log("���j���[�\��");
    //    }
    //}

    public void LightUp(int num) {
        switch (num) {
            case 1:
                plc1.UpdateLightColor();
                q1Time = Time.time;
                break;
            case 2:
                plc2.UpdateLightColor();
                q2Time = Time.time - q1Time;
                break;
            case 3:
                plc3.UpdateLightColor();
                q3Time = Time.time - q1Time - q2Time;
                break;
            default:
                break;
        }
    }
}
