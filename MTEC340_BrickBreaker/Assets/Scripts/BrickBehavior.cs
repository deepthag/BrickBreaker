using UnityEngine;

public class BrickBehavior : MonoBehaviour
{
    private AudioSource _source;
    [SerializeField] private AudioClip _brickBreak;
    void Start()
    {
        _source = GetComponent<AudioSource>();
    }
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Collision!");
            Destroy(gameObject);
            _source.clip = _brickBreak;
            _source.Play();
            GameBehavior.Instance.ScorePoint(); 
        }
    }
}
