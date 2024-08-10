using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelsData", menuName = "LevelsData/LevelsData", order = 1)]
public class LevelsData : ScriptableObject
{
    [SerializeField] private List<Level> _levelData = new();

    public List<Level> LevelData => _levelData;
}
