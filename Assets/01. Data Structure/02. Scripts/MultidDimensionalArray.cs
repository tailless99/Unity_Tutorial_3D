using UnityEngine;

public class MultidDimensionalArray : MonoBehaviour
{
    int[,] array = new int[3, 3]; // 3�� 3���� ���� 2���� �迭
    int[,,] array2 = new int[2, 3, 4]; // 3���� �迭

    int[,] matrix = new int[3, 3];

    private void Start() {
        matrix[1, 2] = 25;
        Debug.Log(matrix[1,2]); // 25 ���
    }
}
