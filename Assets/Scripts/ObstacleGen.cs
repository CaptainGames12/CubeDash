
using UnityEngine;
public class ObstacleGen : MonoBehaviour
{
    [SerializeField] private GameObject _obstaclePrefab;
    [SerializeField] private Transform player;
    public float spawnFrequency;
    public Vector3 obstGenOffset;
    private float _lastUpdate;
    void Start()
    {
        _lastUpdate = Time.time;
    }
    void FixedUpdate()
    {
        float obstGenZ = player.position.z + obstGenOffset.z;
        Vector3 newGenPosition = new(0, 1, obstGenZ);
        transform.position = newGenPosition;
        if (Time.time - _lastUpdate >= spawnFrequency)
        {
            _lastUpdate = Time.time;
            
            for (int i = -18; i <= 8; i += 3)
            {
                float isSpawned = Random.Range(0, 2);
                if (isSpawned == 1)
                {
                    Vector3 position = new(i, transform.position.y, transform.position.z);
                    GameObject _instance = Instantiate(_obstaclePrefab);
                    _instance.transform.position = position;
                    
                }
                
            }
        }
    }
}
