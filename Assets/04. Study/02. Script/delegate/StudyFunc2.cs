using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class StudyFunc2 : MonoBehaviour
{
    public List<Func<int, int, int>> funcList = new List<Func<int, int, int>>();

    private void Start() {
        funcList.Add(AddMethod);
        funcList.Add(MinusMethod);
        funcList.Add(MultiplyMethod);

        foreach (var func in funcList) {
            int result = func(10, 20);
            Debug.Log(result);
        }
    }

    private int AddMethod(int a, int b) => a + b;
    private int MinusMethod(int a, int b) => a - b;
    private int MultiplyMethod(int a, int b) => a * b;
}
