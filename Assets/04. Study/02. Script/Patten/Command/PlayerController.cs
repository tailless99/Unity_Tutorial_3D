using System.Collections.Generic;
using UnityEngine;

namespace Pattern.Command {
    public class PlayerController : MonoBehaviour {
        public Player player;

        private ICommand attackCommand, JumpCommand, SkillCommand;

        private Queue<ICommand> commandQueue = new Queue<ICommand>();
        private Stack<ICommand> ExecuteCommands = new Stack<ICommand>();

        private void Awake() {
            attackCommand = new AttackCommand(player);
            JumpCommand = new JumpCommand(player);
            SkillCommand = new SkillCommand(player, "Fire Ball");
        }

        private void Update() {
            if (Input.GetKeyDown(KeyCode.Q)) {      // 공겨 기능
                attackCommand.Execute();
                ExecuteCommands.Push(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.W)) { // 점프 기능
                JumpCommand.Execute();
                ExecuteCommands.Push(JumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.E)) { // 스킬 공격 기능
                SkillCommand.Execute();
                ExecuteCommands.Push(SkillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Alpha1)) {      // 공겨 기능
                commandQueue.Enqueue(attackCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2)) { // 점프 기능
                commandQueue.Enqueue(JumpCommand);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3)) { // 스킬 공격 기능
                commandQueue.Enqueue(SkillCommand);
            }

            if (Input.GetKeyDown(KeyCode.Space)) { // 큐 일괄 실행
                Debug.Log("턴 종료 및 명령 실행");
                while(commandQueue.Count > 0) {
                    var command = commandQueue.Dequeue();
                    command.Execute();
                    ExecuteCommands.Push(command);
                }
            }

            if (Input.GetKeyDown(KeyCode.Z)) { // 취소 기능
                if(ExecuteCommands.Count > 0) {
                    var lastCommand = ExecuteCommands.Pop(); // 가장 최근에 저장한거
                    Debug.Log($"명령 취소 : {lastCommand.GetType().Name}");
                    lastCommand.Cancel();
                }
                else {
                    Debug.Log("되돌릴 명령이 없다");
                }
            }
        }
    }
}