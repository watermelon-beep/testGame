using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public override void _Ready()
	{

	}

	public override void _PhysicsProcess(double delta)
	{

		float speed = 100;

		Velocity = Vector2.Zero;

		if(Input.IsKeyPressed(Key.W)) 
		{

			Velocity = new Vector2(0, -speed);
			playAnimation("up");

		}
		else if(Input.IsKeyPressed(Key.D) && Input.IsKeyPressed(Key.Shift))
		 {
			Velocity = new Vector2(speed * 2, 0);
			playAnimation("run");
		 }
		 else if(Input.IsKeyPressed(Key.D)) 
		{

			Velocity = new Vector2(speed, 0);
			playAnimation("right");
		}
		else if(Input.IsKeyPressed(Key.A)) 
		{

			Velocity = new Vector2(-speed, 0);
			playAnimation("left");

		}
		else if(Input.IsKeyPressed(Key.S)) 
		{

			Velocity = new Vector2(0, speed);
			playAnimation("down");

		}  
		else {	

			playAnimation("idle");

		}

		MoveAndSlide();
	}

	void playAnimation(string direction) 
	{

		AnimatedSprite2D animation = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

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
				animation.Play("run");
				break;
			case "down":
				animation.Play("walk");
				break;
			default:
				animation.Play("idle");
				break;
		}
	}
}
