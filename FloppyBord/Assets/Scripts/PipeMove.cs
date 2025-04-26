using UnityEngine;

public class PipeMove : MonoBehaviour
{
    public float speed = 5f;
    // public = customize in editor
    private float leftEdge;

    // world space position vs screen space position
    private void Start() {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f;
    }

    private void Update() {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
