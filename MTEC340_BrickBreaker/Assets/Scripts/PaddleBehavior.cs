using UnityEngine;

public class PaddleBehavior : MonoBehaviour
{
    public float Speed = 3.0f;

    public KeyCode RightArrow = KeyCode.RightArrow;
    public KeyCode LeftArrow = KeyCode.LeftArrow;

    public float XLimit = 8.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameBehavior.Instance.State == Utilities.GameplayState.Play)
        {
            float movement = 0; 
            if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < XLimit)
            { 
                movement += Speed;
            }
            if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -XLimit)
            {
                movement -= Speed;
            }
        
            transform.position += new Vector3(movement, 0, 0) * Time.deltaTime;
        }
    }
}
