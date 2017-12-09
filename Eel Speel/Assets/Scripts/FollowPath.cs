using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine;

public class FollowPath : MonoBehaviour {
    public bool isAccelerating;
    private float multiplier = 1;

    public BGCurve curve;
	public BGCcMath math;

	private float pathLength = 0;

	[SerializeField]
	private float position = 0;

	[SerializeField]
	private float speed = 1;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < curve.PointsCount - 1; i++)
		{
			var p1 = curve.Points[i];
			var p2 = curve.Points[i + 1];

			var l = Vector3.Distance(
				p1.PositionWorld,
				p2.PositionWorld);
			pathLength += l;
		}
		Debug.Log("Path length: " + pathLength);
		Debug.Log(math);
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        if (isAccelerating)
        {
            multiplier *= 1.05f;
        }
        else if (multiplier > 1)
        {
            multiplier *= 0.95f;
        }


		if (position >= pathLength)
			position -= pathLength;

		if (position < 0)
			position += pathLength;

		position += speed * multiplier * Time.fixedDeltaTime;

		var pos = math.CalcPositionByDistanceRatio(position / pathLength);
		transform.rotation = Quaternion.LookRotation(math.CalcTangentByDistanceRatio(position / pathLength));
		transform.position = pos;
	}
}
