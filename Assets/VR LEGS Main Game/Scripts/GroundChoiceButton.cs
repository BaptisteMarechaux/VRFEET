using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundChoiceButton : MonoBehaviour {
	public int destinationScene;

	public Renderer renderer;
	public Material inactiveMaterial;
	public Material activeMaterial;

	float stayTimer=0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollsionEnter(Collision col)
	{
		//stayTimer = 0.0f;
	}

	void OnCollisionStay(Collision col)
	{
		this.renderer.material = activeMaterial;
		if (stayTimer >= 2.0f) {
			SceneManager.LoadScene (destinationScene);
		}
		stayTimer += Time.deltaTime;
	}

	void OnCollisionExit()
	{
		this.renderer.material = inactiveMaterial;
		stayTimer = 0.0f;
	}
}
