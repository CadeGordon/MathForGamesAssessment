using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class AABBCollider : Collider
    {
        private float _width;
        private float _height;
        private float _depth;

        /// <summary>
        /// The size of this collider on the x axis
        /// </summary>
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }

        /// <summary>
        /// the size of this collider on the y axis
        /// </summary>
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }

        /// <summary>
        /// the size of this collider on the z axis
        /// </summary>
        public float Depth
        {
            get { return _depth; }
            set { _depth = value; }
        }

        /// <summary>
        /// the farthest on the left x posiotion of this collider
        /// </summary>
        public float Left
        {
            get
            {
                return Owner.LocalPosition.X - Width / 2;
            }
        }

        /// <summary>
        /// the farthest on the right x position of this colldier
        /// </summary>
        public float Right
        {
            get
            {
                return Owner.LocalPosition.X + Width / 2;
            }
        }

        /// <summary>
        /// the farthest y position upwards
        /// </summary>
        public float Top
        {
            get
            {
                return Owner.LocalPosition.Y - Height / 2;
            }
        }

        /// <summary>
        /// the farthest y posistion downwards
        /// </summary>
        public float Bottom
        {
            get
            {
                return Owner.LocalPosition.Y + Height / 2;
            }
        }

        /// <summary>
        /// the farthest z posistion forwards
        /// </summary>
        public float Front 
        {
            get
            {
                return Owner.LocalPosition.Z + Depth / 2;
            }
        }

        /// <summary>
        /// the farthest z posistion towards the back
        /// </summary>
        public float Back
        {
            get
            {
                return Owner.LocalPosition.Z - Depth / 2;
            }
        }

        //Constructor for AABBCollider
        public AABBCollider(float width, float height, float depth, Actor owner) : base(owner, ColliderType.AABB)
        {
            _width = width;
            _height = height;
            _depth = depth;

        }

        //Checks for AABB collision
        public override bool CheckCollisionAABB(AABBCollider other)
        {
            //Return false if this owner is checking for a collision againts itself
            if (other.Owner == Owner)
                return false;

            //Return true if there is an overlap between boxes
            if(other.Left <= Right &&
                other.Bottom <= Top &&
                other.Back <= Front &&
                Left <= other.Right &&
                Bottom <= other.Top &&
                Back <= other.Front)
            {
                return true;
            }

            //Return false if there is no overlap
            return false;
        }

        //Checks for circle collision
        public override bool CheckCollisionCircle(CircleCollider other)
        {
            //returns AABB collision if it collides with circle collider
            return other.CheckCollisionAABB(this);
        }

        //Draws the collider box around actor
        public override void Draw()
        {
            Raylib.DrawCubeWires(new System.Numerics.Vector3(Owner.WorldPosition.X, Owner.WorldPosition.Y, Owner.WorldPosition.Z), Width, Height, Depth, Color.RED);
        }
    }
}
