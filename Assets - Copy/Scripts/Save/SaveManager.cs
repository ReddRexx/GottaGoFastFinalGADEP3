using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour
{
    public int highestGoldScore;
    public Text gold;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        gold.text = "Highest Gold Score: " + highestGoldScore;
    }

    public void SaveGame()
    {
        Save save = CreateSave();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/Game1Save.save");
        binaryFormatter.Serialize(file, save);
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/Game1Save.save"))
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/Game1Save.save", FileMode.Open);
            Save save= (Save)binaryFormatter.Deserialize(file);
            file.Close();
            highestGoldScore = save.highestGoldScore;
        }
    }

    private Save CreateSave()
    {
        Save save = new Save();
        save.highestGoldScore = highestGoldScore;
        return save;
    }

    public void ButtonSaving()
    {
        SaveGame();
    }
}
