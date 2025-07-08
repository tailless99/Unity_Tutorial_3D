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
        persons.Add("철수", new PersonData(10, "철수", 150f, 30f));
        persons.Add("영희", new PersonData(20, "영희", 150f, 30f));
        persons.Add("동수", new PersonData(30, "동수", 150f, 30f));

        Debug.Log(persons["철수"].age);

        /*
        persons.Add("철수", 10);
        persons.Add("영희", 10);
        persons.Add("동수", 10);

        int age = persons["철수"]; // Key값으로 value 출력
        Debug.Log($"철수의 나이는 {age}입니다.");

        foreach(var person in persons) {
            if(person.Value == 15) {
                Debug.Log($"나이가 15인 사람의 이름은 {person.Key}입니다.");
            }

            Debug.Log($"{person.Key}의 나이는 {person.Value}입니다.");
        }

        if (persons.ContainsKey("철수")) {
            Debug.Log("사람 중에 철수가 있다.");
        }

        if (persons.ContainsValue(17)) {
            Debug.Log("17살인 사람이 있다.");
        }
        */
    }
}
