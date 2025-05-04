using System.Collections;
using System.Globalization;
using System.IO;
using UnityEngine;

public class CSVDataUpdater : MonoBehaviour
{
    public TwinUpdater twinUpdater;
    public float updateInterval = 5f;

    public string[] twinIds;
    public Renderer[] plantRenderers; // Must match twinIds order

    private void Start()
    {
        StartCoroutine(ReadAndSendData());
    }

    IEnumerator ReadAndSendData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, "plant_data.csv");

        if (!File.Exists(filePath))
        {
            Debug.LogError("CSV file not found at: " + filePath);
            yield break;
        }

        string[] lines = File.ReadAllLines(filePath);

        for (int i = 1; i < lines.Length; i++)
        {
            if (i - 1 >= twinIds.Length)
            {
                Debug.LogWarning($"No twin ID for row {i}, skipping...");
                continue;
            }

            string[] row = lines[i].Split(',');

            if (row.Length < 3)
            {
                Debug.LogWarning($"Invalid row at line {i + 1}, skipping...");
                continue;
            }

            float temperature = float.Parse(row[0], CultureInfo.InvariantCulture);
            float humidity = float.Parse(row[1], CultureInfo.InvariantCulture);
            float growthDays = float.Parse(row[2], CultureInfo.InvariantCulture);

            float diseaseProbability = Mathf.Clamp01(
                0.02f * humidity + 0.01f * temperature + 0.005f * growthDays
            );
            bool diseaseDetected = diseaseProbability > 0.5f;
        // bool diseaseDetected = false;

            if (i - 1 < plantRenderers.Length && plantRenderers[i - 1] != null)
            {
                plantRenderers[i - 1].material.color = diseaseDetected ? Color.red : Color.green;
            }

            string twinId = twinIds[i - 1];
            twinUpdater.UpdateTwin(twinId, temperature, humidity, diseaseProbability, diseaseDetected);

            yield return new WaitForSeconds(updateInterval);
        }
    }
}
