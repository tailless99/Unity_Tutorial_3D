using System.Collections.Generic;
using UnityEngine;

public class BoardBar : MonoBehaviour {
    public enum BarType { Left, Center, Right }
    public BarType barType;

    public Stack<GameObject> barStack = new Stack<GameObject>();

    private void OnMouseDown() {
        if (!HanoiTower.isSelected) { // ������ �ȵ� ����
            HanoiTower.isSelected = true;
            HanoiTower.currBar = this;
            HanoiTower.selectedDonut = PopDonut();
        }
        else { // ���õ� ����
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

        barStack.Push(donut); // Stack�� GameObject�� �ִ� ���
    }

    public GameObject PopDonut() {
        if (barStack.Count > 0) {
            GameObject donut = barStack.Pop(); // Stack���� GameObject�� ������ ���
            return donut; // ���� ������ ��ȯ
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
                Debug.Log("���� �������� ���Ӻ��� ��� ������ ��ܿ� �ִ� ������ �� �۽��ϴ�.");
                return false;
            }
        }

        return true;
    }
}
