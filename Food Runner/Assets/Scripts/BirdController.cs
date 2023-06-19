using UnityEngine;

public class BirdController : MonoBehaviour
{
    private Animator animator;
    public float flyDelay = 0.3f;
    public bool isFly;
    public Rigidbody2D rb;
    public float flyForce = 5f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // O jogador atacou o pássaro
            animator.SetBool("isHit", true);
            isFly = true;
        }
    }

    private void FixedUpdate()
    {
        if (isFly)
        {
            Invoke("FlyBird", flyDelay);
        }
    }

    private void FlyBird()
    {
        float newY = transform.position.y + (flyForce * Time.deltaTime);
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}