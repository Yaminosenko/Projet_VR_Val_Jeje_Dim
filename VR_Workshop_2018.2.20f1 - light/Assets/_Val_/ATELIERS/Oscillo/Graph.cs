using UnityEngine;

public class Graph : MonoBehaviour {

	public Transform pointPrefab;

	[Range(10, 1000)]
	public int resolution = 10;

	Transform[] points;

    public float step = 0.02f;
    public Vector3 scale;
    public float offsetX = 1f;

    void Awake () {
		//step = 2f / resolution;
		//scale = Vector3.one * step;
		Vector3 position;
		position.y = 0f;
		position.z = 0f;
		points = new Transform[resolution];
		for (int i = 0; i < points.Length; i++) {
			Transform point = Instantiate(pointPrefab);
			position.x = (i + 0.5f) * step - 1f;
			point.localPosition = position;
			point.localScale = scale;
			point.SetParent(transform, false);
			points[i] = point;
		}
	}

	void Update () {
		for (int i = 0; i < points.Length; i++) {
			Transform point = points[i];
			Vector3 position = point.localPosition;
			position.y = Mathf.Sin(Mathf.PI * offsetX * (position.x + Time.time));
			point.localPosition = position;
		}
	}
}