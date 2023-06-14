using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class LoadGallery : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Slider _slider;
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private TextMeshProUGUI _percents;

    public int LoadCount;
    public List<Texture> TextureList {  get; private set; }
    private bool _loadError;

    public static LoadGallery Instance;
    public Texture TextureToLook;

    private void Awake()
    {
        Instance = this;
        Screen.orientation = ScreenOrientation.Portrait;
        TextureList = new List<Texture>();
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(() => StartCoroutine(Load()));
    }

    private IEnumerator Load()
    {
        _loadScreen.SetActive(true);
        float percent = 0;
        for (int i = 0; i < LoadCount; i++)
        {
            yield return StartCoroutine(DownloadImage("http://data.ikppbb.com/test-task-unity-data/pics/"+(i+1)+".jpg"));
            percent = (float)(i + 1) / (float)LoadCount;
            _percents.text = ((int)(percent * 100)).ToString()+" %";
            _slider.value = percent;
        }
        if (!_loadError)
        {
            SceneManager.LoadScene(1);
        }
    }

    private IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
            _loadError = true;
        }
        else
        {
            TextureList.Add(((DownloadHandlerTexture)request.downloadHandler).texture);
        }
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
