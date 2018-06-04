using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Det här scriptet tar hand om "Blink" funktionen

public class Blink : MonoBehaviour {

    RaycastHit2D[] hits;
    Vector3 bestpoint;


    public bool throughWalls;
    public bool nearestPoint;
    public bool blink2D;
    public float step = 0.2f;
    public float distance = 4f;

    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }
    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {

            if (!throughWalls)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.localScale.x * Vector2.right, distance);
                if (hit.collider == null)
                {
                    transform.position += transform.localScale.x * Vector3.right * distance;

                }
                else
                {
                    transform.position = hit.point;

                }
            }
            else
            {
                if (!Physics2D.OverlapPoint(transform.position + transform.localScale.x * Vector3.right * distance))
                {
                    transform.position += transform.localScale.x * Vector3.right * distance;
                }
                else if (!nearestPoint)
                {
                    hits = Physics2D.RaycastAll(transform.position, transform.localScale.x * Vector2.right, distance);


                    bestpoint = hits[0].point;
                    foreach (RaycastHit2D h in hits)
                    {
                        if (h.distance > Vector2.Distance(bestpoint, transform.position) &&
                           !Physics2D.OverlapPoint(h.point + h.normal * .3f))
                        {
                            bestpoint = h.point;
                        }
                    }

                    transform.position = bestpoint;

                }
                else if (nearestPoint)
                {
                    if (!blink2D)
                    {
                        hits = Physics2D.RaycastAll(transform.position, transform.localScale.x * Vector2.right, distance);

                        bestpoint = hits[0].point;
                        foreach (RaycastHit2D h in hits)
                        {
                            if (h.distance > Vector2.Distance(bestpoint, transform.position) &&
                               !Physics2D.OverlapPoint(h.point + h.normal * .3f))
                            {
                                bestpoint = h.point;
                            }
                        }
                        Vector3 aux = bestpoint;
                        while (Physics2D.OverlapPoint(aux))
                        {
                            aux += step * Vector3.right * transform.localScale.x;
                        }

                        if (Vector2.Distance(aux, transform.position + transform.localScale.x * Vector3.right * distance) < Vector2.Distance(bestpoint, transform.position + transform.localScale.x * Vector3.right * distance))
                            bestpoint = aux;


                        transform.position = bestpoint;

                    }
                    else if (blink2D)
                    {

                        bestpoint = transform.position;
                        Vector2 aux;
                        for (aux.x = transform.position.x + transform.localScale.x * distance - distance; aux.x < transform.position.x + transform.localScale.x * distance + distance; aux.x += step)
                        {

                            for (aux.y = transform.position.y - distance; aux.y < transform.position.y + distance; aux.y += step)
                            {

                                if (Vector2.Distance(aux, transform.position + transform.localScale.x * Vector3.right * distance) < Vector2.Distance(bestpoint, transform.position + transform.localScale.x * Vector3.right * distance)
                                   && !Physics2D.OverlapPoint(aux))
                                {
                                    bestpoint = aux;
                                }
                            }

                        }
                        transform.position = bestpoint;

                    }
                }
            }
        }
    }

    //Den här sträckan kod gör så man får se en linje i unity som visar vart man kommer "Blinka"
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + transform.localScale.x * Vector3.right * distance);
        Gizmos.DrawWireSphere(bestpoint, 0.2f);
    }
}