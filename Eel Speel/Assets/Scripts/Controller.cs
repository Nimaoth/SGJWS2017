using UnityEngine;

public class Controller {

	private int id;

	public Controller(int id)
	{
		this.id = id;
	}

	public float GetHorizontalLeftAxis()
	{
		return Input.GetAxis("HorizontalLeft_" + id);
	}

	public float GetVerticalLeftAxis()
	{
		return Input.GetAxis("VerticalLeft_" + id);
	}

	public float GetHorizontalRightAxis()
	{
		return Input.GetAxis("HorizontalRight_" + id);
	}

	public float GetVerticalRightAxis()
	{
		return Input.GetAxis("VerticalRight_" + id);
	}

	public Vector2 GetLeftStick()
	{
		var v = new Vector2(Input.GetAxis("HorizontalLeft_" + id), Input.GetAxis("VerticalLeft_" + id));
		if (v.sqrMagnitude > 1)
			v.Normalize();

		return v;
	}

	public Vector2 GetRightStick()
	{
		var v = new Vector2(Input.GetAxis("HorizontalRight_" + id), Input.GetAxis("VerticalRight_" + id));
		if (v.sqrMagnitude > 1)
			v.Normalize();

		return v;
	}

	public bool GetL1Down()
	{
		return Input.GetButtonDown("L1_" + id);
	}

	public bool GetL2Down()
	{
		return Input.GetButtonDown("L2_" + id);
	}

	public bool GetR1Down()
	{
		return Input.GetButtonDown("R1_" + id);
	}

	public bool GetR2Down()
	{
		return Input.GetButtonDown("R2_" + id);
	}

	public bool GetL1()
	{
		return Input.GetButton("L1_" + id);
	}

	public bool GetL2()
	{
		return Input.GetButton("L2_" + id);
	}

	public bool GetR1()
	{
		return Input.GetButton("R1_" + id);
	}

	public bool GetR2()
	{
		return Input.GetButton("R2_" + id);
	}
}
