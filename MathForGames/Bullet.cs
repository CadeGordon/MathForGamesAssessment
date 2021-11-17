using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Bullet : Actor

    {
        private Vector3 _velocity;
        private float _speed;
        private float _timer;


        //Sets the speed of the bullet
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }


        //Sets the Velocity of the bullet
        public Vector3 Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }


        //Gets the position, velocity and speed of the bullet
        public Bullet(float x, float y, float z, float velocityX, float velocityZ, float speed, string name = "Actor", Shape shape = Shape.SPHERE)
            : base(x, y, z, name, shape)
        {
            _speed = speed;
            _velocity.X = velocityX;
            _velocity.Z = velocityZ;
        }

        /// <summary>
        ///Called everytime the game loops 
        /// </summary>
        public override void Update(float deltaTime, Scene currentScene)
        {

            //Create a vector that stores the move input
            Vector3 moveDirection = new Vector3(_velocity.X, _velocity.Y, _velocity.Z );

            Velocity = moveDirection.Normalized * Speed * deltaTime;

            LocalPosition += Velocity;

            base.Update(deltaTime, currentScene);

            //if the key is pressed after bullet is shot...
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                //...change the scale of the bullet
                SetScale(5, 5, 5);

        }

        
        //Calls collisoion for of the actor collides with another actor
        public override void OnCollision(Actor actor, Scene currentScene)
        {
            
            //If on colliosion the actor is enemy
            if (actor is Enemy)
            {
                //...remove the actor
                currentScene.RemoveActor(actor);
                //...remove the bullet
                currentScene.RemoveActor(this);
                //... and decrament the enemy count
                currentScene.EnemyCount--;
                
            }


        }
    }
}
