﻿using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// .
/// </summary>
[RequireComponent(typeof(BoxCollider))]
public class AutoMoveTo : MonoBehaviour
{
	[SerializeField]
	private float minDelay;

	[SerializeField]
	private float maxDelay;

	[SerializeField]
	private float minMoveTime;

	[SerializeField]
	private float maxMoveTime;

	[SerializeField]
	private float minLookTime;

	[SerializeField]
	private float maxLookTime;

	[SerializeField]
	private List<string> easeTypes;

	private List<MoveTo> moveToList;

	private BoxCollider range;

	void Start()
	{
		this.range = GetComponent<BoxCollider>();
		BroadcastMessage("AttachOnCompleteTarget", gameObject);
		this.moveToList = new List<MoveTo>(GetComponentsInChildren<MoveTo>());
		foreach(var moveTo in moveToList)
		{
			Move(moveTo);
		}
	}

	void OnCompleteMove(MoveTo completeMoveTo)
	{
		Move(completeMoveTo);
	}

	private void Move(MoveTo moveTo)
	{
		var target = this.transform.position;
		target += transform.forward * (Random.Range(-range.size.z, range.size.z) * 0.5f);
		target += transform.right * (Random.Range(-range.size.x, range.size.x) * 0.5f);
		target += transform.up * (Random.Range(-range.size.y, range.size.y) * 0.5f);
		var delay = Random.Range(minDelay, maxDelay);
		var moveTime = Random.Range(minMoveTime, maxMoveTime);
		var lookTime = Random.Range(minLookTime, maxLookTime);
		var easeType = easeTypes[Random.Range(0, easeTypes.Count)];

		moveTo.Move(target, delay, moveTime, lookTime, easeType);
	}
}
