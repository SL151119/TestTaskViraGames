using UnityEngine;
using UnityEngine.UI;

public class ChangeLight : MonoBehaviour
{
    [Header("Background Sprite")]
    [SerializeField] private SpriteRenderer background;

    [Header("Light On/Off ")]
    public bool isLight;

    private Color _lightColor;
    private Color _darkColor;


    private void Start()
    {
        _lightColor = new Color (1f, 1f, 1f, 1f);
        _darkColor = new Color(0.27f, 0.27f, 0.34f, 0.8f);
        isLight = true;
        background = GetComponent<SpriteRenderer>();
    }
    public void Change()
    {
        if (isLight)
        {
            background.color = _darkColor;
            isLight = false;
        }
        else
        {
            background.color = _lightColor;
            isLight = true;
        }
    }
}
