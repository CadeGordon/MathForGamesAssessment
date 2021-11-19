using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibrary;
using Raylib_cs;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private Stopwatch _stopwatch = new Stopwatch();
        private Camera3D _camera = new Camera3D();
        Player _player;
        
        


        /// <summary>
        /// Called to beging the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //loop until the application is told to close
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {
                //Get How much time has passed since the application started
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set delta time to be the difference in time from the last time recorded to the current time
                deltaTime = currentTime - lastTime;

                //Update the application
                Update(deltaTime);
                //Draw all items
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currentTime;
            }

            //Call end for entire application
            End();
        }


        //Initializes Camera to be called and setup in the game
        private void InitializeCamera()
        {
            //Camera position
            _camera.position = new System.Numerics.Vector3(0, 10, 10);
            // Point the camera is focus on
            _camera.target = new System.Numerics.Vector3(0, 0, 0); 
            // Point the camera is focus on
            _camera.up = new System.Numerics.Vector3(0, 1, 0); 
            // Camera field of view
            _camera.fovy = 45;
            //Camera mode type
            _camera.projection = CameraProjection.CAMERA_PERSPECTIVE; 
        }


        /// <summary>
        /// Calls when the application starts
        /// </summary>
        private void Start()
        {


            _stopwatch.Start();

            //Create a window using raylib
            Raylib.InitWindow(800, 450, "Math For Games");
            Raylib.SetTargetFPS(0);

            InitializeCamera();

            

            Scene scene = new Scene();

            Player player = new Player(0, 0, 0, 50, "player", Shape.SPHERE);

            player.SetScale(1, 1, 1);
            player.SetColor(new Vector4(0, 0, 255, 255));
            _player = player;
            
            CircleCollider playerCircleCollider = new CircleCollider(1, player);
            player.Collider = playerCircleCollider;

            Actor companion = new Actor(2, 1.5f, 0, "Companion", Shape.SPHERE);
            companion.SetScale(.8f, .8f, .8f);
            companion.SetColor(new Vector4(255, 165, 0, 255));
            player.AddChild(companion);
            
            

            Enemy enemy = new Enemy(100, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy.SetColor(new Vector4(255, 0, 0, 255));
            enemy.SetScale(5, 5, 5);
            AABBCollider enemyAABBBoxCollider = new AABBCollider(5, 5, 5, enemy);
            enemy.Collider = enemyAABBBoxCollider;

            Enemy enemy2 = new Enemy(-100, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy2.SetColor(new Vector4(255, 0, 0, 255));
            enemy2.SetScale(5, 5, 5);
            AABBCollider enemy2AABBBoxCollider = new AABBCollider(5, 5, 5, enemy2);
            enemy2.Collider = enemy2AABBBoxCollider;

            Enemy enemy3 = new Enemy(200, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy3.SetColor(new Vector4(255, 0, 0, 255));
            enemy3.SetScale(5, 5, 5);
            AABBCollider enemy3AABBBoxCollider = new AABBCollider(5, 5, 5, enemy3);
            enemy3.Collider = enemy3AABBBoxCollider;

            Enemy enemy4 = new Enemy(-200, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy4.SetColor(new Vector4(255, 0, 0, 255));
            enemy4.SetScale(5, 5, 5);
            AABBCollider enemy4AABBBoxCollider = new AABBCollider(5, 5, 5, enemy4);
            enemy4.Collider = enemy4AABBBoxCollider;

            Enemy enemy5 = new Enemy(300, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy5.SetColor(new Vector4(255, 0, 0, 255));
            enemy5.SetScale(5, 5, 5);
            AABBCollider enemy5AABBBoxCollider = new AABBCollider(5, 5, 5, enemy5);
            enemy5.Collider = enemy5AABBBoxCollider;

            Enemy enemy6 = new Enemy(-300, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy6.SetColor(new Vector4(255, 0, 0, 255));
            enemy6.SetScale(5, 5, 5);
            AABBCollider enemy6AABBBoxCollider = new AABBCollider(5, 5, 5, enemy6);
            enemy6.Collider = enemy6AABBBoxCollider;

            Enemy enemy7 = new Enemy(400, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy7.SetColor(new Vector4(255, 0, 0, 255));
            enemy7.SetScale(5, 5, 5);
            AABBCollider enemy7AABBBoxCollider = new AABBCollider(5, 5, 5, enemy7);
            enemy7.Collider = enemy7AABBBoxCollider;

            Enemy enemy8 = new Enemy(-400, 0, 50, 40, player, "Enemy", Shape.CUBE);
            enemy8.SetColor(new Vector4(255, 0, 0, 255));
            enemy8.SetScale(5, 5, 5);
            AABBCollider enemy8AABBBoxCollider = new AABBCollider(5, 5, 5, enemy8);
            enemy8.Collider = enemy8AABBBoxCollider;

            Actor floor = new Actor(0, 0, 0, "floor");
            floor.SetScale(200, 1, 200);
            floor.SetTranslation(0, -2, 0);
            floor.SetColor(new Vector4(0, 0, 0, 255));

            

            //UIText text = new UIText(10, 10, 10, "Test Text", Color.LIME, 70, 70, 15, "This is the test text \n it is not to be taken seriously");

            //scene.AddActor(text);

            scene.AddActor(player);
            scene.AddActor(companion);
            scene.AddActor(enemy);
            scene.AddActor(enemy2);
            scene.AddActor(enemy3);
            scene.AddActor(enemy4);
            scene.AddActor(enemy5);
            scene.AddActor(enemy6);
            scene.AddActor(enemy7);
            scene.AddActor(enemy8);

            scene.AddActor(floor);
            
            
            



            _currentSceneIndex = AddScene(scene);

           

            Console.CursorVisible = false;
        }

       

        /// <summary>
        ///Called everytime the game loops 
        /// </summary>
        private void Update(float deltaTime)
        {
            _scenes[_currentSceneIndex].Update(deltaTime, _scenes[_currentSceneIndex]);

            //change the prespective of the camera (example first person)
            _camera.position = new System.Numerics.Vector3(_player.WorldPosition.X, _player.WorldPosition.Y + 5, _player.WorldPosition.Z + 15);
            _camera.target = new System.Numerics.Vector3(_player.WorldPosition.X, _player.WorldPosition.Y, _player.WorldPosition.Z);
           
           
            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private  void Draw()
        {
            
            Raylib.BeginDrawing();
            Raylib.BeginMode3D(_camera);

            Raylib.ClearBackground(Color.RAYWHITE);
            Raylib.DrawGrid(200, 1);

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndMode3D();
            Raylib.EndDrawing();
        }

        /// <summary>
        /// Called when the application exits
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
            Raylib.CloseWindow();
        }

        /// <summary>
        /// Adds a scene to the engines scene array
        /// </summary>
        /// <param name="scene">The scene that will be added to the scene array</param>
        /// <returns>The index that new scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Create a new temp array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //copy all values from the old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //set the last index to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //retunr the last index
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Gets the next key in the input stream
        /// </summary>
        /// <returns>The key that was pressed</returns>
        public static ConsoleKey GetNextKey()
        {   //If there is no key being pressed...
            if (!Console.KeyAvailable)
                //...return
                return 0;
            
            //Return the current key being pressed
            return Console.ReadKey(true).Key;
        }


        /// <summary>
        /// Ends the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true; 
        }
    }
}
