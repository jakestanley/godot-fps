using Godot;
using System;

public class GunPath : Godot.Path
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    PathFollow follow;
    private float bobDist = 0.2f;
    
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        follow = GetNode<PathFollow>("PathFollow");
        follow.RotationMode = PathFollow.RotationModeEnum.None;
        

        Vector3 p0 = Vector3.Zero;
        Vector3 p0out = Vector3.Zero;

        p0out.x -= bobDist/4;
        p0out.y -= bobDist/2;

        Vector3 p1 = Vector3.Zero;
        p1.y -= bobDist;

        Vector3 p1out = Vector3.Zero;
        p1out.x += bobDist/4;
        p1out.y -= bobDist/2;

        bool useCode = true;
        if(useCode) {
            Curve.ClearPoints();
            Curve.AddPoint(p0, p1out, p0out);
            Curve.AddPoint(p1, p0out, p1out);
            Curve.AddPoint(p0, p1out, p0out);
        }
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
    follow.Offset += 0.5f * delta;
 }
}
