using UnityEngine;
using System.Collections;

public class LineScript : MonoBehaviour
{
    public int lengthOfLineRenderer = 20;
    public int _x = 0;
    public int _y = 0;
    LineRenderer lineRenderer;

    void Start()
    {
        //LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        //lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
        //lineRenderer.SetWidth(0.2F, 0.2F);
        //lineRenderer.SetVertexCount(lengthOfLineRenderer);
        lineRenderer = GetComponent<LineRenderer>();
    }
    void Update()
    {
        int i = 0;
        while (i < lengthOfLineRenderer)
        {
            Vector3 pos = new Vector3(_y * i, Mathf.Sin(_x * i + Time.time), 0);
            lineRenderer.SetPosition(i, pos);
            i++;
        }
    }
}
