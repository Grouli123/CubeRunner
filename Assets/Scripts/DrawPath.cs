using UnityEngine;
using System.Collections.Generic;

public class DrawPath : MonoBehaviour {

	public UnityEngine.AI.NavMeshAgent _agent;

	public GameObject _point; 
	public GameObject _line; 

	public float distance = 1; 
	public float height = 0.01f; 

	private List<GameObject> _points;
	private Vector3 _agentPoint;
	private Vector3 _lastPoint;
	private List<GameObject> _lines;

	private void Awake () 
	{
		_points = new List<GameObject>();
		_lines = new List<GameObject>();
		UpdatePath();
	}

	private void ClearArray() 
	{
		foreach(GameObject obj in _points)
		{
			Destroy(obj);
		}
		foreach(GameObject obj in _lines)
		{
			Destroy(obj);
		}
		_lines = new List<GameObject>();
		_points = new List<GameObject>();
	}

	private bool IsDistance(Vector3 distancePoint) 
	{
		bool result = false;
		float dis = Vector3.Distance(_lastPoint, distancePoint);
		if(dis > distance) result = true;
		_lastPoint = distancePoint;
		return result;
	}

	private void UpdatePath() 
	{
		_lastPoint = _agent.transform.position + Vector3.forward * 100f; 

		ClearArray();

		for(int j = 0; j < _agent.path.corners.Length; j++)
		{
			if(IsDistance(_agent.path.corners[j]))
			{
				GameObject p = Instantiate(_point) as GameObject;
				p.transform.position = _agent.path.corners[j] + Vector3.up * height; 
				_points.Add(p);
			}
		}

		for(int j = 0; j < _points.Count; j++)
		{
			if(j + 1 < _points.Count)
			{
				Vector3 center = (_points[j].transform.position + _points[j+1].transform.position) / 2; 
				Vector3 vec = _points[j].transform.position - _points[j+1].transform.position; 
				float dis = Vector3.Distance(_points[j].transform.position, _points[j+1].transform.position);

				GameObject p = Instantiate(_line) as GameObject;
				p.transform.position = center - Vector3.up * height;
				p.transform.rotation = Quaternion.FromToRotation(Vector3.right, vec.normalized); 
				p.transform.localScale = new Vector3(dis, 1, 1); 
				_lines.Add(p);
			}
		}
	}

	private void Update () 
	{
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		
		if (Physics.Raycast(ray, out hit))
		{
			if(Input.GetMouseButtonDown(0))
			{
				_agent.SetDestination(hit.point); 
			}
		}

		if(_agentPoint != _agent.path.corners[_agent.path.corners.Length-1]) UpdatePath(); 
		_agentPoint = _agent.path.corners[_agent.path.corners.Length-1];

		if(_agent.path.corners.Length == 1 && _points.Count > 1) UpdatePath(); 
	}
}