using UnityEngine;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


public class Heart_Text : MonoBehaviour
{

    public GameObject GameBeat;
    public int heartrateInput;
	float tempHR;
	string path;
	string Url;
	string jsonRate;
	WWW www;
    
    
    void Start()
    {
		string url = "https://api.particle.io/v1/devices/230039000a47353138383138/rate?access_token=fc30489129ccbad879a2e3921485501418ada51c";// Settingan Api Untuk Hardware
		www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
        heartrateInput = 74;
    }

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			string work = www.data;

			_Particle fields = JsonUtility.FromJson<_Particle>(work);
			string jsonRate = fields.result;

			tempHR = float.Parse (jsonRate);
			heartrateInput = Mathf.FloorToInt(tempHR);
			Debug.Log (heartrateInput);
		} else {

		}    
	}

    
    void Update()
    {

        
		string url = "https://api.particle.io/v1/devices/230039000a47353138383138/rate?access_token=fc30489129ccbad879a2e3921485501418ada51c";// Settingan Api Untuk Hardware
		www = new WWW(url);
		StartCoroutine(WaitForRequest(www));

        GetComponent<TextMesh>().text = heartrateInput.ToString("f0")+"BPM";


    }

	[System.Serializable]
	public class _Particle{
		public string name;
		public string result;
	}


}
