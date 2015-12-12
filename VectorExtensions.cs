using UnityEngine;

class SubvectorExtensions{

	public Vector3 SubvectorX(this Vector3 vector)
	{
		return new Vector3(vector.x, 0, 0);
	}
	public Vector3 SubvectorY(this Vector3 vector)
	{
		return new Vector3(0, vector.y, 0);	
	}
	public Vector3 SubvectorXY(this Vector3 vector)
	{
		return new Vector3(vector.x, vector.y, 0);		
	}
	public Vector3 SubvectorXZ(this Vector3 vector)
	{
		return new Vector3(vector.x, 0, vector.z);		
	}
	public Vector3 SubvectorYZ(this Vector3 vector)
	{
		return new Vector3(vector.y, vector.z);			
	}


	public Vector3 SubvectorX(this Vector2 vector)
	{
		return new Vector2(vector.x, 0);
	}
	public Vector3 SubvectorY(this Vector2 vector)
	{
		return new Vector2(0, vector.y);	
	}
}
