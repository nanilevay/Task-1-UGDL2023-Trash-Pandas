using UnityEngine;

public class ParallaxScript : MonoBehaviour
{
    public GameObject ObjToMove;

    RectTransform myRectTransform;

    public Vector3 InitialPos;

    // Start is called before the first frame update
    void Start()
    {
         myRectTransform = ObjToMove.GetComponent<RectTransform>();
         InitialPos = myRectTransform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (-myRectTransform.offsetMax.x >= 951)
            myRectTransform.localPosition = InitialPos;

        myRectTransform.localPosition -= Vector3.right;

        Debug.Log(myRectTransform.offsetMax.x);
    }
}