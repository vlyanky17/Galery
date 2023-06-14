using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LookScreen : MonoBehaviour
{
    [SerializeField] RawImage _image;
    [SerializeField] Button _button;

    private void Awake()
    {
        _image.texture = LoadGallery.Instance.TextureToLook;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Back();
        }
    }

    private void OnEnable()
    {
        _button.onClick.AddListener(Back);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
    }

    private void Back()
    {
        SceneManager.LoadScene(1);
    }
}
