using Microsoft.CognitiveServices.Speech;
using System.Diagnostics;
using System.Threading.Tasks;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    private string speechKey = "39cf770484cc49a88518708648e11238";
    private string serviceRegion = "koreacentral";

    public Animator animator;

    private async void Start()
    {
        await RecognizeSpeechAsync();

        animator = GetComponent<Animator>();
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

                    doAction(result.Text);
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

    // 인식된 음성에 따른 행동
    public void doAction(string msg)
    {
        switch(msg)
        {
            case "Sit.":
                UnityEngine.Debug.Log("Action : Sit");
                animator.SetTrigger("doSit");
                break;

            case "Eat.":
                UnityEngine.Debug.Log("Action : Eat");
                animator.SetTrigger("doEat");
                break;

            case "Turn.":
                UnityEngine.Debug.Log("Action : Turn");
                animator.SetTrigger("doTurn");
                break;
        }
    }

    
}
