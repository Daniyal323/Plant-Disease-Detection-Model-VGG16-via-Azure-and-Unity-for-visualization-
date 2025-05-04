// using System.Collections;
// using UnityEngine;
// using UnityEngine.Networking;
// using System.Text;
// using System;

// public class TwinUpdater : MonoBehaviour
// {
//     public string twinId = "PlantEnvironment";
//     public float temperature = 27.5f;
//     public float humidity = 60f;
//     public float diseaseProbability = 0.21f;

//     void Start()
//     {
//         StartCoroutine(UpdateTwinProperties(temperature, humidity, diseaseProbability));
//     }

//     // IEnumerator UpdateTwinProperties()
//     // {
//     //     string url = $"https://Temperature-Humidity.api.sea.digitaltwins.azure.net/digitaltwins/{twinId}?api-version=2022-10-31";

//     //     string patchBody = "["
//     //         + $"{{\"op\": \"replace\", \"path\": \"/temperature\", \"value\": {temperature}}},"
//     //         + $"{{\"op\": \"replace\", \"path\": \"/humidity\", \"value\": {humidity}}},"
//     //         + $"{{\"op\": \"replace\", \"path\": \"/diseaseProbability\", \"value\": {diseaseProbability}}}"
//     //         + "]";

//     //     UnityWebRequest request = new UnityWebRequest(url, "PATCH");
//     //     byte[] bodyRaw = Encoding.UTF8.GetBytes(patchBody);
//     //     request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//     //     request.downloadHandler = new DownloadHandlerBuffer();

//     //     request.SetRequestHeader("Content-Type", "application/json");
//     //     request.SetRequestHeader("Authorization", "Bearer " + AzureAuth.accessToken);

//     //     yield return request.SendWebRequest();

//     //     if (request.result == UnityWebRequest.Result.Success)
//     //     {
//     //         Debug.Log("✅ Twin updated successfully!");
//     //     }
//     //     else
//     //     {
//     //         Debug.LogError("❌ Failed to update twin: " + request.error);
//     //         Debug.Log(request.downloadHandler.text);
//     //     }
//     // }

