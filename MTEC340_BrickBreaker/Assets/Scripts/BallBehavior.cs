using UnityEngine;

public class BallBehavior : MonoBehaviour
{
    public float YSpeed = 3.0f;
    private int _yDir;
    public float YLimit = 5.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // set _yDir negative so ball falls down;
        _yDir = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(transform.position.y) >= YLimit) 
        {
            _yDir *= -1;  
        }
        
        transform.position += new Vector3 (0, YSpeed * _yDir, 0);
    }
}
