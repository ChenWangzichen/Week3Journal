using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    //set index
    int index = 0;
    Vector3 end;

    private void Start()
    {
        end = starTransforms[index].position;
    }
    // Update is called once per frame
    void Update()
    {
        DrawConstellation();
    }
    public void DrawConstellation()
    {
        //get the speed from distance/time
        float speed = Vector3.Distance(starTransforms[index].position, starTransforms[index + 1].position) / drawingTime;
        //if reach to the end, start the next
        if(Vector3.Distance(end, starTransforms[index+1].position)<0.1)
        {
            index = (index+1)%10;
            end = starTransforms[index].position;
        }
        //the end of line is moving so that it's "drawing" the line
        end += speed * (starTransforms[index + 1].position - starTransforms[index].position).normalized * Time.deltaTime;
        Debug.DrawLine(starTransforms[index].position, end);
    }
}
