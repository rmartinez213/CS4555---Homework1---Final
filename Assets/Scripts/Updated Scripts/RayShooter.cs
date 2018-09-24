using UnityEngine;
using System.Collections;

public class RayShooter : MonoBehaviour {
	private Camera _camera;

    //To attach bullet picture to hitpoint
	public GameObject bullet_hole;

	void Start() {
		_camera = GetComponent<Camera>();

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}

	void OnGUI() {
		int size = 12;
		float posX = _camera.pixelWidth/2 - size/4;
		float posY = _camera.pixelHeight/2 - size/2;
		GUI.Label(new Rect(posX, posY, size, size), "*");
	}

	void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 point = new Vector3(_camera.pixelWidth/2, _camera.pixelHeight/2, 0);
			Ray ray = _camera.ScreenPointToRay(point);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit)) {
				GameObject hitObject = hit.transform.gameObject;
				ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
				if (target != null) {
					target.ReactToHit();
				} else {
					//StartCoroutine(SphereIndicator(hit.point));


                    //Creates bullet hole picture and destroys after 2 seconds
					GameObject ImpactGO = Instantiate(bullet_hole, hit.point, Quaternion.FromToRotation(Vector3.up, hit.normal));
					Destroy(ImpactGO, 2);
				}
			}
		}
	}



	private IEnumerator SphereIndicator(Vector3 pos) {
		GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		sphere.transform.position = pos;

		yield return new WaitForSeconds(1);

		Destroy(sphere);
	}
}