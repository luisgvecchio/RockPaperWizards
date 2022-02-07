using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMove : MonoBehaviour
{
    public float speed;
    private float timer;
    public float magnitude;
    public Vector3 direction;
    private Vector3 startPos;
    public bool activated;
    // Start is called before the first frame update
    void Start()
    {

        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated) return;

        timer += Time.deltaTime * speed;

        this.transform.position = startPos;
        this.transform.position += direction * (Mathf.Sin(timer) * magnitude);
    }

    public void ActivateMe()
    {
        activated = true;
    }

    public void DeActivateMe()
    {
        activated = false;
    }
}
