using UnityEngine;
using TMPro;

public class GameBehavior : MonoBehaviour
{
    public static GameBehavior Instance;

    public Utilities.GameplayState State;
    [SerializeField] private TextMeshProUGUI _pauseMessage;
    
    private int _score;
    public int Score
    {
        // Getter property
        get => _score;
        
        // Setter property
        set
        {
            _score = value;
            _scoreUI.text = Score.ToString();
        }
    }

    [SerializeField] private TextMeshProUGUI _scoreUI;
    
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            // If a different instance already exists,
            // please destroy the instance that is currently being created.
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        State = Utilities.GameplayState.Play;
        _pauseMessage.enabled = false;
    }
    
    public void ScorePoint()
    {
       Score++;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            State = State == Utilities.GameplayState.Play
                ? Utilities.GameplayState.Pause
                : Utilities.GameplayState.Play;

            _pauseMessage.enabled = !_pauseMessage.enabled;
        }
    }
}
