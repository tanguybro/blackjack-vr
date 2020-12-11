using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefab : MonoBehaviour
{
public int _nbPrefabs = 1000;
public GameObject _prefab = null;
public Transform _parent = null;
public Vector3 _position = Vector3.zero;

 private GameObject _instantiatedObject = null;
public GameObject instantiatedObject {
get { return _instantiatedObject; }
}

void ClonePrefab()
{
if (_prefab == null)
return;
for (int i = 0; i < _nbPrefabs; i++)
{
_instantiatedObject = Instantiate(_prefab, _parent);
_instantiatedObject.transform.localPosition = new Vector3(Random.Range(-10.0f,10.0f),1.0f, Random.Range(-10.0f, 10.0f));
AutoRotation ar = _instantiatedObject.GetComponent<AutoRotation>();
if (ar != null)
ar._speed = Random.Range(-360.0f, 360.0f);
}
}

 // Start is called before the first frame update
void Start()
{
}

 void Update()
{
if (Input.GetKeyDown(KeyCode.Space))
ClonePrefab();

 if (Input.GetKeyDown(KeyCode.Backspace))
{
for (int i = this.transform.childCount-1; i >=0 ; i--)
Destroy(this.transform.GetChild(i).gameObject);
}
}

}