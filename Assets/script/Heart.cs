using UnityEngine;

public class Heart : MonoBehaviour
{
    public float speed;
    private Vector2 pos;
    public float t;
    public AnimationCurve curve;
    public TrailRenderer tr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos.x += speed/60;
        if(pos.x > 10)
        {
            tr.Clear();
            tr.enabled = false;
            pos.x = -10;
            tr.Clear();
            tr.enabled = true;
        }
        t += Time.deltaTime;
        if (t > 1)
        {
            t = 0;
        }
        float y = curve.Evaluate(t);
        pos.y = y;
        transform.position = pos;
    }
}