//     IEnumerator UpdateTwinProperties(float temperature, float humidity, float diseaseProbability)
// {
//     string token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSIsImtpZCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSJ9.eyJhdWQiOiJodHRwczovL2RpZ2l0YWx0d2lucy5henVyZS5uZXQiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9iNWEwYTlkOC03YmFkLTQ5YjktYjg0Ni0xOGZhNGMzMzY0YTMvIiwiaWF0IjoxNzQ2MzA2Njg0LCJuYmYiOjE3NDYzMDY2ODQsImV4cCI6MTc0NjMxMTU1NywiYWNyIjoiMSIsImFpbyI6IkFkUUFLLzhaQUFBQXNpNHhBUDExYks5dGgvZG1zWkQ5Wm1icmV1NnpXTDByU1lxWUQ3YWk1TjBuS09XNm1VWWpyWlVHdkVINFhZNGhPTlNtdlgzUW44Yy9GR1Z0VzJsdENCNE8xeTBndkhrMnFGVTd4TytvVmhvMFlqU2xTYkVoYjRjcEpWS2NsMkJaL1pVVUFWMWQ5c1VSbG5aNG1raC9hSzI4ZksrczZwbzgzR1VNazUzcGIwVUlRK2p1TjlpVFgvNkJpL2tzdkltdzYvc1BDRHZlbEdML1VtM2Q4RGg5NWtvT25VTDR2OVRWUWlrbVY2dFNJL1NmQk0wMWRrS3hOVGJGdUVWTkgvUER6dHVOaGFIZG1pbWxLbHVyNFAxMTdRPT0iLCJhbHRzZWNpZCI6IjE6bGl2ZS5jb206MDAwM0JGRkQ0RTM3RUEyRSIsImFtciI6WyJwd2QiLCJtZmEiXSwiYXBwaWQiOiJiNjc3YzI5MC1jZjRiLTRhOGUtYTYwZS05MWJhNjUwYTRhYmUiLCJhcHBpZGFjciI6IjAiLCJlbWFpbCI6Imlyb29mcm95YWxAZ21haWwuY29tIiwiZmFtaWx5X25hbWUiOiJQZXJ2ZXoiLCJnaXZlbl9uYW1lIjoiSXFyYSIsImlkcCI6ImxpdmUuY29tIiwiaWR0eXAiOiJ1c2VyIiwiaXBhZGRyIjoiMTgyLjE3Ny4xMjUuMjciLCJuYW1lIjoiSXFyYSBQZXJ2ZXoiLCJvaWQiOiIyZGU2OGMzOC1mMjFjLTQ0MzYtYWUwYS1kNTc3MmI3NDBhNTAiLCJwdWlkIjoiMTAwMzIwMDQ4NUUwQTQ4NCIsInJoIjoiMS5BVThBMkttZ3RhMTd1VW00UmhqNlRETmtveW4wQnd0TG54UkhrNUxNWG82QXlMQTVBVUZQQUEuIiwic2NwIjoidXNlcl9pbXBlcnNvbmF0aW9uIiwic2lkIjoiMDA0MTU2YTktZDhmYi0wZjM2LTg0YTgtNDBkZmE0ZDk5ODhkIiwic3ViIjoiZHMxVjV3NmN0TnNaanR2WXMwWElZQ0dYY2tOaU05T3lGeHNOY1J0WmxsayIsInRpZCI6ImI1YTBhOWQ4LTdiYWQtNDliOS1iODQ2LTE4ZmE0YzMzNjRhMyIsInVuaXF1ZV9uYW1lIjoibGl2ZS5jb20jaXJvb2Zyb3lhbEBnbWFpbC5jb20iLCJ1dGkiOiJWT1pRUVlWbExVMmdwNDBRWnZxb0FBIiwidmVyIjoiMS4wIiwieG1zX2lkcmVsIjoiMzAgMSJ9.MkjPJZboiQlXKOwqC_ScICLc3qKyDjE33Ob4eH3XJf2XLVn1M88eBfuQY4Qxp5UtPQEuHye7LVLXCJlF03TIbSRawmuoniOS77sVN-6QUapgx2D9DPPU6mVe1s5mKVhBR2PPqGTAiFQhHb_ZM1GVNe_IkZJQxZ6HZ32KsBAxEeLwjaEFuCQVoYr1nGNR9p9Eli1vXcCYaUOQXJ-P9O-IXkPE2vkir-ddv4nU62bOJy1dv-PO5RBeRxWcQzCUHQaMuUfTM6wttaLIysX3sXYszh-drMZf-XvBTnI_oVlJvBjUFvcoOjxFBRMIEM2oZ34K-yhS36KIorvSGZWkn6GLzg";
//     string url = "https://temperature-humidity.api.sea.digitaltwins.azure.net/digitaltwins/PlantEnvironment?api-version=2023-10-31";

//     string jsonPayload = $@"
//     {{
//         ""op"": ""replace"",
//         ""path"": ""/temperature"",
//         ""value"": {temperature}
//     }},
//     {{
//         ""op"": ""replace"",
//         ""path"": ""/humidity"",
//         ""value"": {humidity}
//     }},
//     {{
//         ""op"": ""replace"",
//         ""path"": ""/diseaseProbability"",
//         ""value"": {diseaseProbability}
//     }}";

//     jsonPayload = $"[{jsonPayload}]";

//     using (UnityWebRequest request = new UnityWebRequest(url, "PATCH"))
//     {
//         byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonPayload);
//         request.uploadHandler = new UploadHandlerRaw(bodyRaw);
//         request.downloadHandler = new DownloadHandlerBuffer();

//         request.SetRequestHeader("Authorization", $"Bearer {token}");
//         request.SetRequestHeader("Content-Type", "application/json-patch+json");

//         yield return request.SendWebRequest();

//         if (request.result != UnityWebRequest.Result.Success)
//         {
//             Debug.LogError($"❌ Failed to update twin: {request.responseCode}");
//             Debug.Log(request.downloadHandler.text);
//         }
//         else
//         {
//             Debug.Log("✅ Twin updated successfully!");
//         }
//     }
// }

// }


// using System.Collections;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Text;
// using UnityEngine;
// using System.Globalization;


