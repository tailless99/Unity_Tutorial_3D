using UnityEngine;

public class Fibonacci : MonoBehaviour
{
    private void Start() {
        for(int i = 0; i < 10; i++){
            int result = FibonacciRunction(i);
            Debug.Log(result);
        }
    }

    private int FibonacciRunction(int n) {
        if (n <= 1)
            return n;

        return FibonacciRunction(n - 1) + FibonacciRunction(n - 2);
    }
}
