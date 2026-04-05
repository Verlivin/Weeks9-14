using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Knight : MonoBehaviour
{
    public AudioSource SFX;
	public AudioSource SFX2;
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
    public GameObject[] keyShow;
    public Vector3 letterSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        letterSpawn = new Vector3(-9, 0, 0);
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
		SFX2.Play();
		CheckKeys();
    }
    public void CheckKeys(){
		Vector2 pos = transform.position;
        
        for (int i = 0; i < Keys.Length; i++) {
        Vector2 keyPos = Keys[i].transform.position;

            if (pos.x >= keyPos.x - keyRange && pos.x <= keyPos.x + keyRange && pos.y >= keyPos.y - keyRange && pos.y <= keyPos.y + keyRange)
            {
				//this is true coding
				if (i == 0) 
                {
                    Debug.Log("1");
                    if (letterSpawn.x >= 5)
                    {
                        letterSpawn.x = -8;
                        letterSpawn.y -= 1;
                    }
                    else
                    {
                        letterSpawn.x += 1;
                    }
				    Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 1)
				{
					Debug.Log("2");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 2)
				{
					Debug.Log("3");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 3)
				{
					Debug.Log("4");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 4)
				{
					Debug.Log("5");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 5)
				{
					Debug.Log("6");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 6)
				{
					Debug.Log("7");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 7)
				{
					Debug.Log("8");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 8)
				{
					Debug.Log("9");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 9)
				{
					Debug.Log("0");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}

				//Q -> M
				else if (i == 10)
				{
					Debug.Log("Q");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 11)
				{
					Debug.Log("W");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 12)
				{
					Debug.Log("E");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 13)
				{
					Debug.Log("R");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 14)
				{
					Debug.Log("T");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 15)
				{
					Debug.Log("Y");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 16)
				{
					Debug.Log("U");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 17)
				{
					Debug.Log("I");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 18)
				{
					Debug.Log("O");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 19)
				{
					Debug.Log("P");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}

				else if (i == 20)
				{
					Debug.Log("A");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 21)
				{
					Debug.Log("S");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 22)
				{
					Debug.Log("D");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 23)
				{
					Debug.Log("F");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 24)
				{
					Debug.Log("G");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 25)
				{
					Debug.Log("H");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 26)
				{
					Debug.Log("J");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 27)
				{
					Debug.Log("K");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 28)
				{
					Debug.Log("L");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}

				else if (i == 29)
				{
					Debug.Log("Z");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 30)
				{
					Debug.Log("X");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 31)
				{
					Debug.Log("C");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 32)
				{
					Debug.Log("V");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 33)
				{
					Debug.Log("B");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 34)
				{
					Debug.Log("N");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}
				else if (i == 35)
				{
					Debug.Log("M");
					if (letterSpawn.x >= 5)
					{
						letterSpawn.x = -8;
						letterSpawn.y -= 1;
					}
					else
					{
						letterSpawn.x += 1;
					}
					Instantiate(keyShow[i], letterSpawn, transform.rotation);
				}

			}
        }
	}
    }

