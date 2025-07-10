using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour {
    public enum BarType { Left, Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    private void OnMouseDown() {
        if (!HanoiTower.isSelected) { // 선택이 안된 상태
            HanoiTower.isSelected = true;
            HanoiTower.currBar = this;
            HanoiTower.selectedDonut = PopDonut();
        }
        else { // 선택된 상태
            PushDonut(HanoiTower.selectedDonut);
        }
    }

    public void PushDonut(GameObject donut) {
        if (!CheckDonut(donut)) return;

        HanoiTower.isSelected = false;
        HanoiTower.selectedDonut = null;
        HanoiTower.moveCount++;


        donut.transform.position = transform.position + Vector3.up * .5f;
        donut.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
        donut.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        barStack.Push(donut); // Stack에 GameObject를 넣는 기능
    }

    public GameObject PopDonut() {
        if (barStack.Count > 0) {
            GameObject donut = barStack.Pop(); // Stack에서 GameObject를 꺼내는 기능
            return donut; // 꺼낸 도넛을 반환
        }
        return null;
    }

    private bool CheckDonut(GameObject dount) {
        if (barStack.Count > 0) {
            int pushNumber = dount.GetComponent<Donut>().DonutNumber;

            GameObject peekDonut = barStack.Peek();
            int peekNumber = peekDonut.GetComponent<Donut>().DonutNumber;

            if (pushNumber < peekNumber) return true;
            else {
                Debug.Log("현재 넣으려는 도넛보다 대상 막대의 상단에 있는 도넛이 더 작습니다.");
                return false;
            }
        }

        return true;
    }
}
