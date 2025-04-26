using UnityEngine;

public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;

    public Sprite[] sprites;
    private int spriteIndex;

    // updates when object is initialized
    private void Awake() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // updates first frame when object is enabled
    private void Start() {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // calls every 1.5 seconds

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Obstacle") {
            FindObjectOfType<GameManager>().GameOver();   // not super efficient
        } else if (other.gameObject.tag == "Scoring") {
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }

    private void AnimateSprite() {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // updates every frame
    // usually put input
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            direction = Vector3.up * strength;
        }

        
        direction.y += gravity * Time.deltaTime;
        transform.position += direction * Time.deltaTime;

        // touch input
        // if (Input.touchCount > 0)
        // {
        //  Touch touch = Input.GetTouch(0);
        //  if (touch.phase == TouchPhase.Began) {
        //      direction = Vector3.up * strength; 
        //  }
        // }
        // 
    } 
}
