using UnityEngine;
using System.Collections;
using Windows.Kinect;

public class DetectJoints : MonoBehaviour {


    public GameObject bodySourceManager;
    public JointType trackedJoint;
    private BodySourceManager bodyManager;
    private Body[] bodies;
    public float multiplier = 10f;


	// Use this for initialization
	void Start ()
    {
	    if(bodySourceManager == null)
        {
            Debug.Log("Assign Game Object with Body Source Manager");
        }
        else
        {
            bodyManager = bodySourceManager.GetComponent<BodySourceManager>();
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (bodyManager == null)
        {
            return;
        }
        bodies = bodyManager.GetData();
        if (bodies == null)
        {
            return;
        }
        foreach (var body in bodies)
        {
            if (body == null)
            {
                continue;
            }
            if (body.IsTracked)
            {
                var pos = body.Joints[trackedJoint].Position;
                gameObject.transform.position = new Vector3(pos.X * multiplier, pos.Y * multiplier);
            }
        }

    }
}
