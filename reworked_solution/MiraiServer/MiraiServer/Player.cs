using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace MiraiServer
{
    class Player
    {
        public int id;
        public float flip = 1f;
        public string username;
        public string location;

        public Vector3 position;
        public Quaternion rotation;
        public Vector3 targetPosition, currentPosition;

        private float moveSpeed = 5f / Constants.TICKS_PER_SEC;
        private bool[] inputs;
        private bool mouseMovement, xMouseMovement, yMouseMovement;

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
                flip = 1f;
            }
            if (inputs[3])
            {
                _inputDirection.X += 1;
                flip = -1f;
            }

            if (mouseMovement == true)
            {
                _inputDirection = Vector2.Normalize(new Vector2(targetPosition.X, targetPosition.Y) - new Vector2(currentPosition.X, currentPosition.Y));

                if (targetPosition.X - currentPosition.X > 0)
                {
                    flip = -1f;
                }
                else if (targetPosition.X - currentPosition.X < 0)
                {
                    flip = 1f;
                }

            }


            Move(_inputDirection);
        }

        public void Move(Vector2 _inputDirection)
        {
            
            Vector3 _up = Vector3.Transform(new Vector3(0, 1, 0), Quaternion.Identity);
            Vector3 _right = Vector3.Transform(new Vector3(1, 0, 0), Quaternion.Identity);

            Vector3 _moveDirection = _up * _inputDirection.Y + _right * _inputDirection.X;
            position += _moveDirection * moveSpeed;

            ServerSend.PlayerPosition(this, flip, targetPosition);
        }

        public void SetInput(bool[] _inputs, Quaternion _rotation, Vector3 _targetPos, Vector3 _currentPos, bool _mouse, bool _x, bool _y)
        {
            inputs = _inputs;
            rotation = _rotation;
            targetPosition = new Vector3(_targetPos.X, _targetPos.Y, 0);
            currentPosition = _currentPos;
            mouseMovement = _mouse;
            xMouseMovement = _x;
            yMouseMovement = _y;
        }
    }
}