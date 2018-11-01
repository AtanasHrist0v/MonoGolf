using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour {

    public GameObject cam, pivot, plane;
    public Text counter;
    public LevelBuilder levelBuilder;
    float angle, drawLength, speedMultiplier = 30F;
    Vector3 startPos, endPos, direction, force, lastPos;
    bool shot = false, mouseHeld = false;
    Quaternion rotation;
    
    // Use this for initialization
    void Start () {
        Input.simulateMouseWithTouches = true;
        plane.GetComponent<MeshRenderer>().enabled = false;
        cam.GetComponent<Camera>().fieldOfView = 55 / ((float)cam.GetComponent<Camera>().pixelWidth / cam.GetComponent<Camera>().pixelHeight);
    }
	
	// Update is called once per frame
	void Update () {


        if (Input.GetMouseButtonDown(0) && GetComponent<Rigidbody>().velocity == Vector3.zero)
        {
 
            startPos = new Vector3(cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).x, cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).y, 0);
            plane.GetComponent<MeshRenderer>().enabled = true;
            
        }
        if (Input.GetMouseButton(0) && GetComponent<Rigidbody>().velocity == Vector3.zero && Input.mousePosition.y < Screen.height - Screen.height / 6 && Mathf.Abs(GetComponent<Rigidbody>().velocity.x) + Mathf.Abs(GetComponent<Rigidbody>().velocity.y) + Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > 0)
        {
            startPos = new Vector3(cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).x, cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).y, 0);
            plane.GetComponent<MeshRenderer>().enabled = true;
            endPos = Input.mousePosition;
            drawLength = (Mathf.Sqrt(Mathf.Pow((startPos.x - endPos.x), 2) + Mathf.Pow((startPos.y - endPos.y), 2))) % 400;
            if ((Mathf.Sqrt(Mathf.Pow((startPos.x - endPos.x), 2) + Mathf.Pow((startPos.y - endPos.y), 2))) / 400 >= 1) drawLength = 399;
            angle = Vector3.Angle(startPos - new Vector3(startPos.x, endPos.y, endPos.z), startPos - endPos);
            rotation = Quaternion.Euler(0, angle, 0);
            direction = rotation * Vector3.forward;
            force = direction * speedMultiplier * drawLength;
            if (startPos.x < endPos.x && startPos.y > endPos.y)
            {
                angle = -angle;
                rotation = Quaternion.Euler(0, angle, 0);
                direction = rotation * Vector3.forward;
                force = direction * speedMultiplier * drawLength;
            }
            else if (startPos.x < endPos.x && startPos.y < endPos.y) force = -force;
            else if (startPos.x > endPos.x && startPos.y < endPos.y)
            {
                angle = -angle;
                rotation = Quaternion.Euler(0, angle, 0);
                direction = rotation * Vector3.forward;
                force = -(direction * speedMultiplier * drawLength);

            }
            else if (startPos.x < endPos.x && startPos.y == endPos.y)
            {
                rotation = Quaternion.Euler(0, angle, 0);
                direction = rotation * Vector3.forward;
                force = -(direction * speedMultiplier * drawLength);
            }
            else if (startPos.x == endPos.x && startPos.y < endPos.y)
            {
                rotation = Quaternion.Euler(0, angle, 0);
                direction = rotation * Vector3.forward;
                force = -(direction * speedMultiplier * drawLength);
            }
            pivot.transform.localScale = new Vector3(pivot.transform.localScale.x, pivot.transform.localScale.y, drawLength / 4000F);
            if (startPos.y <= endPos.y)
            {
                if (startPos.y == endPos.y && startPos.x > endPos.x)
                {
                    pivot.transform.localScale = new Vector3(pivot.transform.localScale.x, pivot.transform.localScale.y, (drawLength / 4000F));
                }
                else pivot.transform.localScale = new Vector3(pivot.transform.localScale.x, pivot.transform.localScale.y, -(drawLength / 4000F));
            }
            pivot.transform.position = new Vector3(GetComponent<Transform>().position.x, 0.52F, GetComponent<Transform>().position.z);
            pivot.transform.rotation = rotation;
            mouseHeld = true;
            if (endPos.x >= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).x - 50 && endPos.x <= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).x + 50 && endPos.y >= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).y - 50 && endPos.y <= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).y + 50) plane.GetComponent<MeshRenderer>().enabled = false;
        }
        if (mouseHeld && Input.GetMouseButton(0) == false && Input.mousePosition.y < Screen.height - Screen.height / 6 && Mathf.Abs(GetComponent<Rigidbody>().velocity.x) + Mathf.Abs(GetComponent<Rigidbody>().velocity.y) + Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > 0)
        {
            if (!(endPos.x >= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).x - 50 && endPos.x <= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).x + 50 && endPos.y >= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).y - 50 && endPos.y <= cam.GetComponent<Camera>().WorldToScreenPoint(GetComponent<Transform>().position).y + 50)) {
                GetComponent<Rigidbody>().AddRelativeForce(force);
                lastPos = GetComponent<Transform>().position;
                shot = true;
                levelBuilder.shotsLeft--;
            }
            plane.GetComponent<MeshRenderer>().enabled = false;
            mouseHeld = false;
        }

        if (GetComponent<Transform>().position.y < -1F)
        {
            GetComponent<Transform>().position = lastPos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Transform>().position = lastPos;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

        if (Input.mousePosition.y > Screen.height - Screen.height / 6) {
            plane.GetComponent<MeshRenderer>().enabled = false;
        }
        counter.text = "Shots left: " + levelBuilder.shotsLeft;

        //Debug.Log(GetComponent<Rigidbody>().velocity);
    }

    void LateUpdate()
    {
        cam.transform.position = new Vector3(GetComponent<Transform>().position.x, 12, GetComponent<Transform>().position.z + (float)cam.GetComponent<Camera>().pixelWidth / 350);
        if (cam.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(0, 0, cam.GetComponent<Camera>().nearClipPlane)).z >= 40) cam.transform.position = new Vector3(0, 12, 40.2F);

        if (GetComponent<Rigidbody>().velocity.z == 0)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Transform>().rotation = Quaternion.identity;
            shot = false;
        }

        if (GetComponent<Transform>().position.y > 4.5 && Mathf.Abs(GetComponent<Rigidbody>().velocity.x) + Mathf.Abs(GetComponent<Rigidbody>().velocity.y) + Mathf.Abs(GetComponent<Rigidbody>().velocity.z) > 0)
        {
            Physics.sleepThreshold = 0;
        }
        else Physics.sleepThreshold = 100;

    }

	void OnCollisionEnter(Collision col)
	{
		if(col.gameObject.name == "Trigger") 
		{
			SceneManager.LoadScene (1);
		}
	}
}
