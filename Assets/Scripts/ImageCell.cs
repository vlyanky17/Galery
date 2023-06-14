using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageCell : MonoBehaviour
{
    [SerializeField] private RawImage _image;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private Button _button;

    public void SetImage(Texture texture)
    {
        _text.gameObject.SetActive(false);
        _image.texture= texture;
        _button.onClick.AddListener(() =>LoadLook(texture));
    }

    private void LoadLook(Texture texture)
    {
        LoadGallery.Instance.TextureToLook = texture;
        SceneManager.LoadScene(2);
    }


    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }
}
