using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
  public struct QVector2
  {
    public Quadruple x;
    public Quadruple y;
    public Quadruple len()
    {
      return Quadruple.Sqrt(x * x + y * y);
    }
    public static implicit operator QVector2(QPolarCoordinate pc)
    {
      return new QVector2(Quadruple.Cos(pc.Theta_rad) * pc.Radius, Quadruple.Sin(pc.Theta_rad) * pc.Radius);
    }

    public QVector2(Quadruple x, Quadruple y)
    {
      this.x = x;
      this.y = y;
    }
  }

  public struct QPolarCoordinate
  {
    public Quadruple Theta_rad;
    public Quadruple Radius;

    public QPolarCoordinate(Quadruple Radius, Quadruple Theta_rad)
    {
      this.Theta_rad = Theta_rad;
      this.Radius = Radius;
    }

    public static implicit operator QPolarCoordinate(QVector2 v)
    {
      return new QPolarCoordinate(v.len(), Quadruple.ATan2(v.y, v.x));
    }
  }
  class Program
  {
    static void Main(string[] args)
    {
      var pc = new QPolarCoordinate(10, 0.5);

      double r = (double)pc.Radius;
      double th = (double)pc.Theta_rad;
      System.Console.Out.WriteLine(r);
      System.Console.Out.WriteLine(th);
      var v = (QVector2) pc;
      System.Console.Out.WriteLine(v.x);
      System.Console.Out.WriteLine(v.y);
      System.Console.In.Read();
    }
  }
}
