using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsBallWinFormsLibrary
{
    public class Bird : Ball
    {
        public bool isFly = false;
        int tikcs = 0;

        public static Func<bool> IsTouched;

        public event Action ChangeScore;

        public Bird(float x, float y, float size, float vx, float vy, float g, Color color, Action action) : base(x, y, size, vx, vy, g, color) 
        {
            graphics = form.CreateGraphics();
            ChangeScore = action;
        }

        public override void Go()
        {
            if (IsTouched()) 
            {
                Destroy();
            }
            if (x <= 0 || x >= form.ClientSize.Width - size)
            {
                x = x <= 0 ? 0 : form.ClientSize.Width - size;
                Vx = -Vx * 0.7f;
            }

            if (y >= 389 - size)
            {
                y = 389 - size;
                Vy = -Vy * 0.7f;

                if (isFly) 
                    tikcs++;
            }

            if (tikcs >= 15 && y == 389 - size) 
            {
                Destroy();
            }

            base.Go();
        }

        private void Destroy() 
        {
            Clear();

            timer.Stop();

            Clear();

            ChangeScore();
        }
    }
}
