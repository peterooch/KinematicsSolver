using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kinematics_Solver
{
    class EquationData
    {
        public double t; // Time
        public double x; // Position
        public double a; // Acceleration
        public double v; // Velocity
        public double t0; // Initial time
        public double x0; // Initial position
        public double v0; // Initial velocity
        double deltaX;
        double deltaT;
        double t1;
        double t2;
        public string result;

        enum MsgType
        {
            time,
            pos,
            acc,
            vel,
            init_time,
            init_pos,
            init_vel,
            error
        }

        void DispMsg(MsgType msgType)
        {
                switch (msgType)
                {
                    case MsgType.time:
                        result = String.Format("Time is {0} s", t.ToString());
                        break;
                    case MsgType.pos:
                        result = String.Format("Position is at {0} m", x.ToString());
                        break;
                    case MsgType.acc:
                        result = String.Format("Acceleration is {0} m/s^2", a.ToString());
                        break;
                    case MsgType.vel:
                        result = String.Format("Velocity is {0} m/s", v.ToString());
                        break;
                    case MsgType.init_time:
                        result = String.Format("Initial Time is {0} s", t0.ToString());
                        break;
                    case MsgType.init_pos:
                        result = String.Format("Initial Position is at {0) m", x0.ToString());
                        break;
                    case MsgType.init_vel:
                        result = String.Format("Initial Velocity is {0} m/s", v0.ToString());
                        break;
                    case MsgType.error:
                        result = "More than one undefined variable";
                        break;
                }
        } //DispMsg(MsgType.error);

        void DispMsg(string msg)
        {
            result = msg;
        }

        void Delta_x(double x1, double x0)
        {
            deltaX = x1 - x0;
        }

        void Delta_t(double t1, double t0)
        {
            deltaT = t1 - t0;
        }

        bool IsNAN(double n)
        {
            return Double.IsNaN(n);
        } //NaN helper function

        //Various Equation solving functions

        //Assume if a field is empty then its the one that is required to be found

        //V(T) = V0 + A * ( T - T0 )
        public bool VelocityTime()
        {
            //find v
            if (IsNAN(v))
            {
              //check if other vars are empty
                if (IsNAN(a) || IsNAN(t))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                //assign default values
                if (IsNAN(v0)) v0 = 0.0;
                if (IsNAN(t0)) t0 = 0.0;

                v = v0 + a * (t - t0);

                DispMsg(MsgType.vel);

                return true;
            }
            //find v0
            if (IsNAN(v0))
            {
                //check if other vars are empty
                if (IsNAN(a) || IsNAN(t) || IsNAN(v))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(t0)) t0 = 0.0;

                v0 = v - a * (t - t0);
                DispMsg(MsgType.init_vel);

                return true;
            }
            //find a
            if (IsNAN(a))
            {
                //check if other vars are empty
                if (IsNAN(v) || IsNAN(t))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(t0)) t0 = 0.0;
                if (IsNAN(v0)) v0 = 0.0;

                a = (v - v0) / (t - t0);

                DispMsg(MsgType.acc);

                return true;

            }
            //find t
            if (IsNAN(t))
            {
                if(IsNAN(v) || IsNAN(a))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(t0)) t0 = 0.0;
                if (IsNAN(v0)) v0 = 0.0;

                t = ((v - v0) / a) + t0;

                DispMsg(MsgType.time);

                return true;
            }
            //find t0
            if (IsNAN(t0))
            {
                if (IsNAN(v) || IsNAN(a) || IsNAN(t))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(v0)) v0 = 0.0;

                t0 = ((v - v0) / a) - t;

                DispMsg(MsgType.init_time);

                return true;
            }

            return false;//in case of meltdown
        }
        //V^2 = V0^2 + 2 * A ( X - X0 )
        public bool VelocityDeltaA()
        {
            //find sqrt of v
            if (IsNAN(v))
            {
                if (IsNAN(a) || IsNAN(x))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(v0)) v0 = 0.0;
                if (IsNAN(x0)) x0 = 0.0;

                v = Math.Sqrt(v0 * v0 + 2 * a * (x - x0));

                DispMsg(MsgType.vel);

                return true;
            }
            //find sqrt of v0
            if (IsNAN(v0))
            {
                if (IsNAN(v) || (IsNAN(a)) || (IsNAN(x)))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(x0)) x0 = 0.0;

                v0 = Math.Sqrt(v * v - 2 * (x - x0));

                DispMsg(MsgType.init_vel);

                return true;
            }
            //find a
            if (IsNAN(a))
            {
                if (IsNAN(v) || (IsNAN(x)))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(x0)) x0 = 0.0;
                if (IsNAN(v0)) v0 = 0.0;

                a = (v * v - v0 * v0) / (2 * (x - x0));

                DispMsg(MsgType.acc);

                return true;
            }
            //find X
            if (IsNAN(x))
            {
                if (IsNAN(v) || (IsNAN(a)))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(x0)) x0 = 0.0;
                if (IsNAN(v0)) v0 = 0.0;

                x = ((v * v - v0 * v0) / 2 * a) + x0;

                DispMsg(MsgType.pos);

                return true;
            }
            //find x0
            if (IsNAN(x0))
            {
                if (IsNAN(v) || (IsNAN(a)) || IsNAN(x))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(v0)) v0 = 0.0;

                x0 = ((v * v - v0 * v0) / 2 * a) - x;

                DispMsg(MsgType.init_pos);

                return true;
            }
            return false;//in case of meltdown
        }

        //X(T) = X0 + V0 ( T - T0 ) + ((A / 2) * (( T - T0 ) ^ 2))
        public bool LocationTime()
        {
            //find x
            if(IsNAN(x))
            {
                if (IsNAN(a) || IsNAN(t))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(x0)) x0 = 0.0;
                if (IsNAN(t0)) t0 = 0.0;
                if (IsNAN(v0)) v0 = 0.0;

                x = x0 + v0 * (t - t0) + ((a / 2) * Math.Pow(t - t0, 2));

                DispMsg(MsgType.pos);

                return true;
            }
            //find x0
            if (IsNAN(x0))
            {
                if (IsNAN(a) || IsNAN(t) || IsNAN(x))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(t0)) t0 = 0.0;
                if (IsNAN(v0)) v0 = 0.0;

                Delta_t(t, t0);

                x0 = v0 * deltaT + ((a / 2) * Math.Pow(deltaT, 2)) - x;

                DispMsg(MsgType.pos);

                return true;
            }
            //find v0
            if (IsNAN(v0))
            {
                if(IsNAN(a) || IsNAN(t) || IsNAN(x))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(t0)) t0 = 0.0;
                if (IsNAN(x0)) x0 = 0.0;

                Delta_t(t, t0);

                v0 = (x - x0 - ((a / 2)* Math.Pow(deltaT,2))) / deltaT;

                DispMsg(MsgType.init_vel);

                return true;
            }
            //find a
            if (IsNAN(a))
            {
                if(IsNAN(x) || IsNAN(t))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(v0)) v0 = 0.0;
                if (IsNAN(x0)) x0 = 0.0;
                if (IsNAN(t0)) t0 = 0.0;

                Delta_t(t, t0);

                a = ((x-x0 - v0 * deltaT)/2) * Math.Pow(deltaT, 2);

                DispMsg(MsgType.acc);

                return true;
            }
            //find t
            if (IsNAN(t))
            {
                if(IsNAN(x) || IsNAN(a))
                {
                    DispMsg(MsgType.error);
                    return false;
                }
                if (IsNAN(v0)) v0 = 0.0;
                if (IsNAN(x0)) x0 = 0.0;
                if (IsNAN(t0)) t0 = 0.0;

                //if a is 0 then its a single solution
                if(a == 0.0)
                {
                    t = ((x - x0) / v0) + t0;

                    DispMsg(MsgType.time);
                    return true;
                }
                else // a != 0 means a squared t 
                {
                    //passing vars to a dedicated function
                    bool qresult = Quadratic(a / 2, v0, x0 - x);
                    if(!qresult)
                    {
                        //called function should input error code
                        return false;
                    }

                    return true;
                }
                
            }
            //find t0 (erm...)

            return false;//in case of meltdown
        }

        bool Quadratic(double a, double b, double c)
        {
            //if a is 0 - sanity check in case of odd thing happens at the calling function
            if (a == 0.0)
            {
                DispMsg("The squared variable cannot be 0!"); //linear function
                return false;
            }
            double divider = 2 * a;
            double delta = Math.Sqrt(b * b - 4 * a * c);
            if (IsNAN(delta))
            {
                DispMsg("No Results"); // "Hovering" Function
                return false;
            }
            t1 = (-b + delta) / divider;
            t2 = (-b - delta) / divider;
            if (t0 == 0.0)
                DispMsg(String.Format("T1 = {0} s, T2 = {1} s", t1.ToString(), t2.ToString()));
            else
                DispMsg(String.Format("T1 = {0} s, T2 = {1} s", (t1+t0).ToString(), (t2+t0).ToString()));
            return true;
           
        }
    }
}
