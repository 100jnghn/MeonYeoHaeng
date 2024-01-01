using Microsoft.CognitiveServices.Speech;
using System.Diagnostics;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    private string speechKey = "39cf770484cc49a88518708648e11238";
    private string serviceRegion = "koreacentral";
    
    public GameObject DogGum;
    public GameObject clone;
    Corgi corgi;

    private void Awake()
    {
        corgi = GetComponent<Corgi>();
    }

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
                corgi.cState = Corgi.state.Sit;
               
                corgi.doSit();
                break;

            case "Eat.":
                UnityEngine.Debug.Log("Action : Eat");
                corgi.cState = Corgi.state.Eat;
                corgi.doEat();

                Destroy(clone);
                break;

            case "Turn.":
                UnityEngine.Debug.Log("Action : Turn");
                corgi.cState = Corgi.state.Turn;
                
                corgi.doTurn();
                break;

            case "Happy.": // �̸� �θ� -> �Ĵٺ�
                UnityEngine.Debug.Log("Action : Look");
                corgi.cState = Corgi.state.Look;
               
                corgi.doLook();
                break;

            case "Stand up.": // �Ͼ!

                UnityEngine.Debug.Log("Action : Sit UP");
                corgi.cState = Corgi.state.SitUp;

                corgi.doSitUp();
                break;

            case "Bone.": // �� ����
                UnityEngine.Debug.Log("Create : Bone");
                clone = Instantiate(DogGum, new Vector3(0, 0, 0), DogGum.transform.rotation);
                clone.SetActive(true);

                break;
        }
    }

    
}
