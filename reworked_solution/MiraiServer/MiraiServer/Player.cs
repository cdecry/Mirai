using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MiraiServer
{
    class Player
    {
        public int id;
        public string username;
        public string location;

        public Vector3 position;
        public Quaternion rotation;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        private bool[] inputs;

        public Player(int _id, string _username, string _location, Vector3 _spawnPosition)
        {
            id = _id;
            username = _username;
            location = _location;
            position = _spawnPosition;
            rotation = Quaternion.Identity;

            inputs = new bool[4];
        }

        public void Update()
        {
            Vector2 _inputDirection = Vector2.Zero;
            if (inputs[0])
            {
                _inputDirection.Y += 1;
            }
            if (inputs[1])
            {
                _inputDirection.Y -= 1;
            }
            if (inputs[2])
            {
                _inputDirection.X -= 1;
            }
            if (inputs[3])
            {
                _inputDirection.X += 1;
            }

            Move(_inputDirection);
        }

        public void Move(Vector2 _inputDirection)
        {
            Vector3 _up = Vector3.Transform(new Vector3(0, 1, 0), Quaternion.Identity);
            Vector3 _right = Vector3.Transform(new Vector3(1, 0, 0), Quaternion.Identity);
            Vector3 _moveDirection = _up * _inputDirection.Y + _right * _inputDirection.X;
            position += _moveDirection * moveSpeed;

            ServerSend.PlayerPosition(this);
        }

        public void SetInput(bool[] _inputs, Quaternion _rotation)
        {
            inputs = _inputs;
            rotation = _rotation;
        }
    }
}