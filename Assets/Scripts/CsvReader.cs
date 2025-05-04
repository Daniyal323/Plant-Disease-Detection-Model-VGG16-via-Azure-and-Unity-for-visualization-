using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class CsvReader : MonoBehaviour
{
    public List<EnvironmentData> data = new List<EnvironmentData>();

    void Start()
    {
        TextAsset file = Resources.Load<TextAsset>("environment");
        string[] lines = file.text.Split('\n');

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] values = line.Split(',');
            if (values.Length != 3) continue;

            float temperature = float.Parse(values[0]);
            float humidity = float.Parse(values[1]);
            float diseaseProbability = float.Parse(values[2]);

            data.Add(new EnvironmentData(temperature, humidity, diseaseProbability));
        }
    }
}

[System.Serializable]
public class EnvironmentData
{
    public float temperature;
    public float humidity;
    public float diseaseProbability;

    public EnvironmentData(float t, float h, float d)
    {
        temperature = t;
        humidity = h;
        diseaseProbability = d;
    }
}
