using UnityEngine;

public class StudyString : MonoBehaviour
{
    public string str1 = "Hello World ***";
    public string[] str2 = new string[3] { "Hello", "Unity", "World" };

    private void Start() {
        // �׳� string �����̱� ������ "Hello World ***"�� �� �ɰ��� �����
        Debug.Log(str1[0]); // H
        Debug.Log(str1[2]); // l

        // string �迭�̱� ������ string ��ü�� �����
        Debug.Log(str2[0]); // Hello
        Debug.Log(str2[2]); // World

        Debug.Log(str1.Length); // ���ڿ��� ���� : 5
        Debug.Log(str1.Trim()); // Hello World  (�յڿ� �ִ� �پ�Ⱑ ���ŵ�)
        Debug.Log(str1.Trim('*')); // Hello World , �� �ڿ� �ִ� Ư�� ���� ����

        Debug.Log(str1.Contains('H')); // �빮�� H �� �ִ���

        Debug.Log(str1.ToUpper()); // �빮�ڷ� ��ȯ
        Debug.Log(str1.ToLower()); // �ҹ��ڷ� ��ȯ

        str1 = str1.Replace("World", "Changed");
        Debug.Log(str1); // Ư�� ���� ġȯ
        
        var text = "I wi,ll b,e ba,ck";
        text.Split(","); // Ư�����ڷ� �ɰ���
        /* ��� ->
         * I wi : [0]
         * ll b : [1]
         * e ba : [2]
         * ck   : [3]
         */

    }
}
