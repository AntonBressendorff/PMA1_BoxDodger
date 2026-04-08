using UnityEngine;
using System.IO;
using System.Xml.Serialization;
using UnityEngine.UI;
using System.Text;
using TMPro;
// using System.Threading.Tasks.Dataflow;

public class DataSaver : MonoBehaviour
{
    public TextMeshProUGUI positionSavedShow;
    private GameData gameDataCurrent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameDataCurrent = transform.GetComponent<RecordData>().gameData;

        positionSavedShow.text = GetSavePath();
    }
    public void SaveData()
    {
        SaveCsv(gameDataCurrent);
    }

    public void MoveToDownloads()
    {
        string savedFolder = Path.Combine(GetSavePath(), "SavedData");
        if (!Directory.Exists(savedFolder))
        {
            Debug.LogWarning("SavedData folder does not exist!");
            return;
        }

        string downloadsPath;

        if (Application.platform == RuntimePlatform.Android)
        {
            downloadsPath = "/storage/emulated/0/Download/SavedData"; // Android Downloads
        }
        else
        {
            downloadsPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "SavedData");
        }

        if (!Directory.Exists(downloadsPath))
            Directory.CreateDirectory(downloadsPath);

        foreach (string file in Directory.GetFiles(savedFolder))
        {
            string destFile = Path.Combine(downloadsPath, Path.GetFileName(file));
            File.Copy(file, destFile, true);
            Debug.Log("Copied to Downloads: " + destFile);
        }

        Debug.Log("All files moved to Downloads folder!");
    }

    void SaveCsv(GameData gameData)
    {
        string folder = Path.Combine(GetSavePath(), "SavedData");
        if (!Directory.Exists(folder))
            Directory.CreateDirectory(folder);

        string pathFull = Path.Combine(folder, "gameData.csv");
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("time,posX,posY,score");

        foreach (var entry in gameData.entries)
            sb.AppendLine($"{entry.time},{entry.posX},{entry.posY},{entry.score}");

        File.WriteAllText(pathFull, sb.ToString());
        Debug.Log("Saved CSV: " + pathFull);
    }

    private string GetSavePath()
    {
        if (Application.isEditor)
            return Application.dataPath;
        else
            return Application.persistentDataPath;
    }

}
