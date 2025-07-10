using UnityEngine;

public class Permutation : MonoBehaviour
{
    public int[] array = new int[3] { 1, 2, 3 };

    private void Start() {
        PermutationFunction(array, 0);
    }

    private void PermutationFunction(int[] arr, int start) {
        if (start == arr.Length) {
            Debug.Log(string.Join(", ", arr));
            return;
        }
        
        for(int i = start; i < arr.Length; i++) {
            // Swap : �ڸ� �ٲٱ�
            var temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;

            PermutationFunction(arr, start + 1);

            // ���󺹱�
            temp = arr[start];
            arr[start] = arr[i];
            arr[i] = temp;
        }
    }
}
