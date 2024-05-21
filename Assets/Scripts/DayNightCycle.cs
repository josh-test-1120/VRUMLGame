using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    // Serialized variables
    [SerializeField] private Light sun;
    [SerializeField, Range(0, 24)] private float timeOfDay;
    [SerializeField] private float SunRotationSpeed;

    [Header("Lighting Preset")]
    [SerializeField] private Gradient skyColor;
    [SerializeField] private Gradient equatorColor;
    [SerializeField] private Gradient sunColor;

    private void OnValidate()
    {
        UpdateSunRotation();
        UpdateLighting();
    }

    private void UpdateSunRotation()
    {
        float sunRotation = Mathf.Lerp(-90, 270, timeOfDay / 24);
        sun.transform.rotation = Quaternion.Euler(sunRotation, sun.transform.rotation.y, sun.transform.rotation.z);
    }

    private void UpdateLighting()
    {
        float timeFraction = timeOfDay / 24;
        RenderSettings.ambientEquatorColor = equatorColor.Evaluate(timeFraction);
        RenderSettings.ambientSkyColor = skyColor.Evaluate(timeFraction);
        sun.color = sunColor.Evaluate(timeFraction);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay += Time.deltaTime * SunRotationSpeed;
        if (timeOfDay > 24) timeOfDay = 0;
        UpdateSunRotation();
        UpdateLighting();
    }
}
