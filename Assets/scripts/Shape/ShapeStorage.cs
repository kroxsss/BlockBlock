using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ShapeStorage : MonoBehaviour
{
    public List<ShapeData> shapeData;
    public List<Shape> shapeList;


    private void OnEnable()
    {
        GameEvents.RequestNewShape += RequestNewShape;

    }
    private void OnDisable()
    {
        GameEvents.RequestNewShape -= RequestNewShape;
    }

    
    void Start()
    {
        foreach (var shape in shapeList)
        {
            var shapeIndex = UnityEngine.Random.Range(0,shapeData.Count);
            shape.CreateShape(shapeData[shapeIndex]);
        }
    }

   


    public Shape GetCurrentSelectedShape() 
    {
        foreach (var shape in shapeList)
        {
            if(shape.IsOnStartPosition() == false && shape.IsAnyOfShapeSquareActive())
                return shape;
        }
        Debug.LogError("There is no shape selected!");
           return null; 
    }

      
    private void RequestNewShape()
    {
        foreach (var shape in shapeList)
        {
            var shapeIndex = UnityEngine.Random.Range(0, shapeData.Count);
            shape.RequestNewShape(shapeData[shapeIndex]);
        }
    }


}
