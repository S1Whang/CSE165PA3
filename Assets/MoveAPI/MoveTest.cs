using UnityEngine;
using System.Collections;
using MoveServerNS;
public class MoveTest : MonoBehaviour {

    public MoveServer moveServer;
    // Use this for initialization
    [Range(1, 6)]
    public int controller;
	GameObject sphere;
	Camera cam;
	public GameObject testplane;
    private int r = 0;
    private int g = 255;
    private int b = 0;
	double time;
	void Start () {
		testplane.transform.position = new Vector3 (-84033, 1200, -73416);
		sphere = testplane.transform.GetChild (2).gameObject;
		cam = testplane.transform.GetChild (0).GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
        MoveController move = moveServer.getController(controller-1);
		print (move.controllerNumber);
		time += Time.deltaTime;
		if (time > 3.0f) {
			if (move != null) {
				/* if (move.btnOnPress (MoveButton.BTN_MOVE)) {
					print ("Move");
					r = (int)(Random.value * 255);
					g = (int)(Random.value * 255);
					b = (int)(Random.value * 255);
					moveServer.Send_setMoveLight (move, r, g, b);
				} */
				if (move.btnOnPress (MoveButton.BTN_CIRCLE)) {
					print ("Circle");
				}
				if (move.btnOnPress (MoveButton.BTN_SQUARE)) {
					print ("Square");
					r = 0;
					//moveServer.Send_setMoveLight (move, r, g, b);
					testplane.transform.rotation *= new Quaternion (0,5,0,0);
				}
				if (move.btnOnPress (MoveButton.BTN_TRIANGLE)) {
					print ("Triangle");
					moveServer.Send_calibrateOrientation (move);
					int n = 10;
					while (n > 0) {
						testplane.transform.position -= new Vector3 (1, 10, 1);
						n--;
					}
				}
				if (move.btnOnPress (MoveButton.BTN_CROSS)) {
					print ("Cross");
					//moveServer.Send_resetMoveLight(move);
					testplane.transform.rotation = new Quaternion (5,-5,5,5);

				}
				//tr
				Vector3 speed = sphere.transform.position;
				transform.rotation = move.getQuaternion ();
				testplane.transform.rotation = move.getQuaternion ();
				//sphere.transform.position/10000;
				transform.position = new Vector3 (move.getPositionSmooth ().x * 10, move.getPositionSmooth ().y * 10, move.getPositionSmooth ().z * 10);
				if (move.triggerValue > 50) {
					print ("trigger");
					if (move.btnPressed (MoveButton.BTN_MOVE))
						testplane.transform.position -= new Vector3 (1, 10, 1);
					//moveServer.Send_rumbleController (move, move.triggerValue);
					else
						testplane.transform.position += new Vector3 (1, 10, 1);
				}
				testplane.transform.position = 
				Vector3.MoveTowards (testplane.transform.position,
					speed, (float)(50.0f / Time.deltaTime));
				if (move.btnOnPress (MoveButton.BTN_SELECT)) {
					print ("select");
					testplane.transform.position = new Vector3 (0, 3, 0);
					testplane.transform.localScale = new Vector3 (4, 4, 4);
				}
				if (move.btnOnPress (MoveButton.BTN_START)) {
					Debug.Log (testplane.transform.position - sphere.transform.position);
				}
				//testplane.transform.position = testplane.transform.position;
			}
		}
		else
			moveServer.Send_calibrateOrientation (move);
	}
}
