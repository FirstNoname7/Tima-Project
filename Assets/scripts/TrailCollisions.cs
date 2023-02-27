using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TrailRenderer))]
//https://www.youtube.com/watch?v=iestv-YP5CA&ab_channel=ZeroKelvinTutorials 
public class TrailCollisions : MonoBehaviour //скрипт дл€ создани€ коллизии трейла. „тобы объекты могли врезать€ в колизию, у них ќЅя«ј“≈Ћ№Ќќ должны быть Rigidbody и Collider
{
    TrailRenderer myTrail;
    EdgeCollider2D myCollider;

    void Start()
    {
        myTrail = GetComponent<TrailRenderer>();
        myCollider = new GameObject("TrailCollider", typeof(EdgeCollider2D)).GetComponent<EdgeCollider2D>();
    }

    void Update()
    {
        SetColliderPointsFromTrail(myTrail, myCollider);
    }

    void SetColliderPointsFromTrail(TrailRenderer trail, EdgeCollider2D collider)
    {
        List<Vector2> points = new List<Vector2>();
        //avoid having default points at (-.5,0),(.5,0)
        if (trail.positionCount == 0)
        {
            points.Add(transform.position);
        }
        else for (int position = 0; position < trail.positionCount; position++)
            {
                //ignores z axis when translating vector3 to vector2
                points.Add(trail.GetPosition(position));
            }
        collider.SetPoints(points);
    }

}