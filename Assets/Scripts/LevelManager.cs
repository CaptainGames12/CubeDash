using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static UnityEvent<string> OnSceneChanged = new();
    public string levelName = "StarterLevel";
    public TMP_InputField inputField;
    
    public List<GameObject> loadableObjects = new();
    public string path;
    public void Awake()
    {
        path = Path.Combine(Application.persistentDataPath, "level.json");
        Debug.Log(path);
    }
    public void SetLevelName()
    {
        levelName = inputField.text;
    }
    public void Save()
    {
        LevelData levelData = new()
        {
            levelName = levelName
        };
        GameObject[] gameObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject buildBlock in gameObjects)
        {

            if (LayerMask.LayerToName(buildBlock.layer) == "Persistant")
            {
                Debug.Log(buildBlock.layer);
                LevelObjectData levelObjectData = new(
                    buildBlock.transform.position,
                    buildBlock.transform.rotation,
                    buildBlock.tag
                    );
                levelData.levelObjectDatas.Add(levelObjectData);
                Debug.Log(levelObjectData.objectName);
            }
        }
        string json = JsonUtility.ToJson(levelData);
        
        File.WriteAllText(path, json);

    }
    public void Load()
    {
        LevelData levelData = new();
        if (!File.Exists(path))
        {
            Debug.Log("No file has been found");
            return;
        }
        string json = File.ReadAllText(path);
        levelData = JsonUtility.FromJson<LevelData>(json);
        levelName = levelData.levelName;
        foreach (LevelObjectData buildBlock in levelData.levelObjectDatas)
        {
            GameObject found = loadableObjects.Find(p => p.CompareTag(buildBlock.objectName));
            if (found != null)
            {
                GameObject instantiatedBlock = Instantiate(found, buildBlock.position, buildBlock.rotation);
            }
        }
    }
}
