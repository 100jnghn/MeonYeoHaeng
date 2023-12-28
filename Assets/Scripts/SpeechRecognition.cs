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
                    UnityEngine.Debug.Log($"�����ν� ���: {result.Text}");

                    doAction(result.Text);
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

    // �νĵ� ������ ���� �ൿ
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
