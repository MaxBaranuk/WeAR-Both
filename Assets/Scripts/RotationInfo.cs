using UnityEngine;
using System.Collections.Generic;

public class RotationInfo : MonoBehaviour 
{
	
	public List<GameObject> iPanels;
	public List<LineRenderer> lines;
    public Vector3 [] beginPoints;
	public Transform moon;
    public Material lineMaterial;
	LineRenderer line;

	GameObject arCam;

	void Start () 
	{
		arCam = GameObject.Find("ARCamera");
        if (SceneStateManager.instance.curentManager.name == "InfoManager")
        {
            foreach (var item in iPanels)
            {
                line = item.gameObject.AddComponent<LineRenderer>();
                line.SetWidth(0.02f, 0.02f);
                line.SetVertexCount(2);
                lines.Add(line);
            }
            lineMaterial = Resources.Load("Education") as Material;

            //            lines[0].material = Resources.Load("Buisness") as Material;
            //           lines[1].material = Resources.Load("Education") as Material;
            //            lines[2].material = Resources.Load("Fun") as Material;
            //           lines[3].material = Resources.Load("Promotion") as Material;
        }
           
	}
	
	void Update () 
	{
        if (SceneStateManager.instance.curentManager.name == "InfoManager") {
            int count = 0;
            foreach (var item in iPanels)
            {
                item.transform.rotation = Quaternion.LookRotation(transform.position - arCam.transform.position);
                line = item.gameObject.GetComponent<LineRenderer>();
                line.SetPosition(0, beginPoints[count]);
                line.SetPosition(1, item.transform.GetChild(1).position);
                line.material = lineMaterial;
                count++;
            }
        }
//		transform.rotation = moon.transform.rotation;
	}
}