// public class TwinUpdater : MonoBehaviour
// {
//     public string twinUrl = "https://temperature-humidity.api.sea.digitaltwins.azure.net/digitaltwins/PlantEnvironment?api-version=2023-10-31";
//     public string bearerToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSIsImtpZCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSJ9.eyJhdWQiOiJodHRwczovL2RpZ2l0YWx0d2lucy5henVyZS5uZXQiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9iNWEwYTlkOC03YmFkLTQ5YjktYjg0Ni0xOGZhNGMzMzY0YTMvIiwiaWF0IjoxNzQ2MzQyMTAxLCJuYmYiOjE3NDYzNDIxMDEsImV4cCI6MTc0NjM0NjAwMiwiYWNyIjoiMSIsImFpbyI6IkFaUUFhLzhaQUFBQU9aeVVjcVdSdml0Q003d05uQm5JZGZ3c3dtaFloYnNZU1ptSnhJTnZHUm1kMWdWeHM3THNsQmJQUWRQMXY4YWE5dzBkMVU4VDgxT21hM0krazNwV2lQVjF3eG9GeU1sZHh1allYakxvVmd6QWVRaVdnaHR2ckVIaDY1b1BNZk8rZzJKUzV3VGtZdE5NZ3pDVFluZ01CNDh3Y1ZJVjF4L2pPYm8wVVBBTFFoL3dmeFdneFA3Q25MQmxOeXR1dHVUVSIsImFsdHNlY2lkIjoiMTpsaXZlLmNvbTowMDAzQkZGRDRFMzdFQTJFIiwiYW1yIjpbInB3ZCIsIm1mYSJdLCJhcHBpZCI6ImI2NzdjMjkwLWNmNGItNGE4ZS1hNjBlLTkxYmE2NTBhNGFiZSIsImFwcGlkYWNyIjoiMCIsImVtYWlsIjoiaXJvb2Zyb3lhbEBnbWFpbC5jb20iLCJmYW1pbHlfbmFtZSI6IlBlcnZleiIsImdpdmVuX25hbWUiOiJJcXJhIiwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODIuMTc3LjEyNS4yNyIsIm5hbWUiOiJJcXJhIFBlcnZleiIsIm9pZCI6IjJkZTY4YzM4LWYyMWMtNDQzNi1hZTBhLWQ1NzcyYjc0MGE1MCIsInB1aWQiOiIxMDAzMjAwNDg1RTBBNDg0IiwicmgiOiIxLkFVOEEyS21ndGExN3VVbTRSaGo2VEROa295bjBCd3RMbnhSSGs1TE1YbzZBeUxBNUFVRlBBQS4iLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzaWQiOiIwMDQxNTZhOS1kOGZiLTBmMzYtODRhOC00MGRmYTRkOTk4OGQiLCJzdWIiOiJkczFWNXc2Y3ROc1pqdHZZczBYSVlDR1hja05pTTlPeUZ4c05jUnRabGxrIiwidGlkIjoiYjVhMGE5ZDgtN2JhZC00OWI5LWI4NDYtMThmYTRjMzM2NGEzIiwidW5pcXVlX25hbWUiOiJsaXZlLmNvbSNpcm9vZnJveWFsQGdtYWlsLmNvbSIsInV0aSI6IjJDTTBSb05ORWstLW85ampxcVNrQUEiLCJ2ZXIiOiIxLjAiLCJ4bXNfaWRyZWwiOiI0IDEifQ.Pay2gyIhatKaiL0Xl9l-6ACCChOsVPHbTRzVBgD4hTgYDiyds0_QuU2BlOPBPvEExCaOP-emVc3nMKvJwZVSLW-6EXGdQICtWd6Ih7wDKKeiKv6gk4EzppuzMd0Gr5VieMxH4d54HyxZa5eYtDzyxlnfh8UGVt4c8rAiFNh6xkdkob3JTHNhMHLz4MxSHx0hn33XSUGGXiVPDoA1ok59Gek1ajkA3aJ_SHpbPS4QU1aLXHq-GwOaV1rE0N4GEDElI0DZn4BpcX3uwbR6kmxOJ3MFNFnUizGlhiRA1_gFdt05Py7yMgFO_kSu1zhVc1j5xIkDt5Y8OgSbiwXp8GB-1A";

//     public IEnumerator UpdateTwinProperties(float temperature, float humidity, float diseaseProbability, bool diseaseDetected)
//     {
//         using (HttpClient client = new HttpClient())
//         {
//             client.DefaultRequestHeaders.Authorization =
//                 new AuthenticationHeaderValue("Bearer", bearerToken);

//             string patchJson = $@"
//             [
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/temperature"",
//                     ""value"": {temperature.ToString("F2", CultureInfo.InvariantCulture)}
//                 }},
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/humidity"",
//                     ""value"": {humidity.ToString("F2", CultureInfo.InvariantCulture)}
//                 }},
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/diseaseProbability"",
//                     ""value"": {diseaseProbability.ToString("F2", CultureInfo.InvariantCulture)}
//                 }},
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/diseaseDetected"",
//                     ""value"": {diseaseDetected.ToString().ToLower()}
//                 }}
//             ]";

