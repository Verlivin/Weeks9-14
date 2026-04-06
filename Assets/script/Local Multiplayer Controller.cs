using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.PlayerSettings;

public class LocalMultiplayerController : MonoBehaviour
{
    public Vector2 movementInput;
    public float speed = 5;
    public PlayerInput playerInput;
    public Manager manager;
    public AudioSource SFX; 
    public AnimationCurve curve;
    Coroutine AtkCoroutine;
    Coroutine DashCoroutine;
    public TrailRenderer tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movementInput * speed * Time.deltaTime;

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
    
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Player " + playerInput.playerIndex + ": Atk");
            manager.PlayerAttacking(playerInput);
            SFX.Play();

            StartCoroutine(Atk());

        }
    }
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
            {
            StartCoroutine(Dash());
            }
    }
    public void StartAtk()
    {
        if (AtkCoroutine != null)
        {
            StopCoroutine(AtkCoroutine);
        }
    }

    public void StartDash()
    {
        if (DashCoroutine != null)
        {
            StopCoroutine(DashCoroutine);
        }
    }
    IEnumerator Atking()
    {
        yield return AtkCoroutine = StartCoroutine(Atking());
    }

    IEnumerator Dashing()
    {
        yield return DashCoroutine = StartCoroutine(Dashing());
    }

    IEnumerator Atk()
    {
        float t = 0;
        Vector2 pos = transform.localScale;
        while (t<1)
        {

            t += Time.deltaTime;
            float y = curve.Evaluate(t);
            pos.y = y;
            transform.localScale = pos;
            yield return null;
        }
    }

    IEnumerator Dash()
    {

        float t = 0;
        while (t < 1)
        {

            t += Time.deltaTime;
            speed = 10;
            tr.enabled = true;
            yield return null;
        }
        speed = 5;
        tr.enabled = false;
        tr.Clear();
    }

}
