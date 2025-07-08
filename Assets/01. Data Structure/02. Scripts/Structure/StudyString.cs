using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World ***";
    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    private void Start() {
        // 그냥 string 변수이기 때문에 "Hello World ***"를 각 쪼개서 저장됨
        Debug.Log(str1[0]); // H
        Debug.Log(str1[2]); // l

        // string 배열이기 때문에 string 자체가 저장됨
        Debug.Log(str2[0]); // Hello
        Debug.Log(str2[2]); // World

        Debug.Log(str1.Length); // 문자열의 길이 : 5
        Debug.Log(str1.Trim()); // Hello World  (앞뒤에 있는 뛰어쓰기가 제거됨)
        Debug.Log(str1.Trim('*')); // Hello World , 앞 뒤에 있는 특정 문자 제거

        Debug.Log(str1.Contains('H')); // 대문자 H 가 있는지

        Debug.Log(str1.ToUpper()); // 대문자로 변환
        Debug.Log(str1.ToLower()); // 소문자로 변환

        str1 = str1.Replace("World", "Changed");
        Debug.Log(str1); // 특정 문자 치환
        
        var text = "I wi,ll b,e ba,ck";
        text.Split(","); // 특수문자로 쪼개기
        /* 출력 ->
         * I wi : [0]
         * ll b : [1]
         * e ba : [2]
         * ck   : [3]
         */

    }
}
