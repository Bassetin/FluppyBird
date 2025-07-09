using UnityEngine;

public class ObstacleMover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void FixedUpdate()
    {
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }
        
        float x = GameManager.Instance.obstacleSpeed * Time.fixedDeltaTime;
        transform.position -= new Vector3(x,0,0);
        
        float x1 = transform.position.x;
        if (x1 < -20)
        {
            Destroy(this.gameObject);
        }
    }
}
