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
                    UnityEngine.Debug.Log($"�����ν� ���: {result.Text}");
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    UnityEngine.Debug.Log($"�νĺҰ�");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    UnityEngine.Debug.Log($"��� => {cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        UnityEngine.Debug.Log($"���: ErrorCode={cancellation.ErrorCode}");
                        UnityEngine.Debug.Log($"���: ErrorDetails={cancellation.ErrorDetails}");
                        UnityEngine.Debug.Log($"���: �������� ����");
                    }
                }
            }
        }
    }

    
}
