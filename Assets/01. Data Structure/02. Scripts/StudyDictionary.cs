using System.Collections.Generic;
using UnityEngine;

public class PersonData {
    public int age;
    public string name;
    public float height;
    public float weight;

    public PersonData(int age, string name, float height, float weight) {
        this.age = age;
        this.name = name;
        this.height = height;
        this.weight = weight;
    }
}

public class StudyDictionary : MonoBehaviour {
    public Dictionary<string, PersonData> persons = new Dictionary<string, PersonData>();

    private void Start() {
        persons.Add("ö��", new PersonData(10, "ö��", 150f, 30f));
        persons.Add("����", new PersonData(20, "����", 150f, 30f));
        persons.Add("����", new PersonData(30, "����", 150f, 30f));

        Debug.Log(persons["ö��"].age);

        /*
        persons.Add("ö��", 10);
        persons.Add("����", 10);
        persons.Add("����", 10);

        int age = persons["ö��"]; // Key������ value ���
        Debug.Log($"ö���� ���̴� {age}�Դϴ�.");

        foreach(var person in persons) {
            if(person.Value == 15) {
                Debug.Log($"���̰� 15�� ����� �̸��� {person.Key}�Դϴ�.");
            }

            Debug.Log($"{person.Key}�� ���̴� {person.Value}�Դϴ�.");
        }

        if (persons.ContainsKey("ö��")) {
            Debug.Log("��� �߿� ö���� �ִ�.");
        }

        if (persons.ContainsValue(17)) {
            Debug.Log("17���� ����� �ִ�.");
        }
        */
    }
}
