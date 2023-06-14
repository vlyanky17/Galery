using UnityEngine;

public class ImageContainer : MonoBehaviour
{
    [SerializeField] private ImageCell _imageFirst;
    [SerializeField] private ImageCell _imageSecond;
    [SerializeField] private Gallery _gallery;

    private bool _hasImage;

    private void OnBecameVisible()
    {
        if (!_hasImage)
        {
            _gallery.RequireImages( _imageFirst, _imageSecond);
            _hasImage= true;
        }
    }
}
