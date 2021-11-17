using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{

    class Player : Actor
    {
        private Vector3 _velocity;
        private float _speed;
        private float _bulletTimer;
        
        
        //Sets the speed of the player
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        //Sets the velocity of the player
        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        //Constructor for the player setting pos
        public Player( float x, float y, float z, float speed, string name = "Actor", Shape shape = Shape.CUBE) 
            : base(x, y, z, name, shape)
        {
            _speed = speed;
        }

        /// <summary>
        ///Called everytime the game loops 
        /// </summary>
        public override void Update(float deltaTime, Scene currentScene)
        {
            //X movement direction of the player
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));
            //Z movement direction of the player
            int zDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
               + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            //X movement direction of the bullet
            int bulletDirectionX = -Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
               + Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT));
            //Z movement direction of the bullet
            int bulletDirectionZ = -Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
               + Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN));

            //Sets bullet timer to delta time
            _bulletTimer += deltaTime;

            //If bullet is not equal to zero then set bullet cool down to .30 to prevent bullet spam
            if (bulletDirectionX != 0 && _bulletTimer >= .3 || bulletDirectionZ != 0 && _bulletTimer >= .3)
            {
                Bullet bullet = new Bullet(LocalPosition.X, LocalPosition.Y, LocalPosition.Z, bulletDirectionX, bulletDirectionZ, 100, "Bullet", Shape.SPHERE);
                CircleCollider bulletCollider = new CircleCollider(1f, bullet);
                bullet.Collider = bulletCollider;
                bullet.SetScale(.3f, .3f, .3f);
                bullet.SetColor(new Vector4(234, 134, 154, 255));
                currentScene.AddActor(bullet);

                //bullettimer set to default 0
                _bulletTimer = 0;
            }

            

            

            

            //Create a vector that stores the move input
            Vector3 moveDirection = new Vector3(xDirection, 0, zDirection);

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            if (Velocity.Magnitude > 0)
               Forward = Velocity.Normalized;

            //Translate(_velocity.X, 0, _velocity.Z);

            LocalPosition += Velocity;


            base.Update(deltaTime, currentScene);
            
        }

        //Checks collison for player
        public override void OnCollision(Actor actor, Scene currentScene)
        {
            //If the actor is enemy and collides with player...
            if (actor is Enemy)
                //... Application closes
                Engine.CloseApplication();
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

    }
}
