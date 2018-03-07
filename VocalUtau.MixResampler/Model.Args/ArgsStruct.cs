using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VocalUtau.MixResampler.Model.Args
{
    public class ArgsStruct
    {
        List<int> _PitchBends;

        public List<int> PitchBends
        {
            get { return _PitchBends; }
            set { _PitchBends = value; }
        }
        public ArgsStruct()
        {
            _PitchBends = new List<int>();
        }
        public Dictionary<string, string> Options = new Dictionary<string, string>();
        public List<string> Commands = new List<string>();

        string _inputfilename;

        public string Inputfilename
        {
            get { return _inputfilename; }
            set { _inputfilename = value; }
        }
        string _outputfilename;

        public string Outputfilename
        {
            get { return _outputfilename; }
            set { _outputfilename = value; }
        }

        string _tone;

        public string Tone
        {
            get { return _tone; }
            set { _tone = value; }
        }

        double _velocity;

        public double Velocity
        {
            get { return _velocity; }
            set { _velocity = value; }
        }

        string _flags;

        public string Flags
        {
            get { return _flags; }
            set { _flags = value; }
        }

        double _offset;

        public double Offset
        {
            get { return _offset; }
            set { _offset = value; }
        }

        double _length_require;

        public double Length_Require
        {
            get { return _length_require; }
            set { _length_require = value; }
        }

        double _fix_length;

        public double Fixed_Length
        {
            get { return _fix_length; }
            set { _fix_length = value; }
        }

        double _end_blank;

        public double End_Blank
        {
            get { return _end_blank; }
            set { _end_blank = value; }
        }

        double _Intensity;

        public double Intensity
        {
            get { return _Intensity; }
            set { _Intensity = value; }
        }

        double _Modulation;

        public double Modulation
        {
            get { return _Modulation; }
            set { _Modulation = value; }
        }

        double _Tempo;

        public double Tempo
        {
            get { return _Tempo; }
            set { _Tempo = value; }
        }
    }
}
