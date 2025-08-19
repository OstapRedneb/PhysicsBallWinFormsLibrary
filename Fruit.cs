using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhysicsBallWinFormsLibrary
{
    public class Fruit : Ball
    {
        public static Action ChangeScore;
        public static Action ChangeScoreNegative;

        public Color color;
        public Fruit(float x, float y, float size, float vx, float vy, float g, Color color) : base(x, y, size, vx, vy, g, color)
        {
            this.color = color;
            timer.Start();
        }

        public override void Clear()
        {
            graphics.Clear(form.BackColor);
        }
        public override void MoveNext(object sender, EventArgs e)
        {
            if (y > form.ClientSize.Height)
            {
                ChangeScoreNegative?.Invoke();
                timer.Stop();
            }
            base.MoveNext(sender, e);
        }
        public void Destroy()
        {
            Clear();
            ChangeScore?.Invoke();
            timer.Stop();
            for (int i = 0; i < 5; i++)
            {
                Ball ball = new Ball(x + i * 2, y + i * 2, size / 5, 3, -1, 0.2f, color);
                ball.timer.Start();
            }
            for (int j = 5; j >= 0; j--)
            {
                Ball ball = new Ball(x + j * 2, y + 5 - j * 2, size / 5, -3, -1, 0.2f, color);
                ball.timer.Start();
            }
        }
    }
}
