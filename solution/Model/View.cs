using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
namespace solution.Model
{
    public enum WindowPage_E : int
    {
        View = 0,
        Recipe = 1,
        Setting = 2,
    }


    internal class View
    {
        public bool Bool { get; set; } = false;

        public WindowPage_E WindowPage = WindowPage_E.View;
        public ISeries[] Series { get; set; } 
    }
}
