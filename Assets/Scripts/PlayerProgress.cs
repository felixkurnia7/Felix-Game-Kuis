using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Game Kuis/Player Progress")]
public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progressLevel;
    }

    [SerializeField]
    private string fileName = "save.sav";

    [SerializeField]
    private string _startingLevelPackName;

    public MainData progressData = new();

    public void SimpanProgress()
    {
        //progressData.koin = 200;
        //if (progressData.progressLevel == null)
        //    progressData.progressLevel = new();

        //progressData.progressLevel.Add("Level Pack 1", 3);
        //progressData.progressLevel.Add("Level Pack 3", 5);

        if (progressData.progressLevel == null)
        {
            progressData.progressLevel = new();
            progressData.koin = 0;
            progressData.progressLevel.Add(_startingLevelPackName, 1);
        }

//#if UNITY_EDITOR
//        var directory = Application.dataPath + "/Temporary";
//#elif (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
//        var directory = Application.persistentDataPath + "/ProgresLokal";
//#endif
        string directory = Application.persistentDataPath + "/Save/";
        string path = directory + fileName;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been created: " + directory);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("File Created: " + path);
        }

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream datafile = new FileStream(path, FileMode.Create);

        //var fileStream = File.Open(path, FileMode.OpenOrCreate);

        // Binary Formatter
        //var formatter = new BinaryFormatter();

        //fileStream.Flush();
        formatter.Serialize(datafile, progressData);
        //------------------------------------------------------------------

        // Binary Writer
        //var writer = new BinaryWriter(fileStream);

        //writer.Write(progressData.koin);
        //foreach (var i in progressData.progressLevel)
        //{
        //    writer.Write(i.Key);
        //    writer.Write(i.Value);
        //}

        //writer.Dispose();
        //------------------------------------------------------------------
        datafile.Close();
        //fileStream.Dispose();

        Debug.Log($"{fileName} berhasil disimpan");
    }

    public void MuatProgress()
    {
        string directory = Application.persistentDataPath + "/Save/";
        string path = directory + fileName;

        //var fileStream = File.Open(path, FileMode.OpenOrCreate);
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream dataFile = new FileStream(path, FileMode.Open);
            progressData = (MainData)formatter.Deserialize(dataFile);
            dataFile.Close();
        }
        else
        {
            SimpanProgress();
        }
        //try
        //{
            // Binary Reader
            //var reader = new BinaryReader(fileStream);

            //try
            //{
            //    progressData.koin = reader.ReadInt32();
            //    if (progressData.progressLevel == null)
            //        progressData.progressLevel = new();
            //    while (reader.PeekChar() != -1)
            //    {
            //        var namaLevelPack = reader.ReadString();
            //        var levelKe = reader.ReadInt32();
            //        progressData.progressLevel.Add(namaLevelPack, levelKe);
            //        Debug.Log($"{namaLevelPack}; {levelKe}");
            //    }

            //    reader.Dispose();
            //}
            //catch (System.Exception e)
            //{
            //    Debug.Log($"ERROR: Terjadi Kesalahan Saat Memuat Progress Binari\n {e.Message}");
            //    reader.Dispose();
            //    fileStream.Dispose();
            //    return false;
            //}
            //-----------------------------------------------------------------------------------------

            // Binary Formatter
        //    var formatter = new BinaryFormatter();

        //    progressData = (MainData)formatter.Deserialize(fileStream);
        //    Debug.Log($"{progressData.koin}; {progressData.progressLevel.Count}");

        //    fileStream.Dispose();
        //    return true;
        //}
        //catch(System.Exception e)
        //{
        //    fileStream.Dispose();
        //    Debug.Log($"ERROR: Terjadi Kesalahan Saat Memuat Progress\n {e.Message}");

        //    return false;
        //}
    }
}
