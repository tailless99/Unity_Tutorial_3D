using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIStackManager : MonoBehaviour
{
    public Stack<GameObject> uiStack = new Stack<GameObject>();
    
    public Button[] buttons;
    public GameObject[] popupUIs;

    private void Start() {
        buttons[0].onClick.AddListener(PopupOn01);
        buttons[1].onClick.AddListener(PopupOn02);
        buttons[2].onClick.AddListener(PopupOn03);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            GameObject currUi = uiStack.Pop();
            currUi.SetActive(false);
        }
    }

    private void PopupOn01() {
        popupUIs[0].SetActive(true);
        uiStack.Push(popupUIs[0]);
    }

    private void PopupOn02() {
        popupUIs[1].SetActive(true);
        uiStack.Push(popupUIs[1]);
    }

    private void PopupOn03() {
        popupUIs[2].SetActive(true);
        uiStack.Push(popupUIs[2]);
    }
}
