using System.Runtime.CompilerServices;
using UnityEngine;

public class DijkstraSearch : MonoBehaviour
{
    private int[,] nodes = new int[6, 6] {
       // 0,1,2,3,4,5
        { 0,1,2,0,4,0 }, // 0
        { 1,0,0,0,0,8 }, // 1
        { 2,0,0,3,0,0 }, // 2
        { 0,0,3,0,0,0 }, // 3
        { 4,0,0,0,0,2 }, // 4
        { 0,8,0,0,2,0 }, // 5
    };

    private void Start() {
        int start = 0;  // ���۰�
        int[] dist;     // ���� ��� ��� ����
        int[] prev;     // �湮 ��� ��� ����

        Dijkstra(start, out dist, out prev);

        for(int i = 0; i < nodes.GetLength(0); i++) {
            Debug.Log($"{start}���� {i}������ �ִ� �Ÿ� : {dist[i]}, ��� : {GetPath(i, prev)}");
        }
    }

    private void Dijkstra(int start, out int[] dist, out int[] prev) {
        int n = nodes.GetLength(0);
        dist = new int[n];
        prev = new int[n];
        bool[] visited = new bool[n];

        // ���� ���� �� �ʱ�ȭ
        for(int i = 0; i < n; i++) {
            dist[i] = int.MaxValue; // 2,147,483,647
            prev[i] = -1;
            visited[i] = false;
        }

        dist[start] = 0; // 0�� ��忡�� ����
        for(int cnt = 0; cnt < n; cnt++) {
            int u = -1; // �ִ� �Ÿ� ���
            int min = int.MaxValue; // �ִ� �Ÿ� ����ġ

            // �湮���� ���� ��� �� �ּ� �Ÿ� ��� ����
            for(int j = 0; j < n; j++) {
                if (!visited[j] && dist[j] < min) {
                    min = dist[j];
                    u = j;
                }
            }

            // ���̻� �ִ� �Ÿ� ��� ����
            if (u == -1) break;

            visited[u] = true;

            for(int k = 0; k < n; k++) {
                if (nodes[u,k] > 0 && !visited[k]) {
                    int newDist = dist[u] + nodes[u, k];
                    if(newDist < dist[k]) {
                        dist[k] = newDist;
                        prev[k] = u;
                    }
                }
            }
        }
    }

    private string GetPath(int end, int[] prev) {
        if (prev[end] == -1)
            return end.ToString();

        return $"{GetPath(prev[end], prev)} -> {end.ToString()}";
    }
}
