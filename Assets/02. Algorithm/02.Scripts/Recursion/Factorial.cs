using UnityEngine;

public class Factorial : MonoBehaviour
{
    private void Start() {
        var result = FactorialFuncion(9);
        Debug.Log(result);
    }

    private int FactorialFuncion(int n) {
        if (n == 0)
            return 1;
        else {
            return n * FactorialFuncion(n - 1);
        }
    }
}
