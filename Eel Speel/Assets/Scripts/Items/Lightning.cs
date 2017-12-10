using System.Collections;
using UnityEngine;
using System.Linq;

public class Lightning : MonoBehaviour {

	public LineRenderer line;

	public float speed;
	public float range;
	public float lifetime;
	public int max;
	public float maxDist;

	void Start() {
		StartCoroutine(uiae());
	}

	private IEnumerator uiae()
	{
		var start = Time.time;
		while (start + lifetime > Time.time)
		{
			var arr = new Vector3[line.positionCount + 1];
			line.GetPositions(arr);

			int maxSkip = Mathf.Max(arr.Length - max, 0);
			arr = arr.Skip(maxSkip).ToArray();
			arr[arr.Length - 1] = new Vector3(Random.Range(-range, range),
				Random.Range(-range, range),
				arr[arr.Length - 2].z + speed * Time.deltaTime);
			if (arr[arr.Length - 1].z > maxDist)
				break;
			
			line.positionCount = arr.Length;
			line.SetPositions(arr);

			yield return null;
		}

		Destroy(gameObject);
	}
}
