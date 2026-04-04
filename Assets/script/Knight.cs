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
    public GameObject[] Keys; //All the keys
    public float keyRange; //player don't have step perfectly on the keys
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
        CheckKeys();
    }
    public void CheckKeys(){
		Vector2 pos = transform.position;
        
        for (int i = 0; i < Keys.Length; i++) {
        Vector2 keyPos = Keys[i].transform.position;

            if (pos.x >= keyPos.x - keyRange && pos.x <= keyPos.x + keyRange && pos.y >= keyPos.y - keyRange && pos.y <= keyPos.y + keyRange)
            {
				//this is true coding
				if (i == 0) { Debug.Log("1"); }
				else if (i == 1) { Debug.Log("2"); }
				else if (i == 2) { Debug.Log("3"); }
				else if (i == 3) { Debug.Log("4"); }
				else if (i == 4) { Debug.Log("5"); }
				else if (i == 5) { Debug.Log("6"); }
				else if (i == 6) { Debug.Log("7"); }
				else if (i == 7) { Debug.Log("8"); }
				else if (i == 8) { Debug.Log("9"); }
				else if (i == 9) { Debug.Log("0"); }

				//Q -> M
				else if (i == 10) { Debug.Log("Q"); }
				else if (i == 11) { Debug.Log("W"); }
				else if (i == 12) { Debug.Log("E"); }
				else if (i == 13) { Debug.Log("R"); }
				else if (i == 14) { Debug.Log("T"); }
				else if (i == 15) { Debug.Log("Y"); }
				else if (i == 16) { Debug.Log("U"); }
				else if (i == 17) { Debug.Log("I"); }
				else if (i == 18) { Debug.Log("O"); }
				else if (i == 19) { Debug.Log("P"); }

				else if (i == 20) { Debug.Log("A"); }
				else if (i == 21) { Debug.Log("S"); }
				else if (i == 22) { Debug.Log("D"); }
				else if (i == 23) { Debug.Log("F"); }
				else if (i == 24) { Debug.Log("G"); }
				else if (i == 25) { Debug.Log("H"); }
				else if (i == 26) { Debug.Log("J"); }
				else if (i == 27) { Debug.Log("K"); }
				else if (i == 28) { Debug.Log("L"); }

				else if (i == 29) { Debug.Log("Z"); }
				else if (i == 30) { Debug.Log("X"); }
				else if (i == 31) { Debug.Log("C"); }
				else if (i == 32) { Debug.Log("V"); }
				else if (i == 33) { Debug.Log("B"); }
				else if (i == 34) { Debug.Log("N"); }
				else if (i == 35) { Debug.Log("M"); }

			}
        }
	}
    }

