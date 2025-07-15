using UnityEngine;

public class MergeSort : MonoBehaviour
{
    private int[] array = { 5, 2, 1, 8, 3, 7, 6, 4 };

    void Start() {
        Debug.Log("���� �� : " + string.Join(", ", array));
        MSort(array, 0, array.Length - 1);
        Debug.Log("���� �� : " + string.Join(", ", array));
    }

    private void MSort(int[] arr, int left, int right) {
        if(left < right) {
            int mid = left + (right - left) / 2;
            MSort(arr,left, mid);
            MSort(arr,mid + 1, right);

            Merge(arr, left, mid, right);
        }
    }

    private void Merge(int[] arr, int left, int mid, int right) {
        int n1 = mid - left + 1;    // ���� �迭�� ũ��
        int n2 = right - mid;       // ������ �迭�� ũ��

        int[] leftArr = new int[n1]; // �ӽ� �迭 ũ�� ����
        int[] rightArr = new int[n2]; // �ӽ� �迭 ũ�� ����

        for (int i = 0; i < n1; i++) // ���� �迭 �� �ʱ�ȭ
            leftArr[i] = arr[left + i];

        for (int i = 0; i < n1; i++) // ������ �迭 �� �ʱ�ȭ
            rightArr[i] = arr[mid + 1 + i];

        int j = left; // ���� �迭�� ������
        int u = 0, v = 0; // �ݺ��� ���� �ӽ� ����

        while(u < n1 && v < n2) {
            // ���� ���� ������ ������ �۴ٸ�
            if (leftArr[u] <= rightArr[v]) { 
                arr[j] = leftArr[u];
                u++;
            }
            // ������ ���� ���ʰ� ���� �۴ٸ�
            else {
                arr[j] = rightArr[v];
                v++;
            }
        }

        // ���� �迭�� ���Ҵٸ�
        while(u < n1) { 
            arr[j] = leftArr[u];
            u++;
            j++;
        }

        // �����U �迭�� ���Ҵٸ�
        while(v < n2) {
            arr[j] = leftArr[v];
            v++;
            j++;
        }
    }
}
