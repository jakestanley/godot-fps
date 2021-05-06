using Godot;
using System;

public class Player : Node
{
    // Declare member variables here. Examples:
    private float mouseX = 0;
    private float mouseY = 0;
    private bool mouseMoved = false;
    private float hSpeed = 0.0002f;
    private float vSpeed = 0.01f;
    private float mSpeed = 0.02f;
    private Vector2 move = new Vector2(0,0);
    
        // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        Input.SetMouseMode(Input.MouseMode.Captured);
        // CSGCylinder body = (CSGCylinder) this.GetNode("KinematicBody");
        // this hides everything in the tree so its not appropriate
        //body.Visible = false;
    }

    public override void _Input(InputEvent @event) 
    {
        if (@event is InputEventMouseMotion mouseMotion) {
            Vector2 relative = mouseMotion.Relative;
            mouseX = relative.x;
            mouseY = relative.y;
            mouseMoved = true;
        }

        if(@event is InputEventKey eventKey) {

            if(eventKey.Scancode == (int) KeyList.Q) {
                // TODO this doesn't work. change to working call
                Console.WriteLine("quit");

                // this does work
                GetTree().Quit();
            }
        }
    }

 // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {

        // GD.Print("Delta: " + delta);

        KinematicBody body = this.GetNode<KinematicBody>("KinematicBody");

        if(mouseMoved) {
            Camera cam = this.GetNode<Camera>("KinematicBody/CSGCylinder/Camera");
            
            var horizontal = (mouseX * hSpeed) / delta;
            var vertical = (mouseY * vSpeed) / delta;

            // GD.Print("h/v: " + horizontal + "/" + vertical);

            // look left and right (not happy with this. why is mouse x so fast?)
            body.RotateY(-horizontal);

            // look up and down
            Vector3 vRot = cam.RotationDegrees;
            vRot.x -= vertical;
            vRot.x = Mathf.Clamp(vRot.x, -70, 70);
            cam.RotationDegrees = vRot;

            mouseMoved = false;
        }

        // move the player
        // body.Translate(new Vector3(0,0,(mSpeed * move.y / delta)));
        // move.x = 0;
        // move.y = 0;
    }
}
