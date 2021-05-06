using Godot;
using System;

public class PlayerMovement : KinematicBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    private Vector3 velocity = Vector3.Zero;
    private Vector3 initial;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // for testing purposes, store the original position
        initial = GlobalTransform.origin;
    }
    public override void _Input(InputEvent @event) 
    {
        // press escape to restore the original position
        if(@event is InputEventKey eventKey) {
            if(eventKey.Scancode == (int) KeyList.Escape) {
                Translation = initial;
            }
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _PhysicsProcess(float delta)
    {

        // var horizontal = (mouseX * hSpeed) / delta;
        // this.RotateY(-horizontal);
        // mouseMoved = false;

        var direction = Vector3.Zero;

        if(Input.IsActionPressed("move_forward"))
        {
            direction -= GlobalTransform.basis.z;
        }
        if(Input.IsActionPressed("move_backward")) {
            direction += GlobalTransform.basis.z;
        }
        if(Input.IsActionPressed("move_left"))
        {
            direction -= GlobalTransform.basis.x;
        }
        if(Input.IsActionPressed("move_right")) {
            direction += GlobalTransform.basis.x;
        }

        if (Vector3.Zero != direction)
        {
            direction.Normalized();
        }

        velocity.z = direction.z * 14;
        velocity.x = direction.x * 14;
        velocity.y -= 100 * delta;

        velocity = MoveAndSlide(velocity, Vector3.Up);
    }
}
