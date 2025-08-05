using System;
using UnityEngine;

public class ButtonManager : Singleton<ButtonManager>
{
    public static Action action;
    public static Action emergencyStopButton;

    protected override void Awake() {
        base.Awake();

        emergencyStopButton += StopMessage;
    }

    public void StopMessage() {
        Debug.Log("긴급 중지 실행");
    }

    public void MethodB() {

    }
}
