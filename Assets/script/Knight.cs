using UnityEngine;
using UnityEngine.InputSystem;

public class Knight : MonoBehaviour
{
    public AudioSource SFX;
    public float speed;
    public Vector2 movement;
    public Animator animator;
    public SpriteRenderer sr;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        else
        {
            sr.flipX = false;
        }
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
    }

