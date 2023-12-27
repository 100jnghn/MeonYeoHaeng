using Microsoft.CognitiveServices.Speech;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    private string speechKey = "39cf770484cc49a88518708648e11238";
    private string serviceRegion = "koreacentral";

    private async void Start()
    {
        var config = SpeechConfig.FromSubscription(speechKey, serviceRegion);

        using (var recognizer = new SpeechRecognizer(config))
        {
            var result = await recognizer.RecognizeOnceAsync();

            Debug.Log(result.Text);
        }
    }
}
