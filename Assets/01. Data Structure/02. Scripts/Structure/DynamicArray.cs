using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    //private object[] array = new object[0];

    //List<int> list1 = new List<int>(); // ����Ʈ ����
    //List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 }; // ����Ʈ ����� �ʱ�ȭ
    //public List<int> list3; // private�� �����ϸ� �ο����� ����. �ݵ�� �ʱ�ȭ �ʼ�

    public List<int> list1 = new List<int>();

    private void Start() {
        /*list1.Add(10);
        list2.Add(10);
        list3.Add(10);*/

        for (int i = 0; i < 10; i++)
            list1.Add(i); // �ǵڿ� �߰�

        list1.Add(11); // �ǵڿ� �߰�
        
        list1.Insert(5, 100); // �߰��� ����
        
        list1.Remove(5); // �� 5�� ����
        list1.RemoveAt(5); // �ε��� 5���� �ִ� ���� ����
        list1.RemoveRange(1,3); // �ε��� 1������ 3������ ����
        list1.RemoveAll(x => x > 5); // ���ǿ� �´� �͵� �ϰ� ����

        list1.Clear(); // ����Ʈ �ʱ�ȭ

        list1.Sort(); // �������� ����

        if (list1.Contains(10)) // ����Ʈ �ȿ� Ư�� ���� �ִ��� ã�� �Լ�
            Debug.Log("����Ʈ �ȿ� 10 �� ����");
    }

    //public void Add(object o) {
    //    var temp = new object[array.Length + 1];
    //    for (int i = 0; i < array.Length; i++)
    //        temp[i] = array[i];

    //    array = temp;
    //    array[array.Length - 1] = 0;
    //}
}
