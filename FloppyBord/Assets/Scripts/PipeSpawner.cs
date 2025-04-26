using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject prefabPipes;
    public float spawnRate = 1f;

    public float minHeight = -1f;
    public float maxHeight = 1f;

    // automatic when enable script
    private void OnEnable() {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); // calls every 1.5 seconds
    }

    // automatic when disable script
    private void OnDisable() {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn() {
        GameObject pipes = Instantiate(prefabPipes, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
