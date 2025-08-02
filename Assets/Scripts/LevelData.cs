using System;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public class LevelData
{
    public string levelName;
    public List<LevelObjectData> levelObjectDatas = new();
}
[Serializable]
public class LevelObjectData
{
    public Vector3 position;
    public Quaternion rotation;
    public string objectName;
    public LevelObjectData(Vector3 position, Quaternion rotation, string objectName)
    {
        this.position = position;
        this.rotation = rotation;
        this.objectName = objectName;
    }
}