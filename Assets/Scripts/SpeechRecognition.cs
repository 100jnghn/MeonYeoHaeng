using Microsoft.CognitiveServices.Speech;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    private string speechKey = "39cf770484cc49a88518708648e11238";
    private string serviceRegion = "koreacentral";

    private async void Start()
    {
        await RecognizeSpeechAsync();
    }

    private async Task RecognizeSpeechAsync()
    {
        var config = SpeechConfig.FromSubscription(speechKey, serviceRegion);
        using (var recognizer = new SpeechRecognizer(config))
        {
            while (true) 
            {
                var result = await recognizer.RecognizeOnceAsync();

                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    UnityEngine.Debug.Log($"음성인식 결과: {result.Text}");
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    UnityEngine.Debug.Log($"인식불가");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    UnityEngine.Debug.Log($"취소 => {cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        UnityEngine.Debug.Log($"취소: ErrorCode={cancellation.ErrorCode}");
                        UnityEngine.Debug.Log($"취소: ErrorDetails={cancellation.ErrorDetails}");
                        UnityEngine.Debug.Log($"취소: 구독정보 갱신");
                    }
                }
            }
        }
    }

    
}
