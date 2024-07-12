// 추상 팩토리 패턴

using UnityEngine;

public interface Shape
{
    void Draw();
}

public class Rectangle : Shape
{
    public void Draw()
    {
        Debug.Log("Rectangle");
    }
}
public class Sphere : Shape
{
    public void Draw()
    {
        Debug.Log("Sphere");
    }
}
public class Triangle : Shape
{
    public void Draw()
    {
        Debug.Log("Triangle");
    }
}
public class SuperRectangle : Shape
{
    public void Draw()
    {
        Debug.Log("SuperRectangle");
    }
}
public class SuperSphere : Shape
{
    public void Draw()
    {
        Debug.Log("SuperSphere");
    }
}
public class SuperTriangle : Shape
{
    public void Draw()
    {
        Debug.Log("SuperTriangle");
    }
}

public interface ShapeFactory
{
    Shape getShape(string typeString);
}

public class SimpleShapeFactory : ShapeFactory
{
    public Shape getShape(string typeString)
    {
        switch (typeString)
        {
            case "Rectangle":
                return new Rectangle();
            case "Sphere":
                return new Sphere();
            case "Triangle":
                return new Triangle();
        }

        return null;
    }
}

public class SuperShapeFactory : ShapeFactory
{
    public Shape getShape(string typeString)
    {
        switch (typeString)
        {
            case "Rectangle":
                return new SuperRectangle();
            case "Sphere":
                return new SuperSphere();
            case "Triangle":
                return new SuperTriangle();
        }

        return null;
    }
}

public class FactoryProvider
{
    public static ShapeFactory GetFactory(string factoryType)
    {
        switch (factoryType)
        {
            case "Simple":
                return new SimpleShapeFactory();
            case "Super":
                return new SuperShapeFactory();
        }

        return null;
    }
}

public class AbstractFactory : MonoBehaviour
{
    void Awake()
    {
        {
            ShapeFactory shapeFactory = FactoryProvider.GetFactory("Simple");
        
            Shape shape = shapeFactory.getShape("Sphere");
            shape.Draw();
        }
        {
            ShapeFactory superShapeFactory = FactoryProvider.GetFactory("Super");
        
            Shape shape = superShapeFactory.getShape("Sphere");
            shape.Draw();
        }
    }
}