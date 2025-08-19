using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsBallWinFormsLibrary
{
    public class Bomb : Ball
    {
        public static Action ChangeScore;
        public Color color;
        public Bomb(float x, float y, float size, float vx, float vy, float g, Color color) : base(x, y, size, vx, vy, g, color)
        {
            this.color = color;
            timer.Start();
        }
        public void Destroy()
        {
            Clear();
            ChangeScore?.Invoke();
            timer.Stop();
        }
    }
}
