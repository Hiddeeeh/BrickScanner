using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{
    //Het doel van deze is om de Json data te parsen naar Unity.
    WallData wallData;
    float wallHeight = 5.0f;
    float floorHeight = 0.1f;

    void Start()
    {
        LoadWallData();
        GenerateWall();
        GenerateFloor();
    }

    void LoadWallData()
    {
        //Ophalen JsonData
        TextAsset jsonData = Resources.Load<TextAsset>("wallData2");
        if (jsonData != null)
        {
            wallData = JsonUtility.FromJson<WallData>(jsonData.text);
            Debug.Log("Wall data loaded succesfully.");
        }
        else
        {
            Debug.LogError("wallData.json not found.");
        }


    }

    void GenerateWall()
    {
        foreach (var wall in wallData.walls)
        {
            //calculate wall length
            Vector3 wallLengthVector = (wall.corner3 + wall.corner4) / 2 - (wall.corner1 + wall.corner2) / 2;
            float wallLength = wallLengthVector.magnitude * 100;
            Vector3 wallThicknessVector = (wall.corner2 + wall.corner3) / 2 - (wall.corner1 + wall.corner4) / 2;
            float wallThickness = wallThicknessVector.magnitude * 100;
            Vector3 wallCenter = (wall.corner1 + wall.corner2 + wall.corner3 + wall.corner4) / 4 * 100;
            wallCenter.y += (wallHeight / 2);

            GameObject wallObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            wallObject.transform.position = wallCenter;
            wallObject.transform.localScale = new Vector3(wallThickness, wallHeight, wallLength);
            wallObject.transform.SetParent(this.transform);
        }
    }

    void GenerateFloor()
    {
        foreach (var floor in wallData.floors)
        {
            Vector3 floorLengthVector = (floor.corner3 + floor.corner4) / 2 - (floor.corner1 + floor.corner2) / 2;
            float floorLength = floorLengthVector.magnitude * 100;
            Vector3 floorThicknessVector = (floor.corner2 + floor.corner3) / 2 - (floor.corner1 + floor.corner4) / 2;
            float floorThickness = floorThicknessVector.magnitude * 100;
            Vector3 floorCenter = (floor.corner1 + floor.corner2 + floor.corner3 + floor.corner4) / 4 * 100;

            GameObject floorObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

            floorObject.transform.position = floorCenter;
            floorObject.transform.localScale = new Vector3(floorThickness, floorHeight, floorLength);
            floorObject.transform.SetParent(this.transform);
        }
    }
}
