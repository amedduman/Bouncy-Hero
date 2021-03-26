using System;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public class BoundsWalls : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] GameObject ceil;
    [SerializeField] private GameObject ground;
    [SerializeField] private GameObject wallRight;
    [SerializeField] private GameObject wallLeft;
    
    void Start()
    {
        RePositionBoundsWalls();
    }

    void RePositionBoundsWalls()
    {
        var x = (float) Screen.width;
        var y = (float) Screen.height;
        
        var ceilPos = cam.ScreenToWorldPoint(new Vector3(x / 2, y), 0);
        var groundPos = cam.ScreenToWorldPoint(new Vector3(x / 2, 0), 0);
        var wallRPos = cam.ScreenToWorldPoint(new Vector3(x, y / 2), 0);
        var wallLPos = cam.ScreenToWorldPoint(new Vector3(0, y / 2), 0);
        
        ceil.transform.position = ceilPos;
        ground.transform.position = groundPos;
        wallRight.transform.position = wallRPos;
        wallLeft.transform.position = wallLPos;
    }
}
