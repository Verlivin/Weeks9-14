using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Grower1 : MonoBehaviour
{
    public Transform tree;
    public Transform apple;

    Coroutine growingCoroutine;
    Coroutine treeCoroutine;
    Coroutine appleCoroutine;

    public Button button1;
    public Button button2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;

    }

    // Update is called once per frame
    void Update()
    { 
    }
    public void StartTreeGrowing()
    {
        if (growingCoroutine != null)
        {
            StopCoroutine(growingCoroutine);
        }
        if (appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }
        if (treeCoroutine != null)
        {
            StopCoroutine(treeCoroutine);
        }
        growingCoroutine = StartCoroutine(Growing());
    }
    IEnumerator Growing()
    {
        yield return appleCoroutine = StartCoroutine(GrowApple());
        yield return treeCoroutine = StartCoroutine(GrowTree());
        
    }
    IEnumerator GrowTree() {
        Debug.Log("Starting to grow the tree");
        float t = 0;
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            tree.localScale = Vector2.one * t;
            yield return null;
        }
        button1.interactable = true;
        button2.interactable = true;
        Debug.Log("finshed growing the apple");
        }
    IEnumerator GrowApple()
    {
        Debug.Log("Starting to grow the tree");
        button1.interactable = false;
        button2.interactable = false;
        float t = 0;
        tree.localScale = Vector2.zero;
        apple.localScale = Vector2.zero;

        while (t < 1)
        {
            t += Time.deltaTime;
            apple.localScale = Vector2.one * t;
            yield return null;
        }
        Debug.Log("finshed growing the apple");
    }
}
