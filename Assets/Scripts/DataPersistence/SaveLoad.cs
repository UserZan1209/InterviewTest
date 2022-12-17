 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class saveData 
{
    public int levelOneHighScore;
}


public class SaveLoad : MonoBehaviour
{
    [SerializeField] public static SaveLoad current;

    [HideInInspector] private string path;
    [HideInInspector] private string persistancePath;
    public int temp;
    void Start()
    {
        current = this;
        setPaths();

        writeSaveFile();
    }

    private void setPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "saveData.json";
        persistancePath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "saveData.json";
    }

    //load
    public void readSaveFile()
    {

        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        saveData data = JsonUtility.FromJson<saveData>(json);


        temp = data.levelOneHighScore;


        gameEvents.current.levelOneHS = data.levelOneHighScore;


    }
    //save
    public void writeSaveFile()
    {
        string savePath = path;

        saveData save = new saveData();
        save.levelOneHighScore = gameEvents.current.levelOneHS;

        string json = JsonUtility.ToJson(save);

        using StreamWriter writer = new StreamWriter(savePath);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            readSaveFile();
        }
    }

}
