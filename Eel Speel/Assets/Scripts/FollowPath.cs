using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine;

public class FollowPath : MonoBehaviour {
    public float Acceleration = 0.0f;
    public float multiplier = 1;
    public float multiplierOffset = 0.01f;
    public float multiplierMax = 2.0f;
    public float multiplierMin = 0.5f;
    public float multiplierDamp = 1.0f;

    public BGCurve curve;
	public BGCcMath math;

	public AudioSource audio;

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
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        multiplier *= 1 + (Acceleration * 0.02f);

        //damp
        multiplier = Mathf.Lerp(multiplier, 1.0f, Time.fixedDeltaTime * multiplierDamp);
        multiplier = Mathf.Clamp(multiplier, multiplierMin, multiplierMax);
		if (position >= pathLength)
			position -= pathLength;

		if (position < 0)
			position += pathLength;

		position += speed * multiplier * Time.fixedDeltaTime;

		var pos = math.CalcPositionByDistanceRatio(position / pathLength);
		transform.rotation = Quaternion.LookRotation(math.CalcTangentByDistanceRatio(position / pathLength));
		transform.position = pos;
	}

	public void Suck(float amount)
	{
		if (amount > 0)
		{
			audio.Play();
		}
		else
		{

		}
	}
}
