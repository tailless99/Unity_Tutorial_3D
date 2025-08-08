using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class JsonParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData {
        public string CharID;
        public string Name;
        public int Hp;
        public int Attack;
    }

    [System.Serializable]
    public class CharacterListWrapper{
        public List<CharacterData> characters = new List<CharacterData>();
    }

    private void Start() {
        var dataFile = Resources.Load<TextAsset>("JsonData");
        var data = dataFile.text;

        ParsingCharacterJsonData(data);
    }

    private void ParsingCharacterJsonData(string data) {
        CharacterListWrapper wrapper = JsonUtility.FromJson<CharacterListWrapper>(data);

        foreach(var cData in wrapper.characters) {
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.Hp} / {cData.Attack}");
        }
    }
}
