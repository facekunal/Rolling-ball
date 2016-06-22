using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
	public Text countText;
	public Text winText;
	void Start () {
	    rb = GetComponent<Rigidbody>();
        count =0;
		SetCountText ();
		winText.text = "";
	}
	
	
	void FixedUpdate () {
        //Input
	    float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ( "Vertical" );
	    Vector3 movement = new Vector3(moveHorizontal,0.0f,moveVertical);
        rb.AddForce(movement * speed);  
    }
    
     void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Pick Up")){
           other.gameObject.SetActive(false);
           count++;
			SetCountText ();
        }
    }

	void SetCountText(){
		countText.text = "Score : " + count.ToString ();
		if (count >= 8)
			winText.text = "You win !";
			
	}
	    
}
