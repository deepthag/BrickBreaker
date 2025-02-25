using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float YSpeed = 3.0f;
    private int _yDir;
    private float YLimit = 4.2f;
    private float XSpeed = 1.0f;
    private int _xDir;
    private float XLimit = 9.8f;
    
    private AudioSource _source;
    [SerializeField] private AudioClip _wallHit;
    [SerializeField] private AudioClip _paddleHit;
    
    void Start()
    {

        // set _yDir negative so ball falls down;
        _yDir = -1;
        _xDir = 1;
        
        _source = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= YLimit)  
        {
            _yDir *= -1;  
            _source.clip = _wallHit;
            _source.Play();
        }

        if (Mathf.Abs(transform.position.x) >= XLimit) 
        {
            _xDir *= -1;
            _source.clip = _wallHit;
            _source.Play();
        }
        
        transform.position += new Vector3 (XSpeed * _xDir, YSpeed * _yDir, 0) * Time.deltaTime;
    }
    
    private void OnCollisionEnter2D(Collision2D other) // if using box collider 2D, use 2D notification
    {
        if (other.gameObject.CompareTag("Paddle"))
        {
            _yDir *= -1;
            _source.clip = _paddleHit;
            _source.Play();
        }
        
        if (other.gameObject.CompareTag("Boundary X"))
        {
            _xDir *= -1;
        }
        
        if (other.gameObject.CompareTag("Boundary Y"))
        {
            _yDir *= -1;
        }
    }
}