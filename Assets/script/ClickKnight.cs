using TreeEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ClickKnight : MonoBehaviour
{
    public AudioSource SFX;
    public float speed;
    public Vector2 movement;
    public Animator animator;
    public SpriteRenderer sr;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    private Vector2 currentPos;
    public Vector2 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        animator.SetFloat("Speed", movement.magnitude);
        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        else if(movement.x > 0)
        {
            sr.flipX = false;
        }
        currentPos = transform.position;
        //Debug.Log(mousePos);
        if (Vector2.Distance(currentPos, mousePos) > 0.5f)
        {
            if (mousePos.x > currentPos.x)
            {
                currentPos.x += speed;
            }
            else if (mousePos.x < currentPos.x)
            {
                currentPos.x -= speed;
            }
            if (mousePos.y > currentPos.y)
            {
                currentPos.y += speed;
            }
            else if (mousePos.y < currentPos.y)
            {
                currentPos.y -= speed;
            }
        }
        transform.position = currentPos;
    }
    public void Footsteps()
    {
        //Debug.Log("step!");
        SFX.Play();
        if (movement.x < 0)
        {
            ps2.Emit(5);
        }
        else
        {
            ps.Emit(5);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
       movement = context.ReadValue<Vector2>();
    }
    public void OnClick(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Debug.Log(mousePos);
        }
    }
}


