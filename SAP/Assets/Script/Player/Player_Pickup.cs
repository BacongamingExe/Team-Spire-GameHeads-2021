using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class Player_Pickup : MonoBehaviour
{
    public GameObject HoldPivot;
    public GameObject holdParent;
    public GameObject currentObject;
    public GameObject nulling;

    public string pickupButton;

    public bool isHolding;

    [SerializeField] private int playerID;
    [SerializeField] private Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerID);
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Holdable")
        {
            if (player.GetButtonDown(pickupButton))
            {
                if (isHolding)
                {
                        currentObject.transform.parent = null;
                        currentObject = nulling;

                        isHolding = false;
                }
                else
                {
                        currentObject.transform.parent = nulling.transform;
                        currentObject = other.gameObject;
                        currentObject.transform.parent = holdParent.transform;
                        currentObject.transform.position = HoldPivot.transform.position;

                        isHolding = true;
                }
            }
        }        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
