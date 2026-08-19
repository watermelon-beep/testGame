using Godot;
using System;


	public partial class Player : CharacterBody2D
{
	[Export] public float currentSpeed;
    [Export] public float WalkSpeed = 100.0f;
	[Export] public float RunSpeed = 200.0f;

	public override void _Ready()
	{

	}

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");

		if(Input.IsActionPressed("Sprint")) 
		{
			playAnimation("run");
			currentSpeed = RunSpeed;
		} 
		else currentSpeed = WalkSpeed;

        if (direction != Vector2.Zero) velocity = direction * currentSpeed;

			 if (direction.X > 0) playAnimation("right");
			else if (direction.X < 0) playAnimation("left");
			else if (direction.Y < 0) playAnimation("up");
			else if (direction.Y > 0) playAnimation("down");
			else {
				velocity = velocity.MoveToward(Vector2.Zero, currentSpeed);
				playAnimation("idle");
			}

        Velocity = velocity;
        MoveAndSlide();
    }

	void playAnimation(string direction) 
	{

		AnimatedSprite2D animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		 if (animation.Animation == direction && animation.IsPlaying())
        	return;

		switch(direction) {
			case "up":
				animation.Play("walk");
				break;
			case "left":
				animation.FlipH = true;
				animation.Play("walk");
				break;
			case "right": 
				animation.FlipH = false;
				animation.Play("walk");
				break;
			case "run":
				if (animation.Animation != "run" || !animation.IsPlaying())
					animation.Play("run");
				break;
			case "down":
				animation.Play("walk");
				break;
			default:
				animation.Play("idle");
				break;
		}

		animation.Play(direction);
	}

}


