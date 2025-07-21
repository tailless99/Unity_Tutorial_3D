using System.Collections;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class FPSGameManager : Singleton<FPSGameManager>
{
    public enum GameState { Ready, Run, GameOver }
    public GameState gState = GameState.Ready;

    public GameObject gameLabel;
    TextMeshProUGUI gameText;

    private FPSPlayerMove player;

    private void Start() {
        gState = GameState.Ready;
        gameText = gameLabel.GetComponent<TextMeshProUGUI>();

        gameText.text = "Ready...";
        gameText.color = new Color(255,185,0,255);

        player = GameObject.Find("Player").GetComponent<FPSPlayerMove>();
        StartCoroutine(ReadyToStart());
    }

    IEnumerator ReadyToStart() {
        yield return new WaitForSeconds(2f);
        gameText.text = "Go!";
        yield return new WaitForSeconds(.5f);
        gameLabel.SetActive(false);
        gState = GameState.Run;
    }

    private void Update() {
        if(player.hp <= 0) {
            gameLabel.SetActive(true);
            gameText.text = "Game Over!";
            gameText.color = new Color(255,0,0,255);

            gState = GameState.GameOver;
        }
    }
}
