using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundChoiceButton : MonoBehaviour {
	public int destinationScene;

	public Renderer renderer;
	public Material inactiveMaterial;
	public Material activeMaterial;
    public BoxCollider collider;
    public float yActiveStepCollider = 1.45f;
    public float yActiveStep = -0.045f;
    private float yoriginal;
    private float yoriginalCollider;
    public AudioSource audioEffectDown;
    public AudioSource audioEffectUp;

    float stayTimer=0;
	// Use this for initialization
	void Start () {
        yoriginal = transform.position.y;
        yoriginalCollider = collider.size.y;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision col)
	{
        audioEffectDown.Play();
    }

	void OnCollisionStay(Collision col)
	{
        transform.position = new Vector3(transform.position.x, yActiveStep, transform.position.z);
        collider.size = new Vector3(collider.size.x, yActiveStepCollider, collider.size.z);
        this.renderer.material = activeMaterial;
		if (stayTimer >= 1.5f) {
			SceneManager.LoadScene (destinationScene);
		}
		stayTimer += Time.deltaTime;
    }

	void OnCollisionExit()
	{
        transform.position = new Vector3(transform.position.x, yoriginal, transform.position.z);
        collider.size = new Vector3(collider.size.x, yoriginalCollider, collider.size.z);
        this.renderer.material = inactiveMaterial;
		stayTimer = 0.0f;
        audioEffectUp.Play();
    }
}
