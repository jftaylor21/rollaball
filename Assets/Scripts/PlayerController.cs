using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    public float speed;
    public GUIText countText;
    public GUIText winText;
    private int count;

    void updateCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count == 12)
        {
            winText.text = "You Win";
        }
    }

    // Start happens on initialization
    void Start()
    {
        count = 0;
        updateCountText();
        winText.text = "";
    }

    // FixedUpdate happens before physics update
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);

        rigidbody.AddForce(movement * speed * Time.deltaTime);
    }

    // OnTriggerEnter happens on collision
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PickUp")
        {
            other.gameObject.SetActive(false);
            ++count;
            updateCountText();
        }
    }
}
