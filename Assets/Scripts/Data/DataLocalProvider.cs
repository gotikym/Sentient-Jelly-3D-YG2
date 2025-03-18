using Newtonsoft.Json;
using System.IO;
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
        /*if (IsDataAlreadyExist() == false)
            return false;*/

        //_persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(File.ReadAllText(FullPath));
        if (YG2.saves.idSave < 0)
            return false;

        //YGInsides.LoadProgress();
        _persistentData.PlayerData = JsonConvert.DeserializeObject<PlayerData>(YG2.saves.Json);
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
        YG2.SaveProgress();
    }
    /*private string PATH_SAVES_EDITOR
    {
        get { return InfoYG.PATCH_PC_EDITOR + "/SavesEditorYG2.json"; }
    }*/

    //private bool IsDataAlreadyExist() => File.Exists(PATH_SAVES_EDITOR);
}

namespace YG
{
    public partial class SavesYG
    {
        public string Json;
    }
}