using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

public class XmlParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData {
        public string CharID;
        public string Name;
        public int Hp;
        public int Attack;
    }

    [System.Serializable]
    [XmlRoot("Characters")]
    public class CharacterList {
        [XmlElement("Character")]
        public List<CharacterData> characters;
    }

    public List<CharacterData> characterDatas = new List<CharacterData>();

    private void Start() {
        var dataFile = Resources.Load<TextAsset>("XmlData");
        string data = dataFile.text;


    }

    private void ParsingCharacterXmlData(string data) {
        Debug.Log(data);

        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data)) {
            CharacterList loadData = (CharacterList)serializer.Deserialize(reader);
            characterDatas = loadData.characters;
        }

        foreach(var cData in characterDatas) {
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.Hp} / {cData.Attack}");
        }
    }
}
