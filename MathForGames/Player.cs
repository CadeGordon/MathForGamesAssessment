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
        private Vector3 _currentPosition;
        private float _speed;
        private float _bulletTimer;
        private float _currentSpeed;
        int i = 80;
        
        

        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        public Player( float x, float y, float z, float speed, string name = "Actor", Shape shape = Shape.CUBE) 
            : base(x, y, z, name, shape)
        {
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {
            int xDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_A))
                + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_D));

            int zDirection = -Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_W))
               + Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_S));

            int rotZRotation = Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_O))
                - Convert.ToInt32(Raylib.IsKeyDown(KeyboardKey.KEY_P));

            //int bulletDirectionX = -Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_LEFT))
            //   + Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_RIGHT));

            //int bulletDirectionZ = -Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_UP))
            //   + Convert.ToInt32(Raylib.IsKeyPressed(KeyboardKey.KEY_DOWN));

            //_bulletTimer += deltaTime;

            //if (bulletDirectionX != 0 && _bulletTimer >= .3 || bulletDirectionZ != 0 && _bulletTimer >= .3)
            //{
            //    Bullet bullet = new Bullet(LocalPosition.X, LocalPosition.Y, LocalPosition.Z, bulletDirectionX, bulletDirectionZ, 60, "Bullet", Shape.SPHERE);
            //    CircleCollider bulletCollider = new CircleCollider(1f, bullet);
            //    bullet.Collider = bulletCollider;
            //    bullet.SetScale(.5f, .5f, .5f);
            //    bullet.SetColor(new Vector4(234, 134, 154, 255));
            //    currentScene.AddActor(bullet);


            //    _bulletTimer = 0;
            //}





            Velocity = ((zDirection * Forward) + (xDirection * Right)).Normalized * _currentSpeed * deltaTime;



            _currentSpeed = Speed;

            Rotate(0, rotZRotation * 0.05f, 0);
            Translate(Velocity.X, 0, Velocity.Z);

            base.Update(deltaTime, currentScene);

        }

        public override void OnCollision(Actor actor, Scene currentScene)
        {
            if (actor is Enemy)
                Console.WriteLine("Collison Occured");
        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }

    }
}
