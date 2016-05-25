using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateCover : MonoBehaviour {

    //    ArrayList points;
    List<GameObject> points;
    public GameObject pointObj;
    Vector3[] poly;
//    public Material material;
    public Material[] materials;
    MeshFilter filter;
    int count = 0;
    GameObject currSelectedpoint;
    GameObject lastSelectedPoint;
    float touchTime = 0; 
    int currMatIndex = 0;
    int frameCounter;
    public GameObject infoPanelFloor;
    bool hasCover;
    // Use this for initialization
    void Start () {
        points = new List<GameObject>();
        filter = gameObject.AddComponent(typeof(MeshFilter)) as MeshFilter;
        gameObject.AddComponent(typeof(MeshRenderer));
    }
	
	// Update is called once per frame
	void Update () {
        UserInput();
    }

    void OnDisable() {
        ClearCover();
    }

    public void ClearCover() {
        GameObject[] pointsToDelete = GameObject.FindGameObjectsWithTag("Point");
        for (int i = 0; i < pointsToDelete.Length; i++) {
            Destroy(points[i]);
        }
        if (points != null) {
            points.Clear();
            filter.mesh = null;
        } 
    }

   public void ChangeMaterial() {
        currMatIndex++;
        if (currMatIndex == materials.Length) currMatIndex -= materials.Length;
        gameObject.GetComponent<MeshRenderer>().material = materials[currMatIndex];      
    }

    public void MakeCover() {

        List<Vector2> points2D = new List<Vector2>();
        sortPoints(points);
        foreach (GameObject p in points) {
//            Debug.Log(p.name);
            points2D.Add(new Vector2(p.transform.position.x, p.transform.position.z));
        }
        Triangulator tr = new Triangulator(points2D);
        int[] indices = tr.Triangulate();

        // Create the mesh
        Mesh msh = new Mesh();        
        // Create the Vector3 vertices
        Vector3[] vertices = new Vector3[points2D.Count];
        Vector2[] uvs = new Vector2[points2D.Count];
        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = new Vector3(points2D[i].x, 0.1f, points2D[i].y);
            uvs[i] = new Vector2(vertices[i].x, vertices[i].z)*0.001f;
        }
        msh.vertices = vertices;
        msh.triangles = indices;
        msh.uv = uvs;
        msh.RecalculateNormals();
        msh.RecalculateBounds();
       
        filter.mesh = msh;       
        gameObject.GetComponent<MeshRenderer>().material = materials[currMatIndex];
    }

    static void sortPoints(List<GameObject> verticles) {

        //center of cover
        Vector3 center = new Vector3();
        foreach (GameObject g in verticles) {
            center += g.transform.position;
        }
        center /= verticles.Count;
        for (int i = verticles.ToArray().Length - 1; i > 0; i--)
        {
            for (int j = 0; j < i; j++)
            {
                if (dirAngle(center - verticles[j].transform.position) < dirAngle(center - verticles[j + 1].transform.position))
                {
                    GameObject tmp = verticles[j];
                    verticles[j] = verticles[j + 1];
                    verticles[j + 1] = tmp;
                }
            }
        }
    }

    static float dirAngle(Vector3 v)
    {
        float angle = Vector3.Angle(v, Vector3.forward);
        float sign = Mathf.Sign(Vector3.Dot(Vector3.up, Vector3.Cross(v, Vector3.forward)));
        float signed_angle = angle * sign;
        return signed_angle;
    }


    void UserInput()
    {
        if (Application.isEditor)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Floor")
                    {
                        Vector3 point = hit.point;
                        GameObject vert = (GameObject) Instantiate(pointObj, point, Quaternion.identity);
                        vert.name = "P" + count;
                        points.Add(vert);
                        if (points.Count > 3) MakeCover();
                        count++;
                    }
                    if (hit.transform.gameObject.tag == "Point") {
                        currSelectedpoint = hit.transform.gameObject;
                        currSelectedpoint.GetComponent<Collider>().enabled = false;
                        frameCounter = 0;
                    }
                }
            }

            if (Input.GetMouseButton(0)&& currSelectedpoint!=null) {

                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    if (hit.transform.gameObject.tag == "Floor")
                    {
                        currSelectedpoint.transform.position = hit.point;
                        if (frameCounter % 10 == 0) MakeCover();
                        else frameCounter++;
                    }
                    
                }
            }

            if (Input.GetMouseButtonUp(0) && currSelectedpoint != null) {
                currSelectedpoint.GetComponent<Collider>().enabled = true;
                currSelectedpoint = null;
                frameCounter = 0;
            }
        }
        else {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                RaycastHit hit;

                
                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Floor")
                    {
                        touchTime = 0;
                    }
                    if (hit.transform.gameObject.tag == "Point")
                    {
                        currSelectedpoint = hit.transform.gameObject;
                        currSelectedpoint.GetComponent<Collider>().enabled = false;
                        frameCounter = 0;
                    }
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Stationary) {
                touchTime += Time.deltaTime;
                if (touchTime > 0.7f) {

                    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                    {
                        if (hit.transform.gameObject.tag == "Floor")
                        {
                            Vector3 point = hit.point;
                            GameObject vert = (GameObject)Instantiate(pointObj, point, Quaternion.identity);
                            vert.name = "P" + count;
                            points.Add(vert);
                            if (points.Count > 3) MakeCover();
                            count++;
                            touchTime = 0;
                        }
                       
                    }
                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                touchTime = 0;
            }


            if (Input.GetTouch(0).phase == TouchPhase.Moved && currSelectedpoint != null) {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    if (hit.transform.gameObject.tag == "Floor")
                    {
                        currSelectedpoint.transform.position = hit.point;
                        if (frameCounter % 10 == 0) MakeCover();
                        else frameCounter++;
                    }

                }
            }

            if (Input.GetTouch(0).phase == TouchPhase.Ended && currSelectedpoint != null) {
                currSelectedpoint.GetComponent<Collider>().enabled = true;
                currSelectedpoint = null;
                frameCounter = 0;
            }
        }
    }

    public void OpenInfoPanelFloor()
    {
        infoPanelFloor.SetActive(true);
    }

    public void CloseInfoPanelFloor()
    {
        infoPanelFloor.SetActive(false);
    }
}
