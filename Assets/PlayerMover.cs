using UnityEngine;
using System.Collections;

public class PlayerMover : MonoBehaviour {

    bool canMove = true;
    public float moveSpeed = 1f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (canMove)
        {
            float xVal = Input.GetAxisRaw("Horizontal");
            float zVal = Input.GetAxisRaw("Vertical");
            MovePlayer((int)xVal, (int)zVal);
        }
	}

    void MovePlayer(int xInput, int zInput)
    {
        Vector3 lastPos = transform.position;

        float xMove = xInput * Time.deltaTime * moveSpeed;
        float zMove = zInput * Time.deltaTime * moveSpeed;

        Vector3 nextPos = transform.position + new Vector3(xMove, 0f, zMove);
        gameObject.GetComponent<Rigidbody>().MovePosition(nextPos);

        //Get direction
        if(lastPos != nextPos)
        {
            transform.forward = nextPos - lastPos;
        }
    }

    public void PauseMover()
    {
        canMove = false;
    }

    public void RestartMover()
    {
        canMove = true;
    }
}
