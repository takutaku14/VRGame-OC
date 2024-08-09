using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour{

    [SerializeField]
    private TextMeshProUGUI totalTime;
    [SerializeField]
    private TextMeshProUGUI q1Time;
    [SerializeField]
    private TextMeshProUGUI q2Time;
    [SerializeField]
    private TextMeshProUGUI q3Time;

    public void showClearMenu(float total, float q1, float q2, float q3) {
        totalTime.text = total.ToString("00.00") + "s";
        q1Time.text = q1.ToString("00.00") + "s";
        q2Time.text = q2.ToString("00.00") + "s";
        q3Time.text = q3.ToString("00.00") + "s";
    }
}
