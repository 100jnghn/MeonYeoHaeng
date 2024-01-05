using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
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
    public GameObject cube;

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
        var audioConfig = AudioConfig.FromDefaultMicrophoneInput();
        using (var recognizer = new SpeechRecognizer(config, audioConfig))
        {
            while (isRecognizing)
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
                    TextConfirm.instance.TextTextDebug("$UNKOWN");
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
    private void OnDisable()
    {
        isRecognizing = false;
    }
    private void OnApplicationQuit()
    {
        isRecognizing = false;
    }

    // �νĵ� ������ ���� �ൿ
    public void doAction(string msg)
    {
        switch (msg)
        {
            case "CUBE.":
                Instantiate(cube);
                break;

            case "Sit.":
                UnityEngine.Debug.Log("Action : Sit");
                TextConfirm.instance.TextTextDebug("Action : Sit");
                corgi.cState = Corgi.state.Sit;

                corgi.doSit();
                break;

            case "SIT.":
                UnityEngine.Debug.Log("Action : Sit");
                TextConfirm.instance.TextTextDebug("Action : SIT.");

                corgi.cState = Corgi.state.Sit;

                corgi.doSit();
                break;

            case "Eat.":
                UnityEngine.Debug.Log("Action : Eat");
                TextConfirm.instance.TextTextDebug("Action : Eat");

                corgi.cState = Corgi.state.Eat;
                corgi.doEat();

                Destroy(clone);
                break;

            case "EAT.":
                UnityEngine.Debug.Log("Action : Eat");
                TextConfirm.instance.TextTextDebug("Action : EAT.");

                corgi.cState = Corgi.state.Eat;
                corgi.doEat();

                Destroy(clone);
                break;

            case "Turn.":
                UnityEngine.Debug.Log("Action : Turn");
                TextConfirm.instance.TextTextDebug("Action : Turn");

                corgi.cState = Corgi.state.Turn;

                corgi.doTurn();
                break;

            case "TURN.":
                UnityEngine.Debug.Log("Action : Turn");
                TextConfirm.instance.TextTextDebug("Action : TURN.");
                corgi.cState = Corgi.state.Turn;

                corgi.doTurn();
                break;

            case "Happy.": // �̸� �θ� -> �Ĵٺ�
                /*
                UnityEngine.Debug.Log("Action : Look");
                corgi.cState = Corgi.state.Look;

                corgi.doLook();
                */
                UnityEngine.Debug.Log("Action : Appear");
                TextConfirm.instance.TextTextDebug("Action : Happy.");
                corgi.showDog();
                break;

            case "HAPPY.": // �̸� �θ� -> �Ĵٺ�
                /*
                UnityEngine.Debug.Log("Action : Look");
                corgi.cState = Corgi.state.Look;

                corgi.doLook();
                */
                UnityEngine.Debug.Log("Action : Appear");
                TextConfirm.instance.TextTextDebug("Action : HAPPY.");
                corgi.showDog();
                break;

            case "Stand up.": // �Ͼ!

                UnityEngine.Debug.Log("Action : Sit UP");
                TextConfirm.instance.TextTextDebug("Action : Sit UP.");
                corgi.cState = Corgi.state.SitUp;

                corgi.doSitUp();
                break;

            case "Bone.": // �� ����
                UnityEngine.Debug.Log("Create : Bone");
                TextConfirm.instance.TextTextDebug("Action : Bone.");
                clone = Instantiate(DogGum, new Vector3(-1, 0, 1), DogGum.transform.rotation);
                clone.SetActive(true);

                break;


            case "BONE.": // �� ����
                UnityEngine.Debug.Log("Create : Bone");
                TextConfirm.instance.TextTextDebug("Action : BONE.");
                clone = Instantiate(DogGum, new Vector3(-1, 0, 1), DogGum.transform.rotation);
                clone.SetActive(true);

                break;


            case "Phone.": // �� ����
                UnityEngine.Debug.Log("Create : Bone");
                TextConfirm.instance.TextTextDebug("Action : BONE.");
                clone = Instantiate(DogGum, new Vector3(-1, 0, 1), DogGum.transform.rotation);
                clone.SetActive(true);

                break;
        }
    }


}

