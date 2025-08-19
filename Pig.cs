using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsBallWinFormsLibrary
{
    public class Pig : Ball
    {
        public Pig(float x, float y, float size, float vx, float vy, float g, Color color) : base(x, y, size, vx, vy, g, color)
        {
            graphics = form.CreateGraphics();
            timer.Interval = 1;
        }

        public override void Clear()
        {
            graphics.Clear(form.BackColor);
        }
        public override void MoveNext(object sender, EventArgs e)
        {
            Show();
        }
    }
}
