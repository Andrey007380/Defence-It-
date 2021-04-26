using UnityEngine;
[ExecuteAlways]
public class LightManager : MonoBehaviour
{

    [SerializeField] private Light DirectionalLight;
    [SerializeField] private LightningPresets Preset;

    [SerializeField, Range(0, 24)] private float TimeOfDay;
    private void Update()
    {
        if (Preset == null)
            return;

        if (Application.isPlaying)
        {
            TimeOfDay +=   Time.deltaTime / 12; //Change Speed of time: number lesser 12 = day faster
            TimeOfDay %= 24; //Clamp between 0-24
            UpdateLightning(TimeOfDay / 24);
        }
        else
        {
            UpdateLightning(TimeOfDay / 24f);
        }
    }

    private void UpdateLightning(float timePersent)
    {
        RenderSettings.ambientLight = Preset.AmbientColor.Evaluate(timePersent);
        RenderSettings.fogColor = Preset.FogColor.Evaluate(timePersent);

        if (DirectionalLight != null)
        {
            DirectionalLight.color = Preset.DirectionalColor.Evaluate(timePersent);
            DirectionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePersent * 360) - 90f, 170f, 0f));
        }
    }

    private void OnValidate()
    {
        if(DirectionalLight != null)
        return;
        if(RenderSettings.sun != null)
        {
            DirectionalLight = RenderSettings.sun;
        }
        else
        {
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights)
            {
                if(light.type == LightType.Directional)
                {
                    DirectionalLight = light;
                    return;
                }
            }
        }
    }
}
