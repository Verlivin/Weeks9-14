using System.Collections;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Grower : MonoBehaviour
{
    public Transform tree;
    public Transform apple;

    Coroutine growingCoroutine;
    Coroutine treeCoroutine;
    Coroutine appleCoroutine;

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
        if (treeCoroutine != null)
        {
            StopCoroutine(treeCoroutine);
        }
        if (appleCoroutine != null)
        {
            StopCoroutine(appleCoroutine);
        }
        growingCoroutine = StartCoroutine(Growing());
    }
    IEnumerator Growing()
    {
        yield return treeCoroutine = StartCoroutine(GrowTree());
        yield return appleCoroutine = StartCoroutine(GrowApple());
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
        Debug.Log("finshed growing the apple");
        }
    IEnumerator GrowApple()
    {
        Debug.Log("Starting to grow the tree");
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
