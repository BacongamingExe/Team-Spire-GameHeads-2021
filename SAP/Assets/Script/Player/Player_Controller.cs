using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
public class Player_Controller : MonoBehaviour
{
    public Transform aimTransform;

    public string moveHorizontal;
    public string moveVertical;

    public string lookVertical;
    public string lookHorizontal;

    public string jumpButton;

    public float jumpSpeed;
    public float movementSpeedH;
    public float movementSpeedV;

    public float rotValue = 180;

    public bool isGrounded;

    [SerializeField] private int playerID;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(isGrounded)
        {
            if(player.GetButtonDown(jumpButton))
            {
                this.gameObject.GetComponent<Rigidbody>().AddForce(transform.up * jumpSpeed);
            }
        }

        if (player.GetAxis(moveHorizontal) > 0)
        {
            transform.Translate(movementSpeedH, 0, 0 * Time.deltaTime);
        }

        if (player.GetAxis(moveHorizontal) < 0)
        {
            transform.Translate(-movementSpeedH, 0, 0 * Time.deltaTime);
        }

        if (player.GetAxis(moveVertical) > 0)
        {
            transform.Translate(0, 0, movementSpeedV * Time.deltaTime);
        }

        if (player.GetAxis(moveVertical) < 0)
        {
            transform.Translate(0, 0, -movementSpeedV * Time.deltaTime);
        }

        aimTransform.transform.eulerAngles = new Vector3(0, Mathf.Atan2(player.GetAxis(lookHorizontal), player.GetAxis(lookVertical)) * rotValue / Mathf.PI, 0);
        
    }
}
