using UnityEngine;
using System.Globalization;
using System.IO;

public class PlantController : MonoBehaviour
{
    public int csvRowIndex = 1;
    public string twinId = "Plant1";
    public Renderer plantRenderer;
    public TwinUpdater twinUpdater;

    private void Start()
    {
        InvokeRepeating(nameof(UpdatePlantData), 1f, 5f);
    }

    void UpdatePlantData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "plant_data.csv");
        if (!File.Exists(filePath)) return;

        string[] lines = File.ReadAllLines(filePath);
        if (csvRowIndex >= lines.Length || csvRowIndex <= 0) return;

        string[] row = lines[csvRowIndex].Split(',');
        if (row.Length < 3) return;

        if (!float.TryParse(row[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float temperature)) return;
        if (!float.TryParse(row[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float humidity)) return;
        if (!float.TryParse(row[2], NumberStyles.Float, CultureInfo.InvariantCulture, out float growthDays)) return;

        float diseaseProbability = Mathf.Clamp01(
            0.02f * humidity + 0.01f * temperature + 0.005f * growthDays
        );

        bool diseaseDetected = diseaseProbability > 0.5f;
        // bool diseaseDetected = false;
        UpdateVisual(diseaseDetected);
        Debug.Log($"Plant: Temp={temperature}, Humidity={humidity}, Growth={growthDays}, Prob={diseaseProbability}, Detected={diseaseDetected}");

        if (twinUpdater != null)
        {
            twinUpdater.UpdateTwin(twinId, temperature, humidity, diseaseProbability, diseaseDetected);
        }
    }

    void UpdateVisual(bool diseaseDetected)
    {
        if (plantRenderer != null)
        {
            
            plantRenderer.material.color = diseaseDetected ? Color.red : Color.green;
        }
    }
}
