using System.Collections.Generic;
using UnityEngine;

public class StudyLinkedList : MonoBehaviour
{
    public LinkedList<int> linkedList1 = new LinkedList<int>();

    private void Start() {
        for (int i = 1; i <= 10; i++)
            linkedList1.AddLast(i); // 1~10Ãß°¡°¡

        linkedList1.AddFirst(1);
        linkedList1.AddLast(1);

        var node = linkedList1.AddFirst(1);

        linkedList1.AddBefore(node, 1);
        linkedList1.AddAfter(node, 1);
    }
}
