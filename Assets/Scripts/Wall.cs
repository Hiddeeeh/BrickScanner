using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wall
{
    public Vector3 corner1;
    public Vector3 corner2;
    public Vector3 corner3;
    public Vector3 corner4;
}

[System.Serializable]
public class Floor
{
    public Vector3 corner1;
    public Vector3 corner2;
    public Vector3 corner3;
    public Vector3 corner4;
}

[System.Serializable]
public class WallData
{
    public Wall[] walls;
    public Floor[] floors;
}
