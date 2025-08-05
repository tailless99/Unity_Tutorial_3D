using System;
using UnityEngine;

public class StudyEventHandler2 : MonoBehaviour
{
    public class DataClass : EventArgs {
        public string dataName;

        public DataClass(string dataName) {
            this.dataName = dataName;
        }
    }

    private event EventHandler<DataClass> hanlder;

    private void Start() {
        hanlder+= MethodB;

        DataClass dataClass = new DataClass("Hellow Unity");
        hanlder?.Invoke(this, dataClass);
    }

    private void MethodB(object o, DataClass e) {
        Debug.Log(e.dataName);
    }
}
