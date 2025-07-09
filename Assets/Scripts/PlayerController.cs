using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    
    public float jumpForce = 5;
    
    public float jumpInterval = 0.5f;
    
    private float _jumpCooldown;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update(){
        if (GameManager.Instance.IsGameOver()){
            return;
        }
        
        
        _jumpCooldown -= Time.deltaTime;
        bool canJump = _jumpCooldown <= 0f;
        if (canJump){
            bool jumpInput = Input.GetKey(KeyCode.Space);
            if (jumpInput){
                Jump();
            }
        }

        float gameHeight = GameManager.Instance.gameHeight;
        
        if (transform.position.y > gameHeight){
            transform.position = new Vector3(transform.position.x, gameHeight, transform.position.z);
        }
        
        
    }

    void OnCollisionEnter(Collision other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        OnCustomCollisionEnter(other.gameObject);
    }
    
    
    
    
    private void OnCustomCollisionEnter(GameObject other){
        if (other.CompareTag("Sensor")) {
            GameManager.Instance.score++;
            Debug.Log("Score: " + GameManager.Instance.score);
        }
        else{
            GameManager.Instance.score = 0;
            GameManager.Instance.EndGame();
            StartCoroutine(ReloadScene(2));
        }
    }


    private IEnumerator ReloadScene(float delay)
    {
        yield return new WaitForSeconds(delay);
        
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
    
    

    private void Jump() {
        _jumpCooldown = jumpInterval;
        _rb.linearVelocity = Vector3.zero;
        _rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
    }
}
