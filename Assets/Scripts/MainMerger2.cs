using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainMerger : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static MainMerger Instance;

    public Color TeamColor; // new variable declared

    private void Awake()
    {

        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadColor();
    }

    // added to this 'mainmerger.cs' since script name "mainmanager.cs" referenced in jr propgrammer lessson does not exist in project assets.

    [System.Serializable]
    class SaveData
    {
        public Color TeamColor;

    }

    // serialization - creating json data.
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.TeamColor = TeamColor;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    // deserialization - accessing json data if it exists, i.e., reversal of SaveColor method is LoadColor.
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            TeamColor = data.TeamColor;
        }
    }

}
