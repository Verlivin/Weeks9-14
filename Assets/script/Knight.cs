using System.Collections;
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
    public AnimationCurve curve;
    Coroutine jumpCoroutine;
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
        else if(movement.x > 0)
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
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            //
            StartCoroutine(Jump());
        }
    }
    public void StartJump()
    {
        if(jumpCoroutine != null)
        {
            StopCoroutine(jumpCoroutine);
        }
    }
    IEnumerator Jumping()
    {
        yield return jumpCoroutine = StartCoroutine(Jump());
    }
    IEnumerator Jump()
    {
        Debug.Log("jump");
        float t = 0;
        Vector2 pos = transform.position;
        float initialY = transform.position.y;
        animator.SetBool("jump", true);
        while (t < 1)
        {
            
            t += Time.deltaTime;
            float y = curve.Evaluate(t);
            pos.y = initialY + y;
            transform.position = pos;
            yield return null;
        }
        animator.SetBool("jump", false);
    }
    }

