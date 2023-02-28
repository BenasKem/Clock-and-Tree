using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock_Tree
{
    internal class Clock
    {
		private int _minutes;
        private int _hours;

        private float _angle;
        private float _hourAngle;
        private float _minuteAngle;

        public static readonly int MAX_HOURS = 12;
        public static readonly int MIN_HOURS = 1;

        public static readonly int MAX_MINUTES = 59;
        public static readonly int MIN_MINUTES = 0;

        private float _angle_per_minute = 360 / (MAX_MINUTES+1);
		private float _angle_per_hour = 360 / MAX_HOURS;
        // analog clocks' hour arrow moves by half a degree each minute
        private float _hour_per_minute = 0.5f;


        public Clock()
		{

		}


		public float HourAngle
		{
			get { return _hourAngle; }
			set { _hourAngle = value; }
		}


		public float MinuteAngle
		{
			get { return _minuteAngle; }
			set { _minuteAngle = value; }
		}


		public float AngleBetweenArrows
		{
			get { return _angle; }
			set { _angle = value; }
		}


		public int Minutes
		{
			get { return _minutes; }
			set { _minutes = value; }
		}

		public int Hours
		{
			get { return _hours; }
			set { _hours = value; }
		}

		public void CalculateLesserAngleBetweenArrows()
		{
			HourAngle = (Hours * _angle_per_hour + Minutes * _hour_per_minute);
			MinuteAngle = (Minutes * _angle_per_minute);
            float abs = Math.Abs((HourAngle- MinuteAngle));

            AngleBetweenArrows = Math.Min(360 - abs, abs);
		}

	}
}
