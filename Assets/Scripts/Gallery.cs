using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Gallery : MonoBehaviour
{
    private List<Texture> _textures = new List<Texture>();
    private int _requestNumber;

    private void Awake()
    {
        _textures = LoadGallery.Instance.TextureList;
        Screen.orientation = ScreenOrientation.Portrait;

    }

    public void RequireImages(ImageCell first, ImageCell second)
    {
        int firstNumber = _requestNumber * 2;
        int secondNumber = firstNumber + 1;
        Debug.Log(firstNumber+" "+ secondNumber);
        if (secondNumber< _textures.Count) {
            first.SetImage(_textures[firstNumber]);
            second.SetImage(_textures[secondNumber]);
         //   _textures.RemoveAt(secondNumber);
        }
        else
        {
            StartCoroutine(DownloadImage("http://data.ikppbb.com/test-task-unity-data/pics/" + (firstNumber+1) + ".jpg", first));
            StartCoroutine(DownloadImage("http://data.ikppbb.com/test-task-unity-data/pics/" + (secondNumber+1) + ".jpg", second));
        }
        _requestNumber++;
    }

    private IEnumerator DownloadImage(string MediaUrl, ImageCell image)
    {
        Debug.Log(MediaUrl);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            image.SetImage(((DownloadHandlerTexture)request.downloadHandler).texture);
        }
    }
}
