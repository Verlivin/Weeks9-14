using UnityEngine;
using UnityEngine.InputSystem;

public class barrel : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movement;
    public AudioSource SFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newRoatation = transform.eulerAngles;
        newRoatation.z += movement.x * speed * Time.deltaTime;
        transform.eulerAngles = newRoatation;
        //transform.position += (Vector3)movement * speed * Time.deltaTime;
    }

    public void OnPoint(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        Debug.Log("Attack! " + context.phase);
        if (context.performed == true)
        {
            SFX.Play();
        }
    }
}
