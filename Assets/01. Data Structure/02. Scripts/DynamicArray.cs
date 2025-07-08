using System.Collections.Generic;
using UnityEngine;

public class DynamicArray : MonoBehaviour
{
    //private object[] array = new object[0];

    //List<int> list1 = new List<int>(); // 리스트 선언
    //List<int> list2 = new List<int>() { 1, 2, 3, 4, 5 }; // 리스트 선언과 초기화
    //public List<int> list3; // private로 선언하면 널에러가 나옴. 반드시 초기화 필수

    public List<int> list1 = new List<int>();

    private void Start() {
        /*list1.Add(10);
        list2.Add(10);
        list3.Add(10);*/

        for (int i = 0; i < 10; i++)
            list1.Add(i); // 맨뒤에 추가

        list1.Add(11); // 맨뒤에 추가
        
        list1.Insert(5, 100); // 중간에 삽입
        
        list1.Remove(5); // 값 5를 제거
        list1.RemoveAt(5); // 인덱스 5번에 있는 값을 삭제
        list1.RemoveRange(1,3); // 인덱스 1번에서 3번까지 삭제
        list1.RemoveAll(x => x > 5); // 조건에 맞는 것들 일괄 삭제

        list1.Clear(); // 리스트 초기화

        list1.Sort(); // 오름차순 정렬

        if (list1.Contains(10)) // 리스트 안에 특정 값이 있는지 찾는 함수
            Debug.Log("리스트 안에 10 이 있음");
    }

    //public void Add(object o) {
    //    var temp = new object[array.Length + 1];
    //    for (int i = 0; i < array.Length; i++)
    //        temp[i] = array[i];

    //    array = temp;
    //    array[array.Length - 1] = 0;
    //}
}
