using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscilloWinCondition : MonoBehaviour {

    public GameObject greenSpline;
    Graph graph;
    public float _scaleY;
    public float _scaleX;
    //public float _offsetX;
    public float _margin = 1f;

    public bool atelierDone = false;
    public OscilloParams OP;

    // Use this for initialization
    public void Start () {
        graph = greenSpline.GetComponent<Graph>();
	}
	
	// Update is called once per frame
	public void Update () {
        Completed();
        if (atelierDone == true)
        {
            graph.offsetX = 5f;
            greenSpline.transform.localScale = new Vector3(3f, 1, 1f);
        }
	}

    /*public void Completed ()
    {
        if ((graph.offsetX < _offsetX +_margin &&
            graph.offsetX > _offsetX - _margin) &&
            (OP.OS.transform.localScale.y < _scaleY + _margin &&
            OP.OS.transform.localScale.y > _scaleY - _margin))
        {
            atelierDone = true;
            OP.isDone = true;
        }
    }*/

    public void Completed ()
    {
        if ((OP.OS.transform.localScale.x < _scaleX + _margin &&
            OP.OS.transform.localScale.x > _scaleX - _margin) &&
            (OP.OS.transform.localScale.y < _scaleY + _margin &&
            OP.OS.transform.localScale.y > _scaleY - _margin))
        {
            atelierDone = true;
            OP.isDone = true;
        }
    }
}
