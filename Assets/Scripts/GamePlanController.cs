using System;
using UnityEngine;

public class GamePlanController : MonoBehaviour
{
    [SerializeField] 
    private GamePlanFactory _factory;

    private void Start()
    {
        var data = _factory.GetGamePlan();
        foreach (var stage in data.StageData)
            foreach (var cell in stage.GridData)
            {
                Debug.Log(cell.Identifier);
            }    
    }
}
