using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : Interactable
{
    public Transform player;
    public GameObject tank;


    public PlayerController playerController;

    public bool activeVehicle;
    public bool isInTransition;
    public Transform seat;
    public Vector3 seatoffset;
    public Transform exitSeat;
    public float transitionSpeed = 0.2f;

    public void Update()
    {
        if (activeVehicle && isInTransition) Exit();
        if (!activeVehicle && isInTransition) Enter();
    }

    public override string GetDescription()
    {
        if (activeVehicle) return "Press [E] to exit the <color=red>driver</color> seat.";
        return "Press [E] to enter the <color=red>driver</color> seat.";
    }

    public override void Interact()
    {
        isInTransition = true;
    }

    public void Enter()
    {
        //Rotation lock

        //Constraints
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        playerController.rotationLimXmin = 0f;
        playerController.rotationLimYmax = 0f;
        playerController.rotationLimYmin = 0f;


        //Disable components
        player.GetComponent<CapsuleCollider>().enabled = false;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<PlayerMovement>().enabled = false;

        //Enable components and gameobjects
        tank.GetComponent<TankController>().enabled = true;

        //Move object to seat
        player.position = Vector3.Lerp(player.position, seat.position + seatoffset, transitionSpeed);
        player.rotation = Quaternion.Slerp(player.rotation, seat.rotation, transitionSpeed);

        //Reset - Check
        if (player.position == seat.position + seatoffset) { isInTransition = false; activeVehicle = true; }
    }

    public void Exit()
    {
        Debug.Log("Exiting!");
        //Move object to exit
        player.position = Vector3.Lerp(player.position, exitSeat.position, transitionSpeed);

        //Reset - Check
        if (player.position == exitSeat.position) { isInTransition = false; activeVehicle = false; }

        //Enable components and gameobjects
        player.GetComponent<CapsuleCollider>().enabled = true;
        player.GetComponent<Rigidbody>().useGravity = true;
        player.GetComponent<PlayerMovement>().enabled = true;

        //Constraints
        playerController.rotationLimYmax = 4320f;
        playerController.rotationLimYmin = -4320f;
        playerController.rotationLimXmin = -90f;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        player.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        //Disable Components and gameobjects
        tank.GetComponent<TankController>().enabled = false;
    }
}
