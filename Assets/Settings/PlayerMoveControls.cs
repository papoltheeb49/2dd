using UnityEngine;

public class PlayerMoveControls : MonoBehaviour
{
    private int direction = 1;
    public float speed = 5f;
    private GatherInput gatherInput;
    private Rigidbody2D rigidbody2D;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        gatherInput = GetComponent<GatherInput>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody2D.velocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.velocity.y);
    }
    private void FixedUpdate()
    {
        Move();
        JumpPlayer();

    }
    private void Move()
    {
        Flip();
        rigidbody2D.velocity = new Vector2(speed * gatherInput.valueX, rigidbody2D.velocity.y);
    }
    private void JumpPlayer()
    {
        if (gatherInput.jumpInput)
        {
            rigidbody2D.velocity = new Vector2(gatherInput.valueX * speed, jumpForce);
        }
        gatherInput.jumpInput = false;
    }
    private void Flip()
    {
        if (gatherInput.valueX * direction < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, 1, 1);
            direction *= -1;
        }
    }
}
