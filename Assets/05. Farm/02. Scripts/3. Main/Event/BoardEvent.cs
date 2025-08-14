using UnityEngine;

public class BoardEvent : MonoBehaviour
{
    [SerializeField] private GameObject BoardUI;
    [SerializeField] private GameObject singleBoard;
    [SerializeField] private GameObject AIBoard;

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            BoardUI.gameObject.SetActive(true);
            GameManager.Instance.SetCameraState(CameraState.Board);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            BoardUI.gameObject.SetActive(false);
            singleBoard.gameObject.SetActive(false);
            AIBoard.gameObject.SetActive(false);
            GameManager.Instance.SetCameraState(CameraState.House);
        }
    }

    public  void ShowBoard(int boardIndex) {
        if(boardIndex == 0) {
            singleBoard.gameObject.SetActive(true);
            Single_BoardController.startAction?.Invoke();
        }
        else {
            AIBoard.gameObject.SetActive(true);
            BoardController.startAction?.Invoke();
        }
    }
}
