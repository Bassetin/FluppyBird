using UnityEditor;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{


    private float _cooldown;
   

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.IsGameOver())
        {
            return;
        }
        
        //Cooldown dos obstáculos
        _cooldown -= Time.deltaTime;
        if (_cooldown <= 0){
            _cooldown = GameManager.Instance.obstacleInterval;
            
            
            //Spawn obstaculos
            int prefabIndex = Random.Range(0, GameManager.Instance.obstaclePrefabs.Count);
            GameObject prefab = GameManager.Instance.obstaclePrefabs[prefabIndex];
            float x = GameManager.Instance.obstacleOffsetX;
            float y = Random.Range(GameManager.Instance.obstacleOffsetY.x, GameManager.Instance.obstacleOffsetY.y);
            float z = -0.5f;
            Vector3 position = new Vector3(x, y, z);
            Quaternion rotation = prefab.transform.rotation;
            Instantiate(prefab, position, rotation);
        }
    }
}
