using Microsoft.CognitiveServices.Speech;
using System.Diagnostics;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SpeechRecognition : MonoBehaviour
{
    private string speechKey = "d927e5ec5f6641b5babf651e1f41355d";
    private string serviceRegion = "koreacentral";
    private bool isRecognizing;


    public GameObject DogGum;
    public GameObject clone;
    public GameObject saliva;
    Corgi corgi;

    private void Awake()
    {
        corgi = GetComponent<Corgi>();
    }

    private async void Start()
    {
        isRecognizing = true;
        await RecognizeSpeechAsync();
    }

    private async Task RecognizeSpeechAsync()
    {
        var config = SpeechConfig.FromSubscription(speechKey, serviceRegion);
        using (var recognizer = new SpeechRecognizer(config))
        {
            while (isRecognizing)
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
    private void OnDisable()
    {
        isRecognizing = false;
    }
    private void OnApplicationQuit()
    {
        isRecognizing = false;
    }

    // 인식된 음성에 따른 행동
    public void doAction(string msg)
    {
        switch (msg)
        {
            case "Sit.":
                UnityEngine.Debug.Log("Action : Sit");
                corgi.cState = Corgi.state.Sit;

                corgi.doSit();
                break;

            case "Wait.":
                UnityEngine.Debug.Log("Action : Wait");
                corgi.cState = Corgi.state.Jump;
                corgi.doJump();
                break;

            case "Good boy.":
                UnityEngine.Debug.Log("Action : Eat");
                corgi.cState = Corgi.state.Eat;
                corgi.doEat();
                saliva.SetActive(false);

                Destroy(clone);
                break;

            case "Turn around.":
                UnityEngine.Debug.Log("Action : Turn");
                corgi.cState = Corgi.state.Turn;

                corgi.doTurn();
                break;

            case "Happy.": // 이름 부름 -> 쳐다봄
                UnityEngine.Debug.Log("Action : Look");
                corgi.cState = Corgi.state.Look;

                corgi.doLook();
                break;

            case "Stand up.": // 일어나!

                UnityEngine.Debug.Log("Action : Sit UP");
                corgi.cState = Corgi.state.SitUp;

                corgi.doSitUp();
                break;

            case "Bring snack.":
                UnityEngine.Debug.Log("Create : Bone");
                UnityEngine.Debug.Log("Action : Wait");
                corgi.cState = Corgi.state.Wait;
                corgi.doWait();
                clone = Instantiate(DogGum, new Vector3(0, 0, 0), DogGum.transform.rotation);
                clone.SetActive(true);
                saliva.SetActive(true);
                break;
        }
    }


}

