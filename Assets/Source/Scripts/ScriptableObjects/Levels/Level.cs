using UnityEngine;
using UnityEngine.AddressableAssets;

[CreateAssetMenu(fileName = "Level", menuName = "LevelsData/Level", order = 1)]
public class Level : ScriptableObject
{
    [field: SerializeField] public Sprite Sprite { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public AssetReference Scene { get; private set; }

}