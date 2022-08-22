using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Ball ball;
    [SerializeField] float pushForce = 4f;
    
    [Header("Trajectory")]
    [SerializeField] private Trajectory trajectory;

    [Header("UI")]
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject mainMenu;

    private Camera _cam;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _direction;
    private Vector2 _force;
    private Vector3 _mousePos;
    private float _distance;

    private bool isAiming = false;
    
    [HideInInspector]
    public bool isShoot = false;
    [HideInInspector]
    public bool isGameOver = false;
    [HideInInspector]
    public bool gameIsStart = false;

    private void Start()
    {
        _cam = Camera.main;
        mainMenu.SetActive(true);
        gameIsStart = false;
        _startPoint = ball.transform.position;
    }

    private void Update()
    {
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

        if (!isShoot && gameIsStart)
        {
            Aim();
        }
    }

    private void Aim()
    {
        if (Input.GetMouseButton(0))
        {
            if (Vector3.Distance(_startPoint, _mousePos) < 13f)
            {
                if (!isAiming)
                {
                    isAiming = true;
                    _startPoint = ball.transform.position;
                    CalculateTrajectory();
                    ShowTrajectory();
                }
                else
                {
                    CalculateTrajectory();
                }
            }
            else
            {
                CalculateTrajectory();
            }
        }
        else if (isAiming)
        {
            ball.Push(_force);
            isShoot = true;
            isAiming = false;
            HideTrajectory();
        }
    }
    private void ShowTrajectory()
    {
        trajectory.Show();
    }

    private void CalculateTrajectory()
    {
        var touchForce = _cam.ScreenToWorldPoint(Input.mousePosition);
        var touchForceX = Mathf.Clamp(touchForce.x, _startPoint.x + -2f, _startPoint.x + 2f);
        var touchForceY = Mathf.Clamp(touchForce.y, _startPoint.y + -5f, _startPoint.y + 5f);
        _endPoint = new Vector3(touchForceX, touchForceY, 0f);
        _distance = Vector2.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        _force = _direction * _distance * pushForce;

        trajectory.UpdateDots(ball.playerPos, _force);   
    }

   private void HideTrajectory()
    { 
        trajectory.Hide();
    }

    public void StopTimeForPause()
    {
        Time.timeScale = 0;
    }

    public void StartTime()
    {
        Time.timeScale = 1;
    }
    
    public void StartTimeWithDelay()
    {
        StartCoroutine(ResumeTime());
    }

    IEnumerator ResumeTime()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        gameIsStart = true;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        pauseButton.SetActive(false);
        isGameOver = true;
    }

}
