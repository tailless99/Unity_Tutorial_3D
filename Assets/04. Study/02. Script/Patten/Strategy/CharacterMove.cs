using UnityEngine;

namespace Pattern {

    public class CharacterMove : MonoBehaviour {
        private IMovement movement;

        private void Start() {
            movement = new MoveWalk(3f);
        }

        private void Update() {
            Move();

            if (Input.GetKeyDown(KeyCode.A)) {
                movement = new MoveWalk(3f);
            }
            else if (Input.GetKeyDown(KeyCode.S)) {
                movement = new MoveRun(7f);
            }
            else if (Input.GetKeyDown(KeyCode.D)) {
                movement = new MoveFly(1.5f);
            }
        }

        private void Move() {
            movement.Move(transform);
        }
    }
}