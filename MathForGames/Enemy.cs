using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Enemy : Actor
    {
        private float _speed;
        private Vector3 _velocity;
        private Player _player;
        float x = 10;

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

        public Enemy(float x, float y, float z, float speed, Player player, string name = "Actor", Shape shape = Shape.CUBE)
            : base(x, y, z, name, shape)
        {
            _player = player;
            _speed = speed;
        }

        public override void Update(float deltaTime, Scene currentScene)
        {

            Vector3 moveDirection = _player.LocalPosition - LocalPosition;

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            Translate(Velocity.X, Velocity.Y, Velocity.Z);

            LookAt(_player.WorldPosition);
            

            AABBCollider enemyCollider = new AABBCollider(Size.X, Size.Y, Size.Z, this);
            CircleCollider sizeChangeRadius1 = new CircleCollider(20, this);
            Collider = enemyCollider;

            base.Update(deltaTime, currentScene);





            
        }

        public override void OnCollision(Actor actor, Scene currentScene)
        {
            Console.WriteLine("collison occured");

            //currentScene.RemoveActor(actor);
            
            
            
           


        }

        public override void Draw()
        {
            base.Draw();
            Collider.Draw();
        }
    }
}
