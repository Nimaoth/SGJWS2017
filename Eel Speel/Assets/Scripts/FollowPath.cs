using BansheeGz.BGSpline.Components;
using BansheeGz.BGSpline.Curve;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FollowPath : MonoBehaviour {
    public float Acceleration = 0.0f;
    public float multiplier = 1;
    public float multiplierOffset = 0.01f;
    public float multiplierMax = 2.0f;
    public float multiplierMin = 0.5f;
    public float multiplierDamp = 1.0f;
    public float totalDistance = 0f;

    public Text place;
    public Text timeText;

    public BGCurve curve;
	public BGCcMath math;
	
	public AudioClip suck;
	public AudioClip antiSuck;

	public Transform bodyTransform;

	private float pathLength = 0;

	[SerializeField]
	private float position = 0;

	[SerializeField]
	private float speed = 1;

    [SerializeField]
    private float Timer = 0.0f;

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

    //Timer
    private void Update()
    {
        Timer = Time.time;
		int lap = (int)(totalDistance / pathLength);
		timeText.text = string.Format("Lap: {0}/8", lap);
        int tempPlace = SplitScreenMan.players.IndexOf(this) + 1;
        place.text = string.Format("Position: {0}/{1}", tempPlace, SplitScreenMan.players.Count);
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
        totalDistance += speed * multiplier * Time.fixedDeltaTime;

		var pos = math.CalcPositionByDistanceRatio(position / pathLength);
		transform.rotation = Quaternion.LookRotation(math.CalcTangentByDistanceRatio(position / pathLength));
		transform.position = pos;

        if (totalDistance / pathLength > 8.0f)
        {
            string name;
            switch (transform.GetComponentInChildren<PlayerMovement>().id)
            {
                case 1: name = "Aal Capone";
                    break;
                case 2: name = "Maalefitz";
                    break;
                case 3: name = "Sir Eelington";
                    break;
                case 4: name = "Senor Moreno";
                    break;
                default:
                    break;
            };
            SceneManager.LoadScene("EndScreen");
        }
	}

	public void Suck(float amount)
	{
		if (amount > 0)
		{
			AudioSource.PlayClipAtPoint(suck, Vector3.zero);
		}
		else if (amount < 0)
		{
			AudioSource.PlayClipAtPoint(antiSuck, Vector3.zero);
		}
	}
}
