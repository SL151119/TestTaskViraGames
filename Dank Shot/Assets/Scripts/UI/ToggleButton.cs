using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    [Header("Colors")]
    [SerializeField] private Color onColor;
    [SerializeField] private Color offColor;

    [Header("Background Image")]
    [SerializeField] private Image backgroundButton;
    
    [Header("Toggle Button")]
    [SerializeField] private RectTransform circle;
    [SerializeField] private GameObject[] toogleText;

    [Header("Speed")]
    [SerializeField] private float speed;

    private Vector2 _currentPos;
    private string _saveName = "SoundOff";
    private float _posX = 65;

    private void Start()
    {
        if (PlayerPrefs.HasKey(_saveName))
        {
            _currentPos = new Vector2(-_posX, 0);
        }
        else
        {
            _currentPos = new Vector2(_posX, 0);
        }
        circle.anchoredPosition = _currentPos;
        ChangeColor();
    }

    private void Update()
    {
        if (circle.anchoredPosition != _currentPos)
        {
            circle.anchoredPosition = Vector2.Lerp(circle.anchoredPosition,
                                                   _currentPos, Time.deltaTime * speed);
        }
    }
    public void ChangePos()
    {
        if (_currentPos.x == _posX)
        {
            backgroundButton.color = offColor;
            _currentPos = new Vector2(-_posX, 0);

            toogleText[0].SetActive(false);
            toogleText[1].SetActive(true);
        }
        else
        {
            backgroundButton.color = onColor;
            _currentPos = new Vector2(_posX, 0);

            toogleText[0].SetActive(true);
            toogleText[1].SetActive(false);
        }
    }

    private void ChangeColor()
    {
        if (_currentPos.x == _posX)
        {
            backgroundButton.color = onColor;
        }
        else
        {
            backgroundButton.color = offColor;
        }
        if (PlayerPrefs.HasKey(_saveName))
        {
            toogleText[0].SetActive(false);
            toogleText[1].SetActive(true);

        }
        else
        {
            toogleText[0].SetActive(true);
            toogleText[1].SetActive(false);
        }
    }
}
