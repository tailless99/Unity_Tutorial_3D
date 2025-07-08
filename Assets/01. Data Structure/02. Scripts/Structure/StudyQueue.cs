using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyQueue : MonoBehaviour
{
    public Queue<int> queue = new Queue<int>();

    private void Start() {
        //for (int i = 1; i <= 10; i++)
        //    queue.Push(i);

        //Debug.Log(queue.Pop()); // Last 값을 뽑음
        //Debug.Log(queue.Count); // 현재 갯수

        //Debug.Log(queue.Peek()); // 현재 나올 대상을 확인만 하는 기능
        //Debug.Log(queue.Count); // 현재 갯수

        //Debug.Log(queue.Pop()); // Last 값을 뽑음
        //Debug.Log(queue.Count); // 현재 갯수
    }
}