//             StringContent content = new StringContent(patchJson, Encoding.UTF8, "application/json-patch+json");

//             HttpResponseMessage response = null;

//             try
//             {
//                 response = client.PatchAsync(twinUrl, content).Result;

//                 if (response.IsSuccessStatusCode)
//                 {
//                     Debug.Log("✅ Twin updated successfully!");
//                 }
//                 else
//                 {
//                     Debug.LogError($"❌ Failed to update twin: {(int)response.StatusCode}");
//                     string errorContent = response.Content.ReadAsStringAsync().Result;
//                     Debug.Log(errorContent);
//                 }
//             }
//             catch (System.Exception ex)
//             {
//                 Debug.LogError($"❌ Exception while updating twin: {ex.Message}");
//             }
//         }

//         yield return null;
//     }
// }


// using System.Collections;
// using System.Net.Http;
// using System.Net.Http.Headers;
// using System.Text;
// using UnityEngine;
// using System.Globalization;

// public class TwinUpdater : MonoBehaviour
// {
//     string twinUrl = "https://temperature-humidity.api.sea.digitaltwins.azure.net/digitaltwins/PlantEnvironment?api-version=2023-10-31";
//     string bearerToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSIsImtpZCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSJ9.eyJhdWQiOiJodHRwczovL2RpZ2l0YWx0d2lucy5henVyZS5uZXQiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9iNWEwYTlkOC03YmFkLTQ5YjktYjg0Ni0xOGZhNGMzMzY0YTMvIiwiaWF0IjoxNzQ2MzQyMTAxLCJuYmYiOjE3NDYzNDIxMDEsImV4cCI6MTc0NjM0NjAwMiwiYWNyIjoiMSIsImFpbyI6IkFaUUFhLzhaQUFBQU9aeVVjcVdSdml0Q003d05uQm5JZGZ3c3dtaFloYnNZU1ptSnhJTnZHUm1kMWdWeHM3THNsQmJQUWRQMXY4YWE5dzBkMVU4VDgxT21hM0krazNwV2lQVjF3eG9GeU1sZHh1allYakxvVmd6QWVRaVdnaHR2ckVIaDY1b1BNZk8rZzJKUzV3VGtZdE5NZ3pDVFluZ01CNDh3Y1ZJVjF4L2pPYm8wVVBBTFFoL3dmeFdneFA3Q25MQmxOeXR1dHVUVSIsImFsdHNlY2lkIjoiMTpsaXZlLmNvbTowMDAzQkZGRDRFMzdFQTJFIiwiYW1yIjpbInB3ZCIsIm1mYSJdLCJhcHBpZCI6ImI2NzdjMjkwLWNmNGItNGE4ZS1hNjBlLTkxYmE2NTBhNGFiZSIsImFwcGlkYWNyIjoiMCIsImVtYWlsIjoiaXJvb2Zyb3lhbEBnbWFpbC5jb20iLCJmYW1pbHlfbmFtZSI6IlBlcnZleiIsImdpdmVuX25hbWUiOiJJcXJhIiwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODIuMTc3LjEyNS4yNyIsIm5hbWUiOiJJcXJhIFBlcnZleiIsIm9pZCI6IjJkZTY4YzM4LWYyMWMtNDQzNi1hZTBhLWQ1NzcyYjc0MGE1MCIsInB1aWQiOiIxMDAzMjAwNDg1RTBBNDg0IiwicmgiOiIxLkFVOEEyS21ndGExN3VVbTRSaGo2VEROa295bjBCd3RMbnhSSGs1TE1YbzZBeUxBNUFVRlBBQS4iLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzaWQiOiIwMDQxNTZhOS1kOGZiLTBmMzYtODRhOC00MGRmYTRkOTk4OGQiLCJzdWIiOiJkczFWNXc2Y3ROc1pqdHZZczBYSVlDR1hja05pTTlPeUZ4c05jUnRabGxrIiwidGlkIjoiYjVhMGE5ZDgtN2JhZC00OWI5LWI4NDYtMThmYTRjMzM2NGEzIiwidW5pcXVlX25hbWUiOiJsaXZlLmNvbSNpcm9vZnJveWFsQGdtYWlsLmNvbSIsInV0aSI6IjJDTTBSb05ORWstLW85ampxcVNrQUEiLCJ2ZXIiOiIxLjAiLCJ4bXNfaWRyZWwiOiI0IDEifQ.Pay2gyIhatKaiL0Xl9l-6ACCChOsVPHbTRzVBgD4hTgYDiyds0_QuU2BlOPBPvEExCaOP-emVc3nMKvJwZVSLW-6EXGdQICtWd6Ih7wDKKeiKv6gk4EzppuzMd0Gr5VieMxH4d54HyxZa5eYtDzyxlnfh8UGVt4c8rAiFNh6xkdkob3JTHNhMHLz4MxSHx0hn33XSUGGXiVPDoA1ok59Gek1ajkA3aJ_SHpbPS4QU1aLXHq-GwOaV1rE0N4GEDElI0DZn4BpcX3uwbR6kmxOJ3MFNFnUizGlhiRA1_gFdt05Py7yMgFO_kSu1zhVc1j5xIkDt5Y8OgSbiwXp8GB-1A";

