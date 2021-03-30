using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Lightning Presets", menuName = "Scriptables/Lightning Presets", order =1)]
public class LightningPresets : ScriptableObject
{
    public Gradient AmbientColor;
    public Gradient DirectionalColor;
    public Gradient FogColor;
}
