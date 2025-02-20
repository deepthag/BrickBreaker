using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float YSpeed = 3.0f;
    private int _yDir;
    private float YLimit = 4.2f;
    private float XSpeed = 1.0f;
    private int _xDir;
    private float XLimit = 9.8f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // set _yDir negative so ball falls down;
        _yDir = -1;
        _xDir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= YLimit || transform.position.y <= -YLimit) 
        {
            _yDir *= -1;  
        }

        if (transform.position.x >= XLimit || transform.position.x <= -XLimit)
        {
            _xDir *= -1;
        }
        
        transform.position += new Vector3 (XSpeed * _xDir, YSpeed * _yDir, 0) * Time.deltaTime;
    }
}