//     public IEnumerator UpdateTwinProperties(float temperature, float humidity, float diseaseProbability, bool diseaseDetected)
//     {
//         using (HttpClient client = new HttpClient())
//         {
//             client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
//             string patchJson = $@"
//             [
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/temperature"",
//                     ""value"": {temperature.ToString("F2", CultureInfo.InvariantCulture)}
//                 }},
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/humidity"",
//                     ""value"": {humidity.ToString("F2", CultureInfo.InvariantCulture)}
//                 }},
//                 {{
//                     ""op"": ""replace"",
//                     ""path"": ""/diseaseProbability"",
//                     ""value"": {diseaseProbability.ToString("F2", CultureInfo.InvariantCulture)}
//                 }}
//             ]";
//             var content = new StringContent(patchJson, Encoding.UTF8, "application/json-patch+json");

//             HttpResponseMessage response = null;

//             try
//             {
//                 response = client.PatchAsync(twinUrl, content).Result;

//                 if (response.IsSuccessStatusCode)
//                 {
//                     Debug.Log("Twin updated successfully!");
//                 }
//                 else
//                 {
//                     Debug.LogError($"Failed to update twin: {(int)response.StatusCode} {response.ReasonPhrase}");
//                     string errorContent = response.Content.ReadAsStringAsync().Result;
//                     Debug.LogError(errorContent);
//                 }
//             }
//             catch (System.Exception ex)
//             {
//                 Debug.LogError($"Exception while updating twin: {ex.Message}");
//             }
//         }

//         yield return null;
//     }
// }


using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UnityEngine;
using System.Globalization;

public class TwinUpdater : MonoBehaviour
{
    [Header("Azure Digital Twins")]
    [Tooltip("Base URL up to /digitaltwins/")]
    string baseTwinUrl = "https://temperature-humidity.api.sea.digitaltwins.azure.net/digitaltwins/";

