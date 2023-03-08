using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class SimpleCollectibleScript : MonoBehaviour
{


	public int coinCount = 0;
	public Text coinText;
	public TMP_Text textCounter;
	public enum CollectibleTypes { NoType, IncreaseSpeed, IncreaseSize};

	public CollectibleTypes CollectibleType;

	public bool rotate;

	public float rotationSpeed;

	public AudioClip collectSound;

	public GameObject collectEffect;

	void Start()
	{

	}


	void Update()
	{

		if (rotate)
			transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			coinCount++;
			Collect();
			//coinText.text = "Coins: " + coinCount.ToString();
		}
		if (other.CompareTag("Player"))
		{
			int count = int.Parse(textCounter.text);
			count++;
			textCounter.text = count.ToString();
			gameObject.SetActive(false);
		}

	}

	public void Collect()
	{
		if (collectSound)
			AudioSource.PlayClipAtPoint(collectSound, transform.position);
		if (collectEffect)
			Instantiate(collectEffect, transform.position, Quaternion.identity);



	}


}
