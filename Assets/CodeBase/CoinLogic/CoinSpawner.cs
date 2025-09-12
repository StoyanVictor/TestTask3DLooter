using AxGrid.Base;
using UnityEngine;
public class CoinSpawner : MonoBehaviourExt
{
    [Header("Spawn propertyes")]
    [SerializeField] private Transform gameField;
    [SerializeField] private CoinPool pool;
    [Header("Spawn Data")]
    [SerializeField] private int initialCount;
    [SerializeField] private int currentSpawnStep;
    public int CountToSpawn;
    [Space]
    public AnimationCurve spawnProgression; 
    private Bounds bounds;
    

    [OnAwake]
    public void GetMeshRendererBounds()
    {
        Renderer renderer = gameField.GetComponent<Renderer>();
        bounds = renderer.bounds;
    }
    [OnStart]
    public void SpawnInitalCoins()
    {
        for (int i = 0; i < initialCount; i++)
        {
            pool.GetCoin(GetRandomPointInBounds(bounds), GetRandomYRotation());
        }
        CountToSpawn =(int)spawnProgression.Evaluate(currentSpawnStep);
        currentSpawnStep++;
    }

    [OnRefresh(10)]
    public void SpawnNewCoins()
    {
        int targetCount = Mathf.RoundToInt(spawnProgression.Evaluate(currentSpawnStep));

        bool canSpawn = pool.GetActiveCoinsCount + targetCount < pool.GetPoolCount;
        
        if (canSpawn)
        {
            for (int i = 0; i < targetCount; i++)
            {
                pool.GetCoin(GetRandomPointInBounds(bounds), GetRandomYRotation());
            }
        }
        else if(pool.GetActiveCoinsCount < pool.GetPoolCount)
        {
            for (int i = 0; i < pool.GetPoolCount - pool.GetActiveCoinsCount; i++)
            {
                pool.GetCoin(GetRandomPointInBounds(bounds), GetRandomYRotation());

            }
        }
        else
        {
            Debug.Log("To many coins!!!");
        }

        currentSpawnStep++;
        CountToSpawn = targetCount;
    }

    private Vector3 GetRandomPointInBounds(Bounds bounds)
    {
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float z = Random.Range(bounds.min.z, bounds.max.z);
        float y = bounds.max.y + 0.5f; // чуть выше поверхности
        return new Vector3(x, y, z);
    }
  
    private Quaternion GetRandomYRotation()
    {
        float y = Random.Range(0f, 360f);
        return Quaternion.Euler(0f, y, 0f);
    }


}