    [TextArea(6, 10)]
    string bearerToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSIsImtpZCI6IkNOdjBPSTNSd3FsSEZFVm5hb01Bc2hDSDJYRSJ9.eyJhdWQiOiJodHRwczovL2RpZ2l0YWx0d2lucy5henVyZS5uZXQiLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9iNWEwYTlkOC03YmFkLTQ5YjktYjg0Ni0xOGZhNGMzMzY0YTMvIiwiaWF0IjoxNzQ2MzYwNzQyLCJuYmYiOjE3NDYzNjA3NDIsImV4cCI6MTc0NjM2NTYwMywiYWNyIjoiMSIsImFpbyI6IkFaUUFhLzhaQUFBQWg1Tm5ZL1hDbXJqTCtTQ0prdXJybEhxdXIrWkt6SWthOXpTbWw3bXVUUVpkdThtTzV5SCs5MHRnQmIvb05VM0ZVamNaTmF3MnQ5TnphNlRCWm5CaVZEQy9SanFIWnRYNW42ZElnVjBQMXd4WUlLVzgzenpPNFllTzNYRzdXZTk1dnNKR0pjcGhhRzQ3bnBBZ3JmWXhUR3lyb3RKUUVVdENTM21UU2FwSEFqeUJ6SGp5MVZJV3IxcHY3TEUwL2wrcyIsImFsdHNlY2lkIjoiMTpsaXZlLmNvbTowMDAzQkZGRDRFMzdFQTJFIiwiYW1yIjpbInB3ZCIsIm1mYSJdLCJhcHBpZCI6ImI2NzdjMjkwLWNmNGItNGE4ZS1hNjBlLTkxYmE2NTBhNGFiZSIsImFwcGlkYWNyIjoiMCIsImVtYWlsIjoiaXJvb2Zyb3lhbEBnbWFpbC5jb20iLCJmYW1pbHlfbmFtZSI6IlBlcnZleiIsImdpdmVuX25hbWUiOiJJcXJhIiwiaWRwIjoibGl2ZS5jb20iLCJpZHR5cCI6InVzZXIiLCJpcGFkZHIiOiIxODIuMTc3LjEyNS4yNyIsIm5hbWUiOiJJcXJhIFBlcnZleiIsIm9pZCI6IjJkZTY4YzM4LWYyMWMtNDQzNi1hZTBhLWQ1NzcyYjc0MGE1MCIsInB1aWQiOiIxMDAzMjAwNDg1RTBBNDg0IiwicmgiOiIxLkFVOEEyS21ndGExN3VVbTRSaGo2VEROa295bjBCd3RMbnhSSGs1TE1YbzZBeUxBNUFVRlBBQS4iLCJzY3AiOiJ1c2VyX2ltcGVyc29uYXRpb24iLCJzaWQiOiIwMDQxNTZhOS1kOGZiLTBmMzYtODRhOC00MGRmYTRkOTk4OGQiLCJzdWIiOiJkczFWNXc2Y3ROc1pqdHZZczBYSVlDR1hja05pTTlPeUZ4c05jUnRabGxrIiwidGlkIjoiYjVhMGE5ZDgtN2JhZC00OWI5LWI4NDYtMThmYTRjMzM2NGEzIiwidW5pcXVlX25hbWUiOiJsaXZlLmNvbSNpcm9vZnJveWFsQGdtYWlsLmNvbSIsInV0aSI6IktlcnhEdGlfS0V5N0std3NOMjRyQUEiLCJ2ZXIiOiIxLjAiLCJ4bXNfaWRyZWwiOiIyNCAxIn0.QaJC4LsdlZk5rJo8TLzEjHoWiUjN-WCnolTk5-mHtNHz_v_-E53asoX7JVaOOLkEAyD5fCgCBsf549kghFKb3plcY4e38AKyzCgfs_MDPksqIwSDrCs4N8mqNWuH0Ht95DNo0bNDooFRres0I3310NqVzSY8igLDA3-Mig77JsK39xfielAEfJHRwYNv5Yl0JCZ2jhZQiCRB1_hzLXHMs9f2rb7XQp4VAeR1NzOqEcK226Z-8LRi38yrl64_bMXZ0WvZrLfRO-80SCW160A7jqKFnHZu2IoNkBlPA3RUOuut8heKLUg1l_lTsv3xSyCEpOOAiK04cu9KjU8RrP32GQ";

    /// <summary>
    /// Called by any plant to update its specific digital twin.
    /// </summary>
    public void UpdateTwin(string twinId, float temperature, float humidity, float diseaseProbability, bool diseaseDetected)
    {
        string fullTwinUrl = $"{baseTwinUrl}{twinId}?api-version=2023-10-31";
        StartCoroutine(UpdateTwinProperties(fullTwinUrl, temperature, humidity, diseaseProbability, diseaseDetected));
    }

    private IEnumerator UpdateTwinProperties(string twinUrl, float temperature, float humidity, float diseaseProbability, bool diseaseDetected)
    {
        using (HttpClient client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            string patchJson = $@"
            [
                {{
                    ""op"": ""replace"",
                    ""path"": ""/temperature"",
                    ""value"": {temperature.ToString("F2", CultureInfo.InvariantCulture)}
                }},
                {{
                    ""op"": ""replace"",
                    ""path"": ""/humidity"",
                    ""value"": {humidity.ToString("F2", CultureInfo.InvariantCulture)}
                }},
                {{
                    ""op"": ""replace"",
                    ""path"": ""/diseaseProbability"",
                    ""value"": {diseaseProbability.ToString("F2", CultureInfo.InvariantCulture)}
                }}
            ]";

            var content = new StringContent(patchJson, Encoding.UTF8, "application/json-patch+json");

            HttpResponseMessage response = null;

            try
            {
                response = client.PatchAsync(twinUrl, content).Result;

                if (response.IsSuccessStatusCode)
                {
                    Debug.Log($"Twin updated successfully: {twinUrl}");
                }
                else
                {
                    Debug.LogError($"Twin update failed: {(int)response.StatusCode} {response.ReasonPhrase}");
                    string errorContent = response.Content.ReadAsStringAsync().Result;
                    Debug.LogError(errorContent);
                }
            }
            catch (System.Exception ex)
            {
                Debug.LogError($"Exception while updating twin: {ex.Message}");
            }
        }

        yield return null;
    }
}
