using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using YG;
using YG.Insides;

public class DataLocalProvider : IDataProvider
{
    //private const string FileName = "PlayerSave";
    //private const string SaveFileExtension = ".json";

    private IPersistentData _persistentData;

    public DataLocalProvider(IPersistentData persistentData) => _persistentData = persistentData;

    //private string SavePath => Application.persistentDataPath;
    //private string FullPath => Path.Combine(SavePath, $"{FileName}{SaveFileExtension}");

    public bool TryLoad()
    {
        //YGInsides.LoadLocal();
        YGInsides.LoadProgress();
        //if (IsDataAlreadyExist() == false) return false;
        Debug.Log(YG2.saves.idSave);
        if (YG2.saves.idSave < 1)
            return false;

        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(YG2.saves.Json);
        Debug.Log(YG2.saves.Json.ToString());
        return true;
    }    

    public void Save()
    {
        /*File.WriteAllText(FullPath, JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        }));*/

        string json = JsonConvert.SerializeObject(_persistentData.PlayerData, Formatting.Indented, new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        });

        YG2.saves.Json = json;
        Debug.Log(YG2.saves.Json.ToString());
        YG2.SaveProgress();
    }
    //private bool IsDataAlreadyExist() => File.Exists(FullPath);
}

namespace YG
{
    public partial class SavesYG
    {
        public string Json;
    }
}