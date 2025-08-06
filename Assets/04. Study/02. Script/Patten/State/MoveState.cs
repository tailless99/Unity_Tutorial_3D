using UnityEngine;

public class MoveState : MonoBehaviour, IState {
    public void StateEnter() {
        Debug.Log("Enter Idle");
    }

    public void StateUpdate() {
        Debug.Log("Update");
    }

    public void StateExit() {
        Debug.Log("Exit Idle");
    }
}
