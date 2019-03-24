using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int playerNumber;
    [SerializeField] public float moveSpeed = 5f;
    //public float distance = 0f;  
    public KeyCode left;
    public KeyCode right;
    public KeyCode up;
    public KeyCode down;
    public GameObject gameObejct;
    public SpriteRenderer sprr;
    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    public float pausedMovementDuration = 2.5f;
    public float pausedMovementTimer = 0f;
    public TextMesh pausedMovementMesh;

    private Vector2 moveDirection = Vector2.up;
    private string ps_horizontal;
    private string ps_vertical;
    private string ps_horizontal_stick;
    private string ps_vertical_stick;

    // Start is called before the first frame update
    void Start()
    {
        if (playerNumber == 1)
        {
            ps_horizontal = "PS4_1_Horizontal_arrows";
            ps_vertical = "PS4_1_Vertical_arrows";
            ps_horizontal_stick = "PS4_1_Horizontal_stick";
            ps_vertical_stick = "PS4_1_Vertical_stick";
        } else
        {
            ps_horizontal = "PS4_2_Horizontal_arrows";
            ps_vertical = "PS4_2_Vertical_arrows";
            ps_horizontal_stick = "PS4_2_Horizontal_stick";
            ps_vertical_stick = "PS4_2_Vertical_stick";
        }

        PauseMovement();
    }

    // Update is called once per frame
    void Update()
    {
        if (pausedMovementTimer > 0)
        {
            pausedMovementTimer -= Time.deltaTime;
            pausedMovementMesh.text = ((int)(pausedMovementTimer + 1f)).ToString();
        }
        else
        {
            pausedMovementMesh.text = "";
        }

        movement();
        UpdateSprite();
    }

    void movement()
    {
        Vector2 dir = MovementDirection();

        if (dir != Vector2.zero && (-dir != moveDirection || pausedMovementTimer > 0))
        {
            moveDirection = dir;
        }

        if (pausedMovementTimer <= 0)
        {
            transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
        }
    }

    private int b2i(bool b)
    {
        return b ? 1 : 0;
    }

    Vector2 MovementDirection()
    {
        float ps_x = Input.GetAxis(ps_horizontal) + Input.GetAxis(ps_horizontal_stick);
        float ps_y = Input.GetAxis(ps_vertical) + Input.GetAxis(ps_vertical_stick);

        Vector2 direction = new Vector2(
            ps_x + b2i(Input.GetKey(right)) - b2i(Input.GetKey(left)),
            ps_y + b2i(Input.GetKey(up)) - b2i(Input.GetKey(down))
        );

        if (direction == Vector2.zero) return direction;

        // Return cardinal vector
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            return new Vector2(Mathf.Sign(direction.x), 0);
        }
        else
        {
            return new Vector2(0, Mathf.Sign(direction.y));
        }
    }

    public void PauseMovement()
    {
        pausedMovementTimer = pausedMovementDuration;
    }

    public void UpdateSprite()
    {
        Sprite spr = sprr.sprite;

        if (moveDirection == Vector2.up) spr = upSprite;
        else if (moveDirection == Vector2.down) spr = downSprite;
        else if (moveDirection == Vector2.right) spr = rightSprite;
        else if (moveDirection == Vector2.left) spr = leftSprite;

        sprr.sprite = spr;
    }
}
