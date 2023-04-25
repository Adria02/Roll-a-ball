using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerMove : MonoBehaviour
{
    public float speed=0;
    private Rigidbody rb;
    public TextMeshProUGUI CountText;
    public GameObject winText;

    private int count;
    private float X;
    private float Y;
    // Start is called before the first frame update
    void Start(){
        count=0;
        rb=GetComponent<Rigidbody>();
        SetCountText();
        winText.SetActive(false);
    }

    // Update is called once per frame
    void SetCountText(){
        CountText.text = "Count: " + count.ToString();
        if (count>=18){
            winText.SetActive(true);
        }

    }
    void Reset(Collider other){
        
        if (other.gameObject.CompareTag("Reset")) {
            rb.transform.position = Vector3.zero;
        }

    }
    void OnMove(InputValue movementValue){
        Vector2 movementVector = movementValue.Get<Vector2>();
        X=movementVector.x;
        Y=movementVector.y;
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(X,0.0f,Y);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp")) 
        {
            other.gameObject.SetActive(false);
            count = count+1;
            SetCountText();
        }
    }
}
