using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public GameObject[] Nodes;
	public bool hasTarget = false;
	public GameObject currentNode;
	public GameObject targetNode;
	public GameObject lastNode;
	public GameObject lastTargetNode;
	float lowestDistance = 2000;

	// Use this for initialization
	void Start ()
	{
		Nodes = GameObject.FindGameObjectsWithTag ("Node");
		currentNode = Nodes [5];
		gameObject.transform.position = currentNode.transform.position;
		targetNode = currentNode;
		lastNode = currentNode;
	}
	
	// Update is called once per frame
	void Update () {
		if (!hasTarget) {
			int targetNodeIndex = 0, currentNodeIndex = 0;
			//While the target is the last visited node
			while (targetNode == lastNode)
			{
				//look at all nodes
				foreach(GameObject node in Nodes)
				{
					//if last node
					if(node == lastNode)
						continue;

					//if same node
					if(node == currentNode)
						continue;

					//Check the distance to this node
					//if it is smaller than the last checked node
					//make this the target node
					if(Vector3.Distance(node.transform.position, currentNode.transform.position) < lowestDistance)
					{
						//Set the target node
						lowestDistance = Vector3.Distance(node.transform.position, currentNode.transform.position);
						targetNode = node;
					}
				}
			}
			lastNode = currentNode;
			hasTarget = true;
		}
		else
		{
			Vector3 v = Vector3.zero;
			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, targetNode.transform.position, 0.1f);
			if(gameObject.transform.position == targetNode.transform.position)
			{
				hasTarget = false;
				currentNode = targetNode;
				targetNode = lastNode;
				lowestDistance = 2000;
			}
		}
	
	}
